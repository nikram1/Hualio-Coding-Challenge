using FluentValidation;
using HualioCodingChallenge.Core.Domain.Models;
using HualioCodingChallenge.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HualioCodingChallenge.Core.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductModel>
    {
        public ProductValidator()
        {
            RuleFor(m => m.Name).NotEmpty().NotNull();
            RuleFor(m => m.Price).NotEmpty().NotNull();
        }
    }
}
