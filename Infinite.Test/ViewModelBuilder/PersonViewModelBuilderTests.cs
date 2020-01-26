using FluentAssertions;
using Infinite.Contract;
using Infinite.ViewModel;
using Infinite.ViewModelBuilder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Infinite.Test.ViewModelBuilder
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class PersonViewModelBuilderTests
    {
        private PersonViewModelBuilder _personViewModelBuilder;

        [SetUp]
        public void SetUp()
        {
            _personViewModelBuilder = new PersonViewModelBuilder();
        }

        [Test]
        public void Build_Returns_Expected_PersonViewModel_Result()
        {
            // Arrange
            var expectedResult = GetPersonViewModel();

            // Act
            var actualResult = _personViewModelBuilder.Build(GetPerson());

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Build_Returns_InstanceOf_PersonViewModel()
        {

            // Act
            var actualResult = _personViewModelBuilder.Build(GetPerson());

            // Assert
            Assert.IsInstanceOf<PersonViewModel>(actualResult);
        }

        private Person GetPerson()
        {
            return new Person
            {
                GivenName = "John",
                FamilyName = "Craw",
                Age = 20,
                Address = "20 hampton street"
            };
        }

        private PersonViewModel GetPersonViewModel()
        {
            return new PersonViewModel
            {
                FirstName = "John",
                LastName = "Craw"
            };
        }
    }
}
