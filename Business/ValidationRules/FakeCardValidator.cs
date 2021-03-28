using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    class FakeCardValidator : AbstractValidator<FakeCard>
    {
        public FakeCardValidator()
        {
            RuleFor(f => f.Number).NotEmpty();
            RuleFor(f => f.Number).MinimumLength(2);


        }
    }
}
