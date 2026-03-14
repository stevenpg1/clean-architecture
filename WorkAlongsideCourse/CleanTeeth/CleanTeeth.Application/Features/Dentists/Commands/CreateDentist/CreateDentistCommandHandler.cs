using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Dentists.Commands.CreateDentist
{
    public class CreateDentistCommandHandler : IRequestHandler<CreateDentistCommand, Guid>
    {
        private readonly IDentistRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CreateDentistCommandHandler(
            IDentistRepository repository,
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public Task<Guid> Handle(CreateDentistCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
