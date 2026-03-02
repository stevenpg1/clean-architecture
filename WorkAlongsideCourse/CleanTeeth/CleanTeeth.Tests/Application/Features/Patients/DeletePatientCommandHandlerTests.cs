using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
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
    public class DeletePatientCommandHandlerTests
    {
        private IDentalOfficeRepository m_Repository;
        private IUnitOfWork m_UnitOfWork;
        private DeleteDentalOfficeCommandHandler m_Handler;

        [TestInitialize]
        public void Initialize()
        {
            m_Repository = Substitute.For<IDentalOfficeRepository>();
            m_UnitOfWork = Substitute.For<IUnitOfWork>();
            m_Handler = new DeleteDentalOfficeCommandHandler(m_Repository, m_UnitOfWork);
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeExists_EntityIsDeleted()
        {
            var dentalOffice = new DentalOffice("Dental Office A");
            var id = dentalOffice.Id;
            var command = new DeleteDentalOfficeCommand { Id = id };

            m_Repository.GetById(id).Returns(dentalOffice);

            await m_Handler.Handle(command);

            await m_Repository.Received(1).Delete(dentalOffice);
            await m_UnitOfWork.Received(1).Commit();

        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task Handle_WhenDentalOfficeDoesNotExist_ExceptionIsThrown()
        {
            var command = new DeleteDentalOfficeCommand { Id = Guid.NewGuid() };
            m_Repository.GetById(command.Id).ReturnsNull();
            await m_Handler.Handle(command);
        }

        [TestMethod]
        public async Task Handle_WhenThereIsAnError_UnitOfWorkRollbackIsCalled()
        {
            var dentalOffice = new DentalOffice("Dental Office A");
            var id = dentalOffice.Id;
            var command = new DeleteDentalOfficeCommand { Id = id};
            m_Repository.GetById(id).Returns(dentalOffice);

            m_Repository.Delete(Arg.Any<DentalOffice>()).Throws<Exception>();

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