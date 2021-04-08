using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class RegisteredCreditCardValidator : AbstractValidator<RegisteredCreditCard>
    {
        public RegisteredCreditCardValidator()
        {


            RuleFor(f => f.UserId).NotEmpty();


            RuleFor(f => f.NameOnTheCard).MinimumLength(1);
            RuleFor(r => r.NameOnTheCard).NotEmpty();

            RuleFor(r => r.Number).NotEmpty();
            RuleFor(f => f.Number).MinimumLength(1);


    
            RuleFor(f => f.Cvv).MinimumLength(3);
            RuleFor(r => r.Cvv).NotEmpty();


            RuleFor(r => r.ExpirationDate).NotEmpty();





        }

    }
}
