using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        private readonly IAppointmentRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CreateAppointmentCommandHandler(
            IAppointmentRepository repository,
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAppointmentCommand request)
        {
            var overlapExists = await repository.OverlapExists(request.DentistId, request.StartDate, request.EndDate);

            if (overlapExists)
            {
                throw new CustomValidationException("The dentist has an overlapping appointment during the specified time.");
            }

            var timeInterval = new TimeInterval(request.StartDate, request.EndDate);
            var appointment = new Appointment(request.PatientId, request.DentistId, request.DentalOfficeId, timeInterval);

            try
            {
                var result = await repository.Add(appointment);
                await unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception)
            {
                await unitOfWork.Rollback();
                throw;
            }
        }
    }
}
