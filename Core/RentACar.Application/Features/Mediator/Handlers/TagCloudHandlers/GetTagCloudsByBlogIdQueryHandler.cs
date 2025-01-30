using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.TagCloudQueries;
using RentACar.Application.Features.Mediator.Results.TagCloudResults;
using RentACar.Application.Interfaces.TagCloudInterfaces;


namespace RentACar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudsByBlogIdQueryHandler : IRequestHandler<GetTagCloudsByBlogIdQuery, List<GetTagCloudsByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository ;

        public GetTagCloudsByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudsByBlogIdQueryResult>> Handle(GetTagCloudsByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetTagCloudsByBlogId(request.Id);

            return values.Select(x=>new GetTagCloudsByBlogIdQueryResult
            {

                 BlogId = x.BlogId, 
                  TagCloudId = x.TagCloudId,    
                  Title=x.Title,

            }).ToList();
        }
    }
}
