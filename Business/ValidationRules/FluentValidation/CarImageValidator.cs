using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CarImageValidator: AbstractValidator<CarImage>
    {

        public CarImageValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.CarId).GreaterThan(0);
            RuleFor(c => c.Date).NotEmpty();
            RuleFor(c => c.ImagePath).NotEmpty();
            RuleFor(c => c.ImagePath).MinimumLength(2);
          //  RuleFor(c => c.Id).GreaterThan(0);


     }
    }
}
