using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.Entities
{
    public class Pricing
    {
        public int PricingId { get; set; }

        public string Name { get; set; }

        //Relations

        public List<CarPricing> CarPricings { get; set; }
    }
}
