﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentCountByBlogIdQueryResult
    {
        public int Count { get; set; }
    }
}
