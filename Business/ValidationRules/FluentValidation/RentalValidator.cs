﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class RentalValidator: AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CarId).GreaterThan(0);
            RuleFor(r => r.CostomerId).NotEmpty();
            RuleFor(r => r.CostomerId).GreaterThan(0);
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.RentDate).When(r => r.ReturnDate.HasValue).WithMessage("Girilen tarihler geçersizdir.");




        }
    }
}