using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Domain.Entities;
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
    public class GetDentalOfficeDetailQueryHandlerTests
    {
        private IDentalOfficeRepository m_Repository;
        private GetDentalOfficeDetailQueryHandler m_Handler;

        [TestInitialize]
        public void Initialize()
        {
            m_Repository = Substitute.For<IDentalOfficeRepository>();
            m_Handler = new GetDentalOfficeDetailQueryHandler(m_Repository);
        }

        [TestMethod]
        public async Task Handle_DentalOfficeWhenItExists_ItReturnsWithIt()
        {
            //Arrange
            var dentalOffice = new DentalOffice("Dental Office A");
            var id = dentalOffice.Id;
            var query = new GetDentalOfficeDetailQuery { Id = id };
            m_Repository.GetById(query.Id).Returns(dentalOffice);

            //Act
            var result = await m_Handler.Handle(query);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, id);
            Assert.AreEqual(result.Name, result.Name);
        }

        [TestMethod]
        public async Task Handle_WhenItDoesNotExist_ItThrowsError()
        {
            var id = Guid.NewGuid();
            var query = new GetDentalOfficeDetailQuery { Id = id };
            m_Repository.GetById(id).ReturnsNull();

            //This works but want to try the exactly version below when i upgrade to mstest 4 (i have 3.6.4 atm)
            await Assert.ThrowsExceptionAsync<NotFoundException>(async () =>
            {
                await m_Handler.Handle(query);
            });

            //This is only available in mstest 4
            //await Assert.ThrowsExactly<NotFoundException>(() =>
            //{
            //    await m_Handler.Handle(query);
            //});
        }
    }
}