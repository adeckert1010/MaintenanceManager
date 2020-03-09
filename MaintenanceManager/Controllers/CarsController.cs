using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceManager.Controllers
{
    public class CarsController : Controller
    {

        public IActionResult SeeCar(int id)
        {
             
            return View();
        }

        public IActionResult AddCar()
        {
            return View();
        }
    }
}