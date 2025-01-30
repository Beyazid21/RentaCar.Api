using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.Entities
{
  public  class Comment
    {
        public int CommentId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }



        public DateTime CreatedDate { get; set; }

        public string Desciption { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
