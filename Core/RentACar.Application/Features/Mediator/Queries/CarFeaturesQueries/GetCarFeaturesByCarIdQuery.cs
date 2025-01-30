using MediatR;
using RentACar.Application.Features.Mediator.Results.CarFeaturesResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.CarFeaturesQueries
{
    public class GetCarFeaturesByCarIdQuery:IRequest<List<GetCarFeaturesByCarIdQueryResult>>
    {
        public GetCarFeaturesByCarIdQuery(int carId)
        {
            CarId = carId;
        }

        public int CarId { get; set; }  
    }
}
