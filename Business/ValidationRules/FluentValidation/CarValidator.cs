using Entities.Concrete;
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
            RuleFor(p => p.CarName).NotEmpty(); // RuleFor: kural, nesne ile alakalı.
            RuleFor(p => p.CarName).MinimumLength(2); // ctrl+k ve ctrl+d ile kodları düzeltebiliriz.
            RuleFor(p => p.DailyPrice).NotEmpty();// boş olmamalı.
            RuleFor(p => p.DailyPrice).GreaterThan(0); // 0 dan büyük olmalı.
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.ModelYear).NotEmpty();
            //RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.Id == 1); Rental de yazılacak
            //Id si 1 olan ürünler için min 10 olmalı.
            //RuleFor(p => p.CarName).Must(StartWithA).WithMessage("Araçlar A harfi ile başlamalı");
        }       //WithMessage = hata mesajı.
        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");   arg= car demek  "A" ile başlarsa true döner.
        //}

    }
}
