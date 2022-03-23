using FakeItEasy;
using GuideBookProject.Controllers;
using GuideBookProject.Models;
using GuideBookProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GuideBookTests
{
    public class GuideBookTests
    {
        [Fact]
        public async Task GetPersons_Returns_The_All_Persons_Data()
        {
            // Arrange

            // create fake instance
            var datastore = A.Fake<IGuideRepository>();

            // int count = 5;
            // var fakedata = A.CollectionOfDummy<Person>(count).AsEnumerable();
            //// when we invoke Get_Persons is it return anything?
            // A.CallTo(() => datastore.Get_Persons(count)).Return(Task.FromResult(fakedata));

            A.CallTo(() => datastore.Get_Persons());

            var controller = new GuideController(datastore);



            // Act
            var actionResult = await controller.GetPersons();




            // Assert
            var result = actionResult as OkObjectResult;
            Assert.NotNull(result);
        }
    }
}
