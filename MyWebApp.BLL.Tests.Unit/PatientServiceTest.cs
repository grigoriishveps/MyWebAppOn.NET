using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using MyWebApp.BLL.Contracts;
using MyWebApp.BLL.Implementation;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using NUnit.Framework;

namespace MyWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class PatientServiceTest
    {
        [Test]
        public async Task ValidateAsync_PatientExists_DoesNothing()
        {
            // Arrange
            var patientContainer = new Mock<IPatientContainer>();

            var patient = new Patient();
            var streetService = new Mock<IStreetService>();
            var patientDAL = new Mock<IPatientDAL>();
            var patientIdentity = new Mock<IPatientIdentity>();
            patientDAL.Setup(x => x.GetAsync(patientIdentity.Object)).ReturnsAsync(patient);

            var patientGetService = new PatientService(patientDAL.Object,streetService.Object);
            
            // Act
            var action = new Func<Task>(() => patientGetService.ValidateAsync(patientContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_PatientNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var patientContainer = new Mock<IPatientContainer>();
            patientContainer.Setup(x => x.PatientId).Returns(id);
            var patientIdentity = new Mock<IPatientIdentity>();
            var streetService = new Mock<IStreetService>();
            var patient = new Patient();
            var patientDAL = new Mock<IPatientDAL>();
            patientDAL.Setup(x => x.GetAsync(patientIdentity.Object)).ReturnsAsync((Patient) null);

            var patientGetService = new PatientService(patientDAL.Object,streetService.Object);

            // Act
            var action = new Func<Task>(() => patientGetService.ValidateAsync(patientContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Patient not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_PatientValidationSucceed_CreatesPatient()
        {
            // Arrange
            var patient = new PatientUpdateModel();
            var expected = new Patient();
            
            var streetService = new Mock<IStreetService>();
            streetService.Setup(x => x.ValidateAsync(patient));

            var patientDAL = new Mock<IPatientDAL>();
            patientDAL.Setup(x => x.InsertAsync(patient)).ReturnsAsync(expected);

            var patientService = new PatientService(patientDAL.Object, streetService.Object);
            
            // Act
            var result = await patientService.CreateAsync(patient);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_PatientValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var patient = new PatientUpdateModel();
            var expected = fixture.Create<string>();
            
            var streetService = new Mock<IStreetService>();
            streetService
                .Setup(x => x.ValidateAsync(patient))
                .Throws(new InvalidOperationException(expected));
            
            var patientDAL = new Mock<IPatientDAL>();
            
            var patientService = new PatientService(patientDAL.Object, streetService.Object);
            
            var action = new Func<Task>(() => patientService.CreateAsync(patient));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            patientDAL.Verify(x => x.InsertAsync(patient), Times.Never);
        }
    }
}