using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEB_DIR.Pages.GaugeStations
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _db;

        public List<GaugeStationModel> GaugeStationModelList = new();
        public GaugeStationModel GaugeStationModel = new();
        public List<StationsModel> stationsModels = new();
        public bool hasData = false;

        [BindProperty(SupportsGet = true)]
        public bool hasError { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public bool hasResponse { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public string errorMessage { get; set; }
        [BindProperty(SupportsGet = true)]
        public DbOperations dbOperation { get; set; }

        public IndexModel(IDataService db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            //get GaugeStation
            GaugeStationModelList = await _db.GaugeStationGetAll();
            stationsModels = await _db.StationsGetAll();
            if (GaugeStationModelList.Count() > 0)
            {
                hasData = true;
            }
            else
            {
                hasData = false;
            }
        }

        public async Task<IActionResult> OnPost(GaugeStationModel model, DbOperations dbOperations, int deleteId)
        {
            //if deleting set operation to Delete
            dbOperations = deleteId > 0 ? DbOperations.Delete : dbOperations;

            try
            {
                switch (dbOperations)
                {
                    case DbOperations.Create:
                        var id = await _db.GaugeStationCreate(model);
                        break;
                    case DbOperations.Update:
                        await _db.GaugeStationUpdate(model);
                        break;
                    case DbOperations.Delete:
                        await _db.GaugeStationDelete(deleteId);
                        break;
                }
                return RedirectToPage("/GaugeStations/Index", new
                {
                    dbOperation = deleteId > 0 ? DbOperations.Delete : dbOperations,
                    hasResponse = true
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToPage("/GaugeStations/Index", new
                {
                    error = true,
                    errorMessage = e.Message,
                    hasResponse = true
                });
            }
        }
    }
}
