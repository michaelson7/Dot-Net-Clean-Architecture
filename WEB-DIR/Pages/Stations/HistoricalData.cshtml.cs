using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEB_DIR.Pages.Stations
{
    public class HistoricalDataModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public void OnGet()
        {
        }
    }
}
