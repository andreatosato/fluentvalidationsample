using FluentValidation.TestHelper;
using System;
using Xunit;

namespace Sample.Validators.Tests
{
    public class PersonValidatorTest
    {
        private PersonValidator _personValidatior;
        public PersonValidatorTest()
        {
            _personValidatior = new PersonValidator();
        }

        [Fact]
        public void Test1()
        {
            var errors = _personValidatior.ShouldHaveValidationErrorFor(p => p.Name, "dd");
            Assert.NotEmpty(errors);
        }


    }
}
