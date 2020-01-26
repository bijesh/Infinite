using Infinite.Contract;
using Infinite.Controllers;
using Infinite.Interface;
using Infinite.ViewModel;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Test.Controllers
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class HomeControllerTests
    {
        private HomeController _homeController;
        private Mock<IPersonService> _personService;
        private Mock<IPersonViewModelBuilder> _personViewModelBuilder;

        [SetUp]
        public void Setup()
        {
            _personService = new Mock<IPersonService>();
            _personService.Setup(x => x.GetPerson()).ReturnsAsync(GetPersonList());
            _personViewModelBuilder = new Mock<IPersonViewModelBuilder>();
            _personViewModelBuilder.Setup(x => x.Build(It.IsAny<Person>())).Returns(GetPersonViewModel());
            _homeController = new HomeController(_personService.Object, _personViewModelBuilder.Object);
        }

        [Test]
        public async Task Get_Returns_Instance_Of_IEnumerable_PersonViewModel()
        {
            // Act
            var result = await _homeController.Get();

            // Assert
            Assert.IsInstanceOf<IEnumerable<PersonViewModel>>(result);
        }

        [Test]
        public async Task Get_Calls_GetPerson_Service()
        {
            // Act
            await _homeController.Get();

            // Assert
            _personService.Verify(x => x.GetPerson(), Times.Once);
        }

        private List<Person> GetPersonList()
        {
            return new List<Person>()
            {
                new Person
                {
                    GivenName="John",
                    FamilyName="Craw",
                    Age=20,
                    Address = "20 hampton street"
                },
                 new Person
                {
                    GivenName="Graham",
                    FamilyName="Smith",
                    Age=25,
                    Address = "25 New Way"
                },
            };
        }

        private PersonViewModel GetPersonViewModel()
        {
            return new PersonViewModel
            {
                FirstName= "John",
                LastName= "Craw"
            };
        }
    }
}
