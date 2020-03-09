using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceManager.Models
{
    public class Cars
    {
        public static IList<Car> LocalCars { get; set; }


        public IList<Car> removeFromLocalList(int ID)
        {
            foreach(Car car in LocalCars)
            {
                if(car.LocalID == ID)
                {
                    LocalCars.Remove(car);
                }
            }
            return LocalCars;
        }
    }
}
