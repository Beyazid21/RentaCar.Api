using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dto.CarPricingDtos
{
	public class ResultCarPricingWithTimePeriod
	{
		public string Model { get; set; }

		public string CoverImageUrl { get; set; }
		public string BrandName { get; set; }
		public decimal AmountDaily { get; set; }
		public decimal AmountWeekly { get; set; }
		public decimal AmountMonthly { get; set; }



	}
}
