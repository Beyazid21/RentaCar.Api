using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.CQRS.Commands.ContactCommands;
using RentACar.Application.Features.CQRS.Handlers.ContactHandlers;
using RentACar.Application.Features.CQRS.Queries.ContactQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, GetContactQueryHandler getContactQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            return Ok(await _getContactQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            return Ok(await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);

            return Ok("Yeni kontakt elave olundu");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);

            return Ok("kontakt yenilendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));

            return Ok("kontakt silindi");
        }
    }
}
