using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class HistoricalDataModel
    {
        public string Year { get; set; }
        public List<StationStatsModel> StationStatsModel { get; set; } = new();
    }

    public class StationStatsModel
    {
        public decimal Year { get; set; }
        public int Month { get; set; }
        public decimal WaterLevel { get; set; }
        public decimal RiverFlow { get; set; }
        public decimal Temperature { get; set; }
    }
}
