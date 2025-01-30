using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Queries.TagCloudQueries;
using RentACar.Application.Features.Mediator.Results.TagCloudResults;

namespace RentACar.Application.TagClouds.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(predicate: x => x.TagCloudId == request.Id);

            return new GetTagCloudByIdQueryResult
            {
                TagCloudId = value.TagCloudId,
                Title = value.Title,

                BlogId=value.BlogId,

            };
        }
    }
}
