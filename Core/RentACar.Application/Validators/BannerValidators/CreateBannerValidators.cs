using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators.BannerValidators
{
    public class CreateBannerValidators:AbstractValidator<CreateBannerCommand>
    {
        public CreateBannerValidators()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Xaiş olunur BURANI boş qoymayın");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Xaiş olunur BURANI boş qoymayın"); 
            RuleFor(x=>x.VideoUrl).NotEmpty().WithMessage("Xaiş olunur BURANI boş qoymayın"); 
            

        }
    }
}
