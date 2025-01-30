using MediatR;
using RentACar.Application.Features.Mediator.Results.BrandResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.BrandQueries
{
    public class GetBrandQuery:IRequest<List<GetBrandQueryResult>>
    {
    }
}
