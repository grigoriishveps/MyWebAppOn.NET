using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using MyWebApp.BLL.Implementation;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using NUnit.Framework;

namespace MyWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class DoctorServiceTest
    {
        [Test]
        public async Task ValidateAsync_DoctorExists_DoesNothing()
        {
            // Arrange
            var doctorContainer = new Mock<IDoctorContainer>();

            var doctor = new Doctor();
            var doctorDAL = new Mock<IDoctorDAL>();
            var doctorIdentity = new Mock<IDoctorIdentity>();
            doctorDAL.Setup(x => x.GetAsync(doctorIdentity.Object)).ReturnsAsync(doctor);

            var doctorGetService = new DoctorService(doctorDAL.Object);
            
            // Act
            var action = new Func<Task>(() => doctorGetService.ValidateAsync(doctorContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_DoctorNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var doctorContainer = new Mock<IDoctorContainer>();
            doctorContainer.Setup(x => x.DoctorId).Returns(id);
            var doctorIdentity = new Mock<IDoctorIdentity>();
            var doctor = new Doctor();
            var doctorDAL = new Mock<IDoctorDAL>();
            doctorDAL.Setup(x => x.GetAsync(doctorIdentity.Object)).ReturnsAsync((Doctor) null);

            var doctorGetService = new DoctorService(doctorDAL.Object);

            // Act
            var action = new Func<Task>(() => doctorGetService.ValidateAsync(doctorContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Doctor not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_DoctorValidationSucceed_CreatesStreet()
        {
            // Arrange
            var doctor = new DoctorUpdateModel();
            var expected = new Doctor();
            
            //var departmentGetService = new Mock<IDepartmentGetService>();
            //departmentGetService.Setup(x => x.ValidateAsync(employee));

            var doctorDAL = new Mock<IDoctorDAL>();
            doctorDAL.Setup(x => x.InsertAsync(doctor)).ReturnsAsync(expected);

            var streetService = new DoctorService(doctorDAL.Object);
            
            // Act
            var result = await streetService.CreateAsync(doctor);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}