using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.Patients
{
    [TestClass]
    public class CreatePatientCommandHandlerTests
    {
        private IPatientRepository m_Repository;
        private IUnitOfWork m_UnitOfWork;
        private CreatePatientCommandHandler m_Handler;

        [TestInitialize]
        public void Initialize()
        {
            m_Repository = Substitute.For<IPatientRepository>();
            m_UnitOfWork = Substitute.For<IUnitOfWork>();
            m_Handler = new CreatePatientCommandHandler(m_Repository, m_UnitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnPatientId()
        {
            //Arrange
            var command = new CreatePatientCommand { Name = "Patient A", Email = "bob.loblaw@email.com" };
            var patient = new Patient("Patient A", new Email(command.Email));
            m_Repository.Add(Arg.Any<Patient>()).Returns(patient);

            //Act
            var result = await m_Handler.Handle(command);

            //Assert
            await m_Repository.Received(1).Add(Arg.Any<Patient>());
            await m_UnitOfWork.Received(1).Commit();
            Assert.AreEqual(patient.Id, result);
        }

        [TestMethod]
        public async Task Handle_WhenThereIsAnError_UnitOfWorkRollbackIsCalled()
        {
            var command = new CreatePatientCommand { Name = "Patient A", Email = "bob.loblaw@email.com" };
            m_Repository.Add(Arg.Any<Patient>()).Throws<Exception>();

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
