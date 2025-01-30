using MediatR;
using RentACar.Application.Features.Mediator.Results.StatisticsResults;


namespace RentACar.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetBlogTitleByMaxCommentQuery:IRequest<GetBlogTitleByMaxCommentQueryResult>
    {
    }
}
