﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.Entities
{
    public class Location
    {
        public int LocationId { get; set; }

        public string Name { get; set; }

        public List<RentCar> RentCars { get; set; }

        public List<Reservation> PickUpReservation { get; set; }
        public List<Reservation> DropOffReservation  { get; set; }
    }
}
