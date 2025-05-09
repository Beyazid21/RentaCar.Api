﻿using MediatR;
using RentACar.Application.Features.Mediator.Results.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceByIdQuery:IRequest<GetServiceByIdQueryResult>
    {
        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
