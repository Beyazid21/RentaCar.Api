using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Commands.BrandCommand
{
    public class CreateBrandCommand:IRequest
    {
        
        public string Model { get; set; }
    }
}
