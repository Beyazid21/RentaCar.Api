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
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();

            return value.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                SendDate = x.SendDate,
                Subject = x.Subject 
                
            }).ToList();
        }
    }
}
