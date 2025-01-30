using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount ();
        int GetAuthorCount ();

        int GetBlogCount ();
        int GetBrandCount ();
        decimal GetAvgRentPriceCarForDaily ();
        decimal GetAvgRentPriceCarForWeekly ();
        decimal GetAvgRentPriceCarForMonthly ();
        int GetCarCountByTransmissionIsAuto();
        string GetBrandNameByMaxCar();
        string GetBlogTitleByMaxComment();
        int GetCarCountByKmSmallerThan1000();
        int GetCarCountByFuelGasolineorDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceDailyMax();
        string GetCarBrandAndModelByRentPriceDailyMin();
    }
}
