﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dto.BlogDtos
{
    public class CreateBlogDto
    {
      

        public string Title { get; set; }
        public string Description { get; set; }

        public int AuthorId { get; set; }

  

        public string CoverImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }
    }
}
