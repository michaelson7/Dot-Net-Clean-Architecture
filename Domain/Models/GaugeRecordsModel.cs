using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GaugeRecordsModel
    {
        public int Id { get; set; }
        public int UploaderId { get; set; }
        public string Imagepath { get; set; }
        public string GPSLocation { get; set; }
        public float Waterlevel { get; set; }
        public float Temperature { get; set; }
        public float RiverFlow { get; set; }
        public int GaugeId { get; set; }
        public bool Approval { get; set; }
        public int ApproverId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public UsersModel UploaderModel { get; set; } = new();
        public UsersModel ApproverModel { get; set; } = new();
        public GaugeStationModel GaugeStationModel { get; set; } = new();
        public IFormFile ImageFile { get; set; }
    }
}
