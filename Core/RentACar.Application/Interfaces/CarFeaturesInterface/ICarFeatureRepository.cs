using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.CarFeaturesInterface
{
    public interface ICarFeatureRepository
    {
        Task ChangeToTrue(List<int> ints);
        Task ChangeToFalse(List<int> ints);
        Task CreateCarFeatureByCarId(CarFeature carFeature);
    }
}
