
using Infinite.Contract;
using Infinite.Interface;
using Infinite.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Test.Services
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class PersonServiceTests
    {
        private PersonService _personService;
        private Mock<IWebApiClient> _webApiClientMock;
        private Mock<IConfiguration> _configurationMock;
        private Mock<IConfigurationSection> _configurationSectionMock;

        [SetUp]
        public void Setup()
        {
            _webApiClientMock = new Mock<IWebApiClient>();
            _webApiClientMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(GetResponse());
            _configurationMock = new Mock<IConfiguration>();
            _configurationSectionMock = new Mock<IConfigurationSection>();
            _configurationSectionMock.SetupGet(m => m[It.Is<string>(s => s == "http")]).Returns("http://test/");
            _configurationMock.Setup(a => a.GetSection("PersonApi")).Returns(_configurationSectionMock.Object);
            _personService = new PersonService(_webApiClientMock.Object, _configurationMock.Object);
        }

        [Test]
        public async Task GetPerson_Returns_Person_List()
        {

            //Act
            var address = await _personService.GetPerson();
            
            //Assert
            Assert.IsInstanceOf<IEnumerable<Person>>(address);
        }

        [Test]
        public async Task GetPerson_Calls_ReadFile_Method()
        {
            // Act
            await _personService.GetPerson();

            // Assert
            _webApiClientMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task GetPerson_Calls_GetSection_Method()
        {
            // Act
            await _personService.GetPerson();

            // Assert
            _configurationMock.Verify(x => x.GetSection(It.IsAny<string>()), Times.Once);
        }
        private HttpResponseMessage GetResponse()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"[{""givenName"":""John"",""familyName"":""Craw"",""age"":20,""address"":""20 hampton street""},{""givenName"":""Graham"",""familyName"":""Smith"",""age"":25,""address"":""25 New Way""}]", Encoding.UTF8, "application/json")
            };
        }
    }
}
