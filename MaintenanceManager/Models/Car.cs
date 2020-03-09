using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceManager.Models
{
    public class Car
    {
        public int LocalID { get; set; }
        public int BodyID { get; set; }
        public string DefaultSearchText { get; } = "Keyword Search";
        public int DoorsID { get; set; }
        public int DriveID { get; set; }
        public int EnginePositionID { get; set; }
        public int EngineTypeID { get; set; }
        public int FuelTypeID { get; set; }
        public int MinCylindersID { get; set; }
        public int MinMilesPerGalHwy { get; set; }
        public int MinPowerID { get; set; }
        public int MinTopSpeedID { get; set; }
        public int MinTorqueID { get; set; }
        public int MinWeightID { get; set; }
        public int MinYearID { get; set; }
        public int MaxCylindersID { get; set; }
        public int MaxHwyMPG { get; set; }
        public int MaxPowerID { get; set; }
        public int MaxTopSpeedID { get; set; }
        public int MaxWeightID { get; set; }
        public int MaxYearID { get; set; }
        //,search_controls_id:            "cq-search-controls"
        //,search_input_id:               "cq-search-input"
        //,search_results_id:             "cq-search-results"
        //,search_result_id:              "cq-search-result"
        //,seats_id:                      "cq-seats"
        //,sold_in_us_id:                 "cq-sold-in-us"

    }
}
