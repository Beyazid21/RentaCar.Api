using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Results.CarResults
{
    public class GetCarQueryResult
    {
        public int CarId { get; set; }

        public string Name { get; set; }

        public string CoverImageUrle { get; set; }

        public int Km { get; set; } //-Getdiyi məsafə km ilə

        public string Transmisson { get; set; } //-sürətlər qutusu növü

        public byte Seat { get; set; }   //-oturacaq sayi
        public byte Luggage { get; set; }  //baqaş tutumu 

        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }

        //Relations
        public int BrandId { get; set; }

      
    }
}
