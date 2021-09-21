using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_DIR.Services;

namespace WEB_DIR.Pages.GaugeRecords
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _db;
        private readonly IWebHostEnvironment _env;

        public ImageHandler _imageHandler = new();
        public List<GaugeRecordsModel> GaugeRecordsModelList = new();
        public GaugeRecordsModel GaugeRecordsModel = new();
        public List<GaugeStationModel> GaugeStationModel { get; set; } = new();
        public bool hasData = false;


        [BindProperty(SupportsGet = true)]
        public int gaugeRecordId { get; set; }
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
            _db = db;
            _env = env;
        }

        public async Task OnGetAsync()
        {
            //get GaugeRecords
            if (gaugeRecordId > 0)
            {
                //get records only for specific gage station 
                GaugeRecordsModelList = await _db.GaugeRecordsGet(gaugeRecordId);
            }
            else
            {
                //get all gage Records
                GaugeRecordsModelList = await _db.GaugeRecordsGetAll();
            }
            GaugeStationModel = await _db.GaugeStationGetAll();
            if (GaugeRecordsModelList.Count() > 0)
            {
                hasData = true;
            }
            else
            {
                hasData = false;
            }
        }

        public async Task<IActionResult> OnPost(GaugeRecordsModel model, DbOperations dbOperations, int deleteId, bool Handleapproval, int ApproveId)
        {
            //if deleting set operation to Delete
            dbOperations = deleteId > 0 ? DbOperations.Delete : dbOperations;

            //approval handler
            dbOperations = Handleapproval == true ? DbOperations.Approve : dbOperations;

            //update image if present
            var imageName = await _imageHandler.UploadFile(_env, model.ImageFile);
            if (imageName != null)
            {
                model.Imagepath = imageName;
            }

            //replace with real values
            model.UploaderId = 1;
            model.ApproverId = 1;

            try
            {
                switch (dbOperations)
                {
                    case DbOperations.Approve:
                        model.Id = ApproveId;
                        await _db.GaugeRecordsApprove(model);
                        break;
                    case DbOperations.Create:
                        var id = await _db.GaugeRecordsCreate(model);
                        break;
                    case DbOperations.Update:
                        await _db.GaugeRecordsUpdate(model);
                        break;
                    case DbOperations.Delete:
                        await _db.GaugeRecordsDelete(deleteId);
                        break;
                }
                return RedirectToPage("/GaugeRecords/Index", new
                {
                    dbOperation = deleteId > 0 ? DbOperations.Delete : dbOperations,
                    hasResponse = true
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToPage("/GaugeRecords/Index", new
                {
                    error = true,
                    errorMessage = e.Message,
                    hasResponse = true
                });
            }
        }


    }
}
