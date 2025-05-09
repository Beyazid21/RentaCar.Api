﻿using RentaCar.Domain.Entities;
using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            var value=await _repository.GetByIdAsync(x => x.AboutId == command.AboutId);

            value.Title = command.Title;
            value.Description = command.Description;
            value.ImageUrl = command.ImageUrl;
            

            await _repository.UpdateAsync(value);
        }
    }
}
