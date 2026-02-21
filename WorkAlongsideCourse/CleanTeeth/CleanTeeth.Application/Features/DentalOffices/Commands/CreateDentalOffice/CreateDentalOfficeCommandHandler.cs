using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandHandler : IRequestHandler<CreateDentalOfficeCommand, Guid>
    {
        private readonly IDentalOfficeRepository repository;
        private readonly IUnitOfWork unitOfWork;
        //private readonly IValidator<CreateDentalOfficeCommand> validator; //With this code now in simplemediator, this is no longer necessary here

        public CreateDentalOfficeCommandHandler(
            IDentalOfficeRepository repository,
            IUnitOfWork unitOfWork
            //IValidator<CreateDentalOfficeCommand> validator //With this code now in simplemediator, this is no longer necessary here
            )
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            //this.validator = validator; //With this code now in simplemediator, this is no longer necessary here
        }

        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {
            //THIS VALIDATION CHECKING HAS BEEN MOVED TO SIMPLEMEDIATOR
            //var validationResult = await validator.ValidateAsync(command);

            //if (!validationResult.IsValid)
            //{
            //    throw new CustomValidationException(validationResult);
            //}

            var dentalOffice = new DentalOffice(command.Name);
            try
            {
                var result = await repository.Add(dentalOffice);
                await unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception ex)
            {
                await unitOfWork.Rollback();
                throw;
            }

            
        }
    }
}
