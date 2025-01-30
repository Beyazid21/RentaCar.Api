using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Queries.StatisticsQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarCount()
        {
            var value = await _mediator.Send(new GetCarCountQuery());

            return Ok(value);
        }
        [HttpGet]
        public async Task<IActionResult> GetLocationCount()
        {
            var value = await _mediator.Send(new GetLocationCountQuery());

            return Ok(value);
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthorCount()
        {
            var value = await _mediator.Send(new GetAuthorCountQuery());

            return Ok(value);
        }
        [HttpGet]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _mediator.Send(new GetBrandCountQuery());

            return Ok(value);
        }
        [HttpGet]

        public async Task<IActionResult> GetBlogCount()
        {
            var value = await _mediator.Send(new GetBlogCountQuery());

            return Ok(value);
        }

        [HttpGet]

        public async Task<IActionResult> GetAvgRentPriceCarForDaily()
        {
            var value = await _mediator.Send(new GetAvgRentPriceCarForDailyQuery());

            return Ok(value);
        }
        [HttpGet]
        public async Task<IActionResult> GetAvgRentPriceCarForWeekly()
        {
            var value = await _mediator.Send(new GetAvgRentPriceCarForWeeklyQuery());

            return Ok(value);
        }
        [HttpGet]
        public async Task<IActionResult> GetAvgRentPriceCarForMonthly()
        {
            var value = await _mediator.Send(new GetAvgRentPriceCarForMonthlyQuery());

            return Ok(value);
        }
        [HttpGet]
        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {
            var value = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());

            return Ok(value);
        }


        [HttpGet]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var value = await _mediator.Send(new GetBrandNameByMaxCarQuery());

            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogTitleByMaxComment()
        {
            var value = await _mediator.Send(new GetBlogTitleByMaxCommentQuery());

            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarCountByKmSmallerThan1000()
        {
            var value = await _mediator.Send(new GetCarCountByKmSmallerThan1000Query());

            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarCountByFuelGasolineorDiesel()
        {
            var value = await _mediator.Send(new GetCarCountByFuelGasolineorDieselQuery());

            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var value = await _mediator.Send(new GetCarCountByFuelElectricQuery());

            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());

            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());

            return Ok(value);
        }
    }
}
