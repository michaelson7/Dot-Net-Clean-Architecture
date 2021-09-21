using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_DIR.Services;

namespace WEB_DIR.Pages.Stations
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _db;
        private readonly IWebHostEnvironment _env;

        public List<StationsModel> StationsModelList = new();
        public StationsModel StationsModel = new();
        public StationStatisticsModel stationStatisticsModel = new();
        public ImageHandler _imageHandler = new();
        public bool hasData = false;

        [BindProperty(SupportsGet = true)]
        public bool hasError { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public bool hasResponse { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public string errorMessage { get; set; }
        [BindProperty(SupportsGet = true)]
        public DbOperations dbOperation { get; set; }

        public IndexModel(IDataService db, IWebHostEnvironment env)
        {
            _env = env;
            _db = db;
        }

        public async Task OnGetAsync()
        {
            //get Stations
            StationsModelList = await _db.StationsGetAll();
            if (StationsModelList.Count() > 0)
            {
                hasData = true;
            }
            else
            {
                hasData = false;
            }
        }

        public async Task<IActionResult> OnPost(StationsModel model, StationStatisticsModel statisticsModel, DbOperations dbOperations, int deleteId)
        {
            //if deleting set operation to Delete
            dbOperations = deleteId > 0 ? DbOperations.Delete : dbOperations;

            //update image if present
            var imageName = await _imageHandler.UploadFile(_env, model.ImageFile);
            if (imageName != null)
            {
                model.ImagePath = imageName;
            }

            try
            {
                switch (dbOperations)
                {
                    case DbOperations.Create:
                        var id = await _db.StationsCreate(model);
                        await createStationStatsAsync(id, statisticsModel);
                        break;
                    case DbOperations.Update:
                        await _db.StationsUpdate(model);
                        await updateStationStats(statisticsModel, model.Id);
                        break;
                    case DbOperations.Delete:
                        await _db.StationsDelete(deleteId);
                        break;
                }
                return RedirectToPage("/Stations/Index", new
                {
                    dbOperation = deleteId > 0 ? DbOperations.Delete : dbOperations,
                    hasResponse = true
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToPage("/Stations/Index", new
                {
                    error = true,
                    errorMessage = e.Message,
                    hasResponse = true
                });
            }
        }

        private async Task createStationStatsAsync(int id, StationStatisticsModel statisticsModel)
        {
            statisticsModel.StationId = id;
            await _db.StationStatisticsCreate(statisticsModel);
        }

        public async Task updateStationStats(StationStatisticsModel statisticsModel, int id)
        {
            //check if has stats
            var statsData = await _db.StationStatisticsGet(id);

            if (statsData == null)
            {
                //create stat
                await createStationStatsAsync(id, statisticsModel);
            }
            else
            {
                //update stat
                statisticsModel.StationId = id;
                await _db.StationStatisticsUpdate(statisticsModel);
            }
        }
    }
}
