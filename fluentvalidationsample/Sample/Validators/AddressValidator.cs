using FluentValidation;
using Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Validators
{
    public class AddressValidator : AbstractValidator<AddressViewModel>
    {
        public AddressValidator()
        {

        }
    }
}
