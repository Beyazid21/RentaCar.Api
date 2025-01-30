using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.TestimonialQueries;
using RentACar.Application.Features.Mediator.Results.TestimonialResults;
using RentACar.Application.Interfaces;

namespace RentACar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;
        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();

            return value.Select(x => new GetTestimonialQueryResult
            {
               ImageUrl = x.ImageUrl,
               Name = x.Name,
               Comment = x.Comment,
               Title = x.Title,
               TestimonialId = x.TestimonialId
            }).ToList();
        }
    }
}
