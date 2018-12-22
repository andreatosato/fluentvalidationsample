using FluentValidation.TestHelper;
using System;
using System.Linq;
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
        public void ValidateName()
        {
            var errors = _personValidatior.ShouldHaveValidationErrorFor(p => p.Name, null as string);
            Assert.NotEmpty(errors);
            string errorCode = errors.ToList().First().ErrorCode;
            Assert.Equal("NotEmptyValidator", errorCode);
        }

        [Fact]
        public void ValidateDate()
        {
            var errors = _personValidatior.ShouldHaveValidationErrorFor(p => p.Birthday, DateTime.Now.AddYears(-160));
            Assert.NotEmpty(errors);
            string errorCode = errors.ToList().First().ErrorCode;
            Assert.Equal("ExclusiveBetweenValidator", errorCode);
        }

        [Fact]
        public void ValidateInternationaPhone()
        {
            _personValidatior.ShouldNotHaveValidationErrorFor(p => p.PhoneNumber, "+39 045-989898", PersonValidator.ValidaNumeriTelefono);
            var errors = _personValidatior.ShouldHaveValidationErrorFor(p => p.PhoneNumber, "+39 045989898", PersonValidator.ValidaNumeriTelefono);
            Assert.NotEmpty(errors);
            string errorCode = errors.ToList().First().ErrorCode;
            Assert.Equal("InternationPhoneRule", errorCode);
        }
    }
}
