using FakeItEasy;
using GuideBookProject.Controllers;
using GuideBookProject.Models;
using GuideBookProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using AutoFixture;
using Moq;
using FluentAssertions;


namespace GuideBookTests
{
    public class GuideBookTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IGuideRepository> _guideMock;
        private readonly GuideController _guidecont;

        public GuideBookTests()
        {
            _fixture = new Fixture();
            _guideMock = _fixture.Freeze<Mock<IGuideRepository>>();
            _guidecont = new GuideController(_guideMock.Object);  // creates in-memory implementation
        }

        [Fact]
        public async Task GetPersons_Should_Return_The_All_Persons_Data()
        {
            // Arrange
            var personsMock = _fixture.Create<IEnumerable<Person>>();
            _guideMock.Setup(x => x.Get_Persons()).ReturnsAsync(personsMock);


            // Act
            var result = await _guidecont.GetPersons().ConfigureAwait(false);

            // Assert
            //Assert.NotNull(result);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<Person>>();

        }


        [Fact]
        public async Task GetPerson_Should_Return_Selected_Person_data()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var personMock = _fixture.Create<Person>();
            _guideMock.Setup(x => x.Get_Person(id)).ReturnsAsync(personMock);

            // Act
            var result = await _guidecont.GetPerson(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<Person>>();
        }


        [Fact]
        public async Task AddPerson_Should_Return_Ok_Response()
        {
            // Arrange
            var request = _fixture.Create<Person>();
            var response = _fixture.Create<Person>();
            _guideMock.Setup(x => x.Add_Person(request)).ReturnsAsync(response);

            // Act
            var result = await _guidecont.AddPerson(request).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<Person>>();
        }


        [Fact]
        public async Task UpdatePerson_Should_Return_Updated_Person()
        {
            // Arrange
            var request = _fixture.Create<Person>();
            var response = _fixture.Create<Person>();
            _guideMock.Setup(x => x.Update_Person(request)).ReturnsAsync(response);

            // Act
            var result = await _guidecont.UpdatePerson(request).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<Person>>();
        }


        [Fact]
        public async Task DeletePerson_Should_Delete_Person()
        {
            // Arrange
            var id = _fixture.Create<int>();
            _guideMock.Setup(x => x.Delete_Person(id));

            // Act
            var result = await _guidecont.DeletePerson(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<Person>>();
        }


        [Fact]
        public async Task RemovePerson_Should_Remove_Person()
        {
            // Arrange
            var id = _fixture.Create<int>();
            _guideMock.Setup(x => x.Remove_Person(id));

            // Act
            var result = await _guidecont.RemovePerson(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<Person>>();
        }


        [Fact]
        public async Task AddCommInfo_Should_Return_Ok_Response()
        {
            // Arrange
            var request = _fixture.Create<CommInfo>();
            var response = _fixture.Create<CommInfo>();
            _guideMock.Setup(x => x.Add_CommInfo(request)).ReturnsAsync(response);

            // Act
            var result = await _guidecont.AddCommInfo(request).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<CommInfo>>();
        }


        [Fact]
        public async Task RemoveCommInfo_Should_Remove_Communication_Values()
        {
            // Arrange
            var id = _fixture.Create<int>();
            _guideMock.Setup(x => x.Remove_CommInfo(id));

            // Act
            var result = await _guidecont.RemoveCommInfo(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<CommInfo>>();
        }


        [Fact]
        public async Task GetCommInfo_Should_Return_Selected_Communication_Data()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var comminfoMock = _fixture.Create<CommInfo>();
            _guideMock.Setup(x => x.Get_CommInfo(id)).ReturnsAsync(comminfoMock);

            // Act
            var result = await _guidecont.GetCommInfo(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<CommInfo>>();
        }


        [Fact]
        public async Task Reportx_Should_Return_Report_Values()
        {
            // Arrange
            var personsMock = _fixture.Create<List<Report>>();
            _guideMock.Setup(x => x.Reportx()).ReturnsAsync(personsMock);


            // Act
            var result = await _guidecont.Reportx().ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<Person>>();
        }
    }
}
