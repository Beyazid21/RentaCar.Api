using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Commands.FeatureCommands
{
    public class RemoveTagCloudCommand:IRequest
    {
        public RemoveTagCloudCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
