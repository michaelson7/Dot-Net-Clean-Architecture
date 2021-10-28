using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int AccountStatusId { get; set; }
        public DateTime Timestamp { get; set; }

        public AccountStatusModel AccountStatusData { get; set; }
        public RolesModel RolesData { get; set; } = new();
    }
}
