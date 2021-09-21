using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DIR.Models
{
    public class ResponseModel
    {
        public string errorMessage { get; set; }
        public bool error { get; set; }
        public dynamic results { get; set; }
    }
}
