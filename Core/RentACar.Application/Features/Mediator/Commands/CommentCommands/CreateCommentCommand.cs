using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommand:IRequest
    {

        public string Name { get; set; }

        
        public string Email { get; set; }
        public string Desciption { get; set; }

        public int BlogId { get; set; }
    }
}
