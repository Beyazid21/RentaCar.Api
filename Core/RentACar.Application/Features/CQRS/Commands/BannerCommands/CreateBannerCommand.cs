﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Commands.BannerCommands
{
    public class CreateBannerCommand
    {
     

        public string Title { get; set; }

        public string Description { get; set; }

        public string VieoDescription { get; set; }

        public string VideoUrl { get; set; }
    }
}
