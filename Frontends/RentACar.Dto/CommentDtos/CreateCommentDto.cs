using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dto.CommentDtos
{
    public class CreateCommentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }


       

        public string Desciption { get; set; }

        public int BlogId { get; set; }
    }
}
