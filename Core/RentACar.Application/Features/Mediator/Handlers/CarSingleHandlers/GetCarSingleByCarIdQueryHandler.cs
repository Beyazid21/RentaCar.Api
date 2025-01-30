using MediatR;
using Microsoft.EntityFrameworkCore;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.CarSingleQueries;
using RentACar.Application.Features.Mediator.Results.CarSingleResults;
using RentACar.Application.Interfaces;


namespace RentACar.Application.Features.Mediator.Handlers.CarSingleHandlers
{
    public class GetCarSingleByCarIdQueryHandler:IRequestHandler<GetCarSingleByCarIdQuery, GetCarSingleByCarIdQueryResult>
    {
        private readonly IRepository<Car> _repository;

        public GetCarSingleByCarIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarSingleByCarIdQueryResult> Handle(GetCarSingleByCarIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(predicate: x => x.CarId == request.CarId, include: query => query.Include(x => x.Brand).Include(x => x.CarDescriptions).Include(x => x.CarFeatures).ThenInclude(x=>x.Feature));
            var features = car.CarFeatures
      .Where(x => x.CarId == request.CarId) // CarId-ə uyğun xüsusiyyətləri seçin
      .ToDictionary(
          x => x.Feature.Name, // Feature Name açar kimi
          x => x.Available // Available dəyəri bool kimi
      );
            return new GetCarSingleByCarIdQueryResult
            {
                CarId = request.CarId,
          
                BrandName = car.Brand.Model,
                Features = features,
                Description = car.CarDescriptions.FirstOrDefault(x => x.CarId == request.CarId)?.Details ?? "Boshdur",
                Fuel = car.Fuel,
                Km = car.Km,
                Luggage = car.Luggage,
                Name = car.Name,
                Seat = car.Seat,
                Transmisson = car.Transmisson,
                BigImageUrl = car.BigImageUrl,
               
            };
        }
    }
}
