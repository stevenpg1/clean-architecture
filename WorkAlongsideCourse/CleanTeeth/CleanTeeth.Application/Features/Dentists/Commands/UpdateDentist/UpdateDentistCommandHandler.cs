using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
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
        public Task Handle(UpdateDentistCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
