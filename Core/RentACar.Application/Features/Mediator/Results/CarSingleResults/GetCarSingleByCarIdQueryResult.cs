using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Results.CarSingleResults
{
    public class GetCarSingleByCarIdQueryResult
    {
        public int CarId { get; set; }

        public string Name { get; set; }

        public string BrandName { get; set; }

        public string Description { get; set; }

        public Dictionary<string,bool> Features { get; set; }= new Dictionary<string,bool>();

        public int Km { get; set; } //-Getdiyi məsafə km ilə

        public string Transmisson { get; set; } //-sürətlər qutusu növü

        public byte Seat { get; set; }   //-oturacaq sayi
        public byte Luggage { get; set; }  //baqaş tutumu 

        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }

        //Relations
      

       
    }
}
