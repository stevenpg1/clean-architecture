using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentailOfficesList;
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
    public class GetAppointmentsListQueryHandlerTests
    {
        private IDentalOfficeRepository m_Repository;
        private GetDentalOfficesListQueryHandler m_Handler;

        [TestInitialize]
        public void Initialize()
        {
            m_Repository = Substitute.For<IDentalOfficeRepository>();
            m_Handler = new GetDentalOfficesListQueryHandler(m_Repository);
        }

        [TestMethod]
        public async Task Handle_DentalOfficesList_ItReturnsList()
        {
            //Arrange
            var dentalOffices = new List<DentalOffice> {
                new DentalOffice("Dental Office A"),
                new DentalOffice("Dental Office B")
            };
            
            var query = new GetDentalOfficesListQuery {  };
            
            m_Repository.GetAll().Returns(dentalOffices);

            //Act
            var result = await m_Handler.Handle(query);

            //Assert
            Assert.AreEqual(2, result.DentalOffices.Count);
            Assert.AreEqual(dentalOffices[0].Name, result.DentalOffices[0].Name);
            Assert.AreEqual(dentalOffices[1].Name, result.DentalOffices[1].Name);
        }

        [TestMethod]
        public async Task Handle_WhenThereAreNoOffice_ItReturnsEmptyList()
        {
            var query = new GetDentalOfficesListQuery { };

            m_Repository.GetAll().Returns([]);

            //Act
            var result = await m_Handler.Handle(query);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.DentalOffices.Count);
        }
    }
}