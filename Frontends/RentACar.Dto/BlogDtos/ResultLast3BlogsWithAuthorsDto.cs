﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dto.BlogDtos
{
    public class ResultLast3BlogsWithAuthorsDto
    {
        public int BlogId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }


        public string CoverImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }
    }
}
