using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Commands.UpdateDentist
{
    public class UpdateDentistCommandHandler : IRequestHandler<UpdateDentistCommand>
    {
        private readonly IDentistRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateDentistCommandHandler(
            IDentistRepository repository,
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateDentistCommand request)
        {
            var dentist = await repository.GetById(request.Id);

            if (dentist is null)
            {
                throw new NotFoundException();
            }

            dentist.UpdateName(request.Name);
            dentist.UpdateEmail(new Email(request.Email));

            try
            {
                await repository.Update(dentist);
                await unitOfWork.Commit();
            }
            catch (Exception)
            {
                await unitOfWork.Rollback();
                throw;
            }
        }
    }
}
