using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Validators
{
    public class PersonValidator : AbstractValidator<PersonViewModel>
    {
        public const string ValidaMail = "ValidaMail";
        public const string ValidaNumeriTelefono = "ValidaNumeriTelefono";

        public PersonValidator()
        {
            // Common rules
            //RuleFor(x => x.Birthday).ExclusiveBetween(DateTime.Now.AddYears(150), DateTime.Now);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Address).Cascade(CascadeMode.Continue);

            // Set Rule
            RuleSet(ValidaMail, () => 
            {
                RuleFor(x => x.EmailAddress).EmailAddress().NotEmpty();
                RuleFor(x => x.PecMail).EmailAddress();
            });

            // Set Rule
            RuleSet(ValidaNumeriTelefono, () =>
            {
                RuleFor(x => x.PhoneNumber).NotEmpty().SetValidator(new InternationPhoneRule());
                RuleFor(x => x.PecMail).NotEmpty().SetValidator(new InternationPhoneRule());
            });
        }


        
    }

    public class InternationPhoneRule : PropertyValidator
    {
        public InternationPhoneRule()
            : base("{PropertyName} must contain phone number in format: +IINNN-PPPPPPPP")
        {
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            bool isValid = false;
            string phoneNumber = context.PropertyValue as string;
            if (phoneNumber.StartsWith("+"))
            {
                var splitPhone = phoneNumber.Split("-");
                if (splitPhone?.Count() != 2)
                {
                    context.MessageFormatter.BuildMessage("{PropertyName} not contains national prefix with separator -");
                }
                else
                    isValid = true;
            }
            else
                context.MessageFormatter.BuildMessage("{PropertyName} not contains international prefix with separator +");

            return isValid;
        }
    }
}
