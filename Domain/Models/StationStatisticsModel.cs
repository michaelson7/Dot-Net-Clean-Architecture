using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StationStatisticsModel
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string Coordinates { get; set; }
        public string Location { get; set; }

    }
}
