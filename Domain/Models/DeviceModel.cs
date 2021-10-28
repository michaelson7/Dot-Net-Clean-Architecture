using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DeviceModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DeviceId { get; set; }
        public int DeviceStatusId { get; set; }
        public DateTime LastSync { get; set; }
        public DateTime DateCreated { get; set; }
        public int DeviceBearerId { get; set; }
        public int SateliteId { get; set; }

        public UsersModel DeviceBearerData { get; set; }    
        public SateliteModel SateliteData { get; set; }
        public DeviceStatusModel DeviceStatusData { get; set; } 
    }
}
