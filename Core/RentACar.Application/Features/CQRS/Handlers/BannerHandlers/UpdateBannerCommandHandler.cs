﻿using RentaCar.Domain.Entities;
using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(x => x.BannerId == command.BannerId);
            value.Description=command.Description;
            value.Title=command.Title;
            value.VideoUrl=command.VideoUrl;
            value.VieoDescription=command.VieoDescription;
            await _repository.UpdateAsync(value);
        }

    }
}
