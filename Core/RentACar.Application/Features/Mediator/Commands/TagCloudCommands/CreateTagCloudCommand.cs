using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Commands.FeatureCommands
{
    public class CreateTagCloudCommand:IRequest
    {
        

        public string Title { get; set; }

        public int BloqId { get; set; }
    }
}
