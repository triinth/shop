﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Domain.Spaceship
{
    public class Spaceship
    {
        [Key]

        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Crew { get; set; }
        public int Passengers { get; set; }
        public int CargoWeight { get; set; }
        public int FullTripsCount { get; set; }
        public int MaintenanceCount { get; set; }
        public DateTime LastMaintenance { get; set; }
        public int EnginePower { get; set; }


        public DateTime MaidenLaunch { get; set; }
        public DateTime BuiltDate { get; set; }

        //only in database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
