using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDaentalOffice;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.DentalOffices
{
    [TestClass]
    public class UpdateAppointmentCommandHandlerTests
    {
        private IDentalOfficeRepository m_Repository;
        private IUnitOfWork m_UnitOfWork;
        private UpdateDentalOfficeCommandHandler m_Handler;

        [TestInitialize]
        public void Initialize()
        {
            m_Repository = Substitute.For<IDentalOfficeRepository>();
            m_UnitOfWork = Substitute.For<IUnitOfWork>();
            m_Handler = new UpdateDentalOfficeCommandHandler(m_Repository, m_UnitOfWork);
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeExists_EntityIsUpdateAndPersisted()
        {
            var dentalOffice = new DentalOffice("Dental Office A");
            var id = dentalOffice.Id;
            var command = new UpdateDentalOfficeCommand { Id = id, Name = "Updated Name" };

            m_Repository.GetById(id).Returns(dentalOffice);

            await m_Handler.Handle(command);

            await m_Repository.Received(1).Update(dentalOffice);
            await m_UnitOfWork.Received(1).Commit();

        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task Handle_WhenDentalOfficeDoesNotExist_ExceptionIsThrown()
        {
            var command = new UpdateDentalOfficeCommand { Id = Guid.NewGuid(), Name = "Updated Name" };
            m_Repository.GetById(command.Id).ReturnsNull();
            await m_Handler.Handle(command);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public async Task Handle_WhenDentalOfficeNameIsEmpty_ExceptionIsThrown()
        {
            var dentalOffice = new DentalOffice("Dental Office A");
            var id = dentalOffice.Id;
            var command = new UpdateDentalOfficeCommand { Id = id, Name = "" };
            m_Repository.GetById(id).Returns(dentalOffice);
            await m_Handler.Handle(command);
        }

        [TestMethod]
        public async Task Handle_WhenThereIsAnError_UnitOfWorkRollbackIsCalled()
        {
            var dentalOffice = new DentalOffice("Dental Office A");
            var id = dentalOffice.Id;
            var command = new UpdateDentalOfficeCommand { Id = id, Name = "Dental Office A" };
            m_Repository.GetById(id).Returns(dentalOffice);

            m_Repository.Update(Arg.Any<DentalOffice>()).Throws<Exception>();

            //Act
            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await m_Handler.Handle(command);
            });

            //Assert
            await m_UnitOfWork.Received(1).Rollback();
        }
    }
}