using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string ImagePath { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public IFormFile ImageFile { get; set; }
        public UsersModel UsersModel { get; set; } = new();
    }
}
