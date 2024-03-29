﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {

            RuleFor(c => c.ModelYear).NotEmpty(); //2000 den büyük model olmalı
            RuleFor(c => c.ModelYear).GreaterThan(2000);
            RuleFor(c => c.Description).NotEmpty(); 
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(10);
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.FindeksScore).GreaterThanOrEqualTo(0);
            RuleFor(c => c.FindeksScore).LessThanOrEqualTo(1900);


            //  RuleFor(c => c.Description).Must(StartWithA).WithMessage("Açıklama A harfi ile başlamalıdır.");
        }



    }
}
