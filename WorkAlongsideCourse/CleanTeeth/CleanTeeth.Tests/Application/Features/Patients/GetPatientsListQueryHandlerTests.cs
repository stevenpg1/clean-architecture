using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Tests.Application.Features.Patients
{
    [TestClass]
    public class GetPatientsListQueryHandlerTests
    {
        private IPatientRepository m_Repository;
        private GetPatientsListQueryHandler m_Handler;

        [TestInitialize]
        public void Initialize()
        {
            m_Repository = Substitute.For<IPatientRepository>();
            m_Handler = new GetPatientsListQueryHandler(m_Repository);
        }

        [TestMethod]
        public async Task Handle_ValidQuery_ReturnsPaginatedListOfPatients()
        {
            //Arrange
            var page = 1;
            var recordsPerPage = 2;

            var patients = new List<Patient> {
                new Patient("Patient A", new Email("patient1@fred.com")),
                new Patient("Patient B", new Email("patient2@fred.com"))
            };
            
            var query = new GetPatientsListQuery
            {
                Page = page,
                RecordsPerPage = recordsPerPage
            };

            m_Repository.GetFiltered(Arg.Any<PatientsFilterDTO>()).Returns(patients);
            m_Repository.GetRecordCount().Returns(10);

            //Act
            var result = await m_Handler.Handle(query);

            //Assert
            Assert.AreEqual(10, result.RecordCount);
            Assert.AreEqual(2, result.Elements.Count);
            Assert.AreEqual(patients[0].Name, result.Elements[0].Name);
            Assert.AreEqual(patients[1].Name, result.Elements[1].Name);
        }

        [TestMethod]
        public async Task Handle_WhenThereAreNoPatients_ItReturnsEmptyList()
        {
            var query = new GetPatientsListQuery { Page = 1, RecordsPerPage = 5};
            var patients = new List<Patient>();
            m_Repository.GetFiltered(Arg.Any<PatientsFilterDTO>()).Returns(patients);
            m_Repository.GetRecordCount().Returns(0);

            //Act
            var result = await m_Handler.Handle(query);

            //Assert
            Assert.IsNotNull(result.Elements);
            Assert.AreEqual(0, result.RecordCount);
            Assert.AreEqual(0, result.Elements.Count);
        }
    }
}