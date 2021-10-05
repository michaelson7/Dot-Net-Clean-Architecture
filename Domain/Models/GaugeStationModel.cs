﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GaugeStationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int StationId { get; set; }
        public StationsModel StationsModel { get; set; } = new();
    }
}