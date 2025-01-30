using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dto.StatisticsDtos
{
    public class StatisticsDto
    {
        public int carCount {  get; set; }
        public int locationCount {  get; set; }
        public int authorCount {  get; set; }
        public int brandCount {  get; set; }
        public int blogCount {  get; set; }
        public decimal price {  get; set; }
       public string brandName { get; set; }
       public string name { get; set; }
    }
}
