using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dto.CarFeatureDto
{
    public class ResultCarFeatureDto
    {
        public int CarFeatureId { get; set; }

        //Relations
      



        public int FeatureId { get; set; }
        public string FeatureName { get; set; }



        public bool Available { get; set; }
    }
}
