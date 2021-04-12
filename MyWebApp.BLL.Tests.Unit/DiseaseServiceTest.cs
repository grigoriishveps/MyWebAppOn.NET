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
    public class DiseaseServiceTest
    {
        [Test]
        public async Task ValidateAsync_DiseaseExists_DoesNothing()
        {
            // Arrange
            var diseaseContainer = new Mock<IDiseaseContainer>();

            var disease = new Disease();
            var diseaseDAL = new Mock<IDiseaseDAL>();
            var diseaseIdentity = new Mock<IDiseaseIdentity>();
            diseaseDAL.Setup(x => x.GetAsync(diseaseIdentity.Object)).ReturnsAsync(disease);

            var diseaseGetService = new DiseaseService(diseaseDAL.Object);
            
            // Act
            var action = new Func<Task>(() => diseaseGetService.ValidateAsync(diseaseContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_DiseaseNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var diseaseContainer = new Mock<IDiseaseContainer>();
            diseaseContainer.Setup(x => x.DiseaseId).Returns(id);
            var diseaseIdentity = new Mock<IDiseaseIdentity>();
            var disease = new Disease();
            var diseaseDAL = new Mock<IDiseaseDAL>();
            diseaseDAL.Setup(x => x.GetAsync(diseaseIdentity.Object)).ReturnsAsync((Disease) null);

            var diseaseGetService = new DiseaseService(diseaseDAL.Object);

            // Act
            var action = new Func<Task>(() => diseaseGetService.ValidateAsync(diseaseContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Disease not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_DiseaseValidationSucceed_CreatesStreet()
        {
            // Arrange
            var disease = new DiseaseUpdateModel();
            var expected = new Disease();
            
            var diseaseDAL = new Mock<IDiseaseDAL>();
            diseaseDAL.Setup(x => x.InsertAsync(disease)).ReturnsAsync(expected);

            var diseaseService = new DiseaseService(diseaseDAL.Object);
            
            // Act
            var result = await diseaseService.CreateAsync(disease);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}