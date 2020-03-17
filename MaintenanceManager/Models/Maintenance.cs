using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceManager.Models
{
    public class Maintenance
    {

        public class Rootobject
        {
            public Message message { get; set; }
            public Datum[] data { get; set; }
        }

        public class Message
        {
            public int code { get; set; }
            public string message { get; set; }
            public string credentials { get; set; }
            public string version { get; set; }
            public string endpoint { get; set; }
            public int counter { get; set; }
        }

        public class Datum
        {
            public string desc { get; set; }
            public int due_mileage { get; set; }
            public bool is_oem { get; set; }
            public Repair repair { get; set; }
            public Part[] parts { get; set; }
        }

        public class Repair
        {
            public int repair_difficulty { get; set; }
            public float repair_hours { get; set; }
            public float labor_rate_per_hour { get; set; }
            public float part_cost { get; set; }
            public float labor_cost { get; set; }
            public float misc_cost { get; set; }
            public float total_cost { get; set; }
        }

        public class Part
        {
            public string desc { get; set; }
            public string manufacturer { get; set; }
            public float price { get; set; }
            public int qty { get; set; }
        }

    }
}
