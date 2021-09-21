using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StaffModel
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public int UserId { get; set; }
        public int StationId { get; set; }
        public UsersModel UsersModel { get; set; } = new();
        public StationsModel StationsModel { get; set; } = new();
    }
}
