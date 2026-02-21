using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.DentalOffices
{
    [TestClass]
    public class CreateDentalOfficeCommandHandlerTests
    {
        private IDentalOfficeRepository m_Repository;
        private IUnitOfWork m_UnitOfWork;
        private CreateDentalOfficeCommandHandler m_Handler;

        [TestInitialize]
        public void Initialize()
        {
            m_Repository = Substitute.For<IDentalOfficeRepository>();
            m_UnitOfWork = Substitute.For<IUnitOfWork>();
            m_Handler = new CreateDentalOfficeCommandHandler(m_Repository, m_UnitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnDentalOfficeId()
        {
            //Arrange
            var command = new CreateDentalOfficeCommand { Name = "Dental Office A" };
            var dentalOffice = new DentalOffice("Dental Office A");
            m_Repository.Add(Arg.Any<DentalOffice>()).Returns(dentalOffice);

            //Act
            var result = await m_Handler.Handle(command);

            //Assert
            await m_Repository.Received(1).Add(Arg.Any<DentalOffice>());
            await m_UnitOfWork.Received(1).Commit();
            Assert.AreEqual(dentalOffice.Id, result);
        }

        [TestMethod]
        public async Task Handle_WhenThereIsAnError_UnitOfWorkRollbackIsCalled()
        {
            var command = new CreateDentalOfficeCommand { Name = "Dental Office A" };
            m_Repository.Add(Arg.Any<DentalOffice>()).Throws<Exception>();

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
