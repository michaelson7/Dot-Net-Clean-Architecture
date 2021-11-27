using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_DIR.Services;

namespace WEB_DIR.Pages
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

        public int stationsCount;
        public int gaugeReaderCount;
        public int gaugeRecordCount;
        public int newsCount;


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
            //get stats
            var stationData = await _db.StationsGetAll();
            var recordData = await _db.GaugeRecordsGetAll();
            var readerData = await _db.GaugeStationGetAll();
            var newsData = await _db.NewsGetAll();

            stationsCount = stationData.Count();
            gaugeRecordCount = recordData.Count();
            gaugeReaderCount = readerData.Count();
            newsCount = newsData.Count();

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
    }
}
