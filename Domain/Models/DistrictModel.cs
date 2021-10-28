using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class DistrictModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Prefix { get; set; }
        public int ProvinceId { get; set; }
        public ProvinceModel ProvinceData { get; set; }

    }
}
