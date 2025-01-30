using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.Entities
{
    public  class RentCarProcess
    {
        public int RentCarProcessId { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PickUpLocationId { get; set; }

        public int CustomerId   { get; set; }

        public Customer Customer { get; set; }
        


        public int DropOffLocaiton {  get; set; }

        public string PickUpDescription { get; set; }
        public string DropOffDescription { get; set; }

        public decimal TotalPrice { get; set; } 

        public DateOnly PickUpDate {  get; set; }
        public DateOnly DropOffDate {  get; set; }
        public TimeOnly PickUpOfTime {  get; set; }
        public TimeOnly DropOffTime {  get; set; }

        
    }
}
