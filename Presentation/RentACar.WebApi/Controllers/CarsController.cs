using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACar.Application.Features.CQRS.Handlers.CarHandlers;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Features.CQRS.Results.CarResults;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;


        public CarsController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            return Ok(await _getCarQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            return Ok(await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);

            return Ok("Yeni mashin elave olundu");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);

            return Ok("mashin yenilendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));

            return Ok("Mashin silindi");
        }

        [HttpGet]
        public async Task<IActionResult> CarListWithBrand()
        {
            return Ok(await _getCarWithBrandQueryHandler.Handle());
        }

    }
}
