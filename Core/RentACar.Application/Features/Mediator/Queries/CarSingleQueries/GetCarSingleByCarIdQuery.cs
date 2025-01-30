using MediatR;
using RentACar.Application.Features.Mediator.Results.CarSingleResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.CarSingleQueries
{
    public class GetCarSingleByCarIdQuery:IRequest<GetCarSingleByCarIdQueryResult>
    {
        public GetCarSingleByCarIdQuery(int carId)
        {
            CarId = carId;
        }

        public int CarId { get; set; }
    }
}
