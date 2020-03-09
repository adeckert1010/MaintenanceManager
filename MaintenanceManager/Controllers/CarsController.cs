using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaintenanceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceManager.Controllers
{
    public class CarsController : Controller
    {
        private IList<Car> cars = Cars.LocalCars;
        public IActionResult SeeCar(int id)
        {
            foreach(var car in cars)
            {
                if(car.LocalID == id)
                {
                    return View(car);
                }
            }
            return View();
        }

        public IActionResult AddCar()
        {
            return View();
        }
    }
}