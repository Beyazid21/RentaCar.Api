using RentACar.Application.Features.CQRS.Queries.ContactQueries;
using RentACar.Application.Features.CQRS.Results.ContactResults;
using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(predicate: x => x.ContactId == query.Id);

            return new GetContactByIdQueryResult
            {
                ContactId = value.ContactId,
                Name = value.Name,
                Subject = value.Subject,
                SendDate = value.SendDate,
                Message = value.Message,
                Email = value.Email 
            };
        }
    }
}
