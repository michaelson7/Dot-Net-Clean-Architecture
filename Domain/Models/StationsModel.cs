using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StationsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public IFormFile ImageFile { get; set; }
        public StationStatisticsModel StationStatisticsModel { get; set; } = new();
    }
}
