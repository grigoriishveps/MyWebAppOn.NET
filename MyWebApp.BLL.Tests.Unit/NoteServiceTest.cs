using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using MyWebApp.BLL.Contracts;
using MyWebApp.BLL.Implementation;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain;
using MyWebApp.Domain.Models;
using NUnit.Framework;

namespace MyWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class NoteServiceTest
    {
        [Test]
        public async Task CreateAsync_NoteValidationSucceed_CreatesNote()
        {
            // Arrange
            var note = new NoteUpdateModel();
            var expected = new Note();
            
            //var departmentGetService = new Mock<IDepartmentGetService>();
            //departmentGetService.Setup(x => x.ValidateAsync(employee));

            var noteDAL = new Mock<INoteDAL>();
            noteDAL.Setup(x => x.InsertAsync(note)).ReturnsAsync(expected);

            var noteService = new NoteService(noteDAL.Object);
            
            // Act
            var result = await noteService.CreateAsync(note);
            
            // Assert
            result.Should().Be(expected);
        }
        
        //[Test]
        public async Task CreateAsync_NoteValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var note = new NoteUpdateModel();
            var expected = fixture.Create<string>();
            
            // var patientService = new Mock<IPatientService>();
            // patientService
            //     .Setup(x => x.ValidateAsync(employee))
            //     .Throws(new InvalidOperationException(expected));
            // var doctorService = new Mock<INoteService>();
            // patientService
            //     .Setup(x => x.ValidateAsync(employee))
            //     .Throws(new InvalidOperationException(expected));
            // var departmentService = new Mock<INoteService>();
            // patientService
            //     .Setup(x => x.ValidateAsync(employee))
            //     .Throws(new InvalidOperationException(expected));
            
            var noteDAL = new Mock<INoteDAL>();
            
            var noteService = new NoteService(noteDAL.Object);
            
            var action = new Func<Task>(() => noteService.CreateAsync(note));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            noteDAL.Verify(x => x.InsertAsync(note), Times.Never);
        }
    }
}