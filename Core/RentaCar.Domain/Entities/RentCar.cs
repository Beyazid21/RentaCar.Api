using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.Entities
{
    public class RentCar
    {
        public int RentCarId { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CarId { get; set; }

        public Car Car { get; set; }
        public bool Available { get; set; }

    }
}
