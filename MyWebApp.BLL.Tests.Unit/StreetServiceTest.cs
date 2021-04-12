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
    public class StreetServiceTest
    {
        [Test]
        public async Task ValidateAsync_StreetExists_DoesNothing()
        {
            // Arrange
            var streetContainer = new Mock<IStreetContainer>();

            var street = new Street();
            var streetDAL = new Mock<IStreetDAL>();
            var streetIdentity = new Mock<IStreetIdentity>();
            streetDAL.Setup(x => x.GetAsync(streetIdentity.Object)).ReturnsAsync(street);

            var streetGetService = new StreetService(streetDAL.Object);
            
            // Act
            var action = new Func<Task>(() => streetGetService.ValidateAsync(streetContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_StreetNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var streetContainer = new Mock<IStreetContainer>();
            streetContainer.Setup(x => x.StreetId).Returns(id);
            var streetIdentity = new Mock<IStreetIdentity>();
            var street = new Street();
            var streetDAL = new Mock<IStreetDAL>();
            streetDAL.Setup(x => x.GetAsync(streetIdentity.Object)).ReturnsAsync((Street) null);

            var streetGetService = new StreetService(streetDAL.Object);

            // Act
            var action = new Func<Task>(() => streetGetService.ValidateAsync(streetContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Street not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_StreetValidationSucceed_CreatesStreet()
        {
            // Arrange
            var street = new StreetUpdateModel();
            var expected = new Street();
            
            var streetDAL = new Mock<IStreetDAL>();
            streetDAL.Setup(x => x.InsertAsync(street)).ReturnsAsync(expected);

            var streetService = new StreetService(streetDAL.Object);
            
            // Act
            var result = await streetService.CreateAsync(street);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}