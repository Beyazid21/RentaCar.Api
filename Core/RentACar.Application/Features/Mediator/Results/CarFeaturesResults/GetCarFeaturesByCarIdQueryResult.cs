﻿using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Results.CarFeaturesResults
{
    public class GetCarFeaturesByCarIdQueryResult
    {
        public int CarFeatureId { get; set; }

        //Relations
       

       

        public int FeatureId { get; set; }
        public string FeatureName { get; set; }

       

        public bool Available { get; set; }
    }
}
