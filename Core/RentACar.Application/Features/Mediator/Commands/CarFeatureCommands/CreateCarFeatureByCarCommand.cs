using MediatR;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureByCarCommand:IRequest
    {
       

        //Relations
        public int CarId { get; set; }

      

        public int FeatureId { get; set; }

     
        public bool Available { get; set; }
    }
}
