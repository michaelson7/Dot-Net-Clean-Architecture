using API_DIR.Handlers;
using API_DIR.Responses;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DIR.Controllers
{
    public class StationsController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IDataService _db;
        public ImageHandlerPro _imageHandler = new();
        public JsonResponse _response = new JsonResponse();

        public StationsController(IDataService db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        //create
        [HttpPost]
        [Route("createStations")]
        public async Task<ActionResult<StationsModel>> createStations([FromForm] StationsModel model)
        {
            try
            {
                //check if file contains image
                if (model.ImageFile != null)
                {
                    var imageName = await _imageHandler.UploadFile(_env, model.ImageFile);
                    model.ImagePath = imageName;
                }
                //create stations
                var output = await _db.StationsCreate(model);
                return _response.getResponse(output, "Error while creating station");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getStationsStatistics")]
        public async Task<ActionResult<StationStatsModel>> StationsGetStatistics(int id)
        {
            try
            {
                var output = await _db.StationsGetStatistics(id);
                return _response.getResponse(output, "station stats not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        [HttpGet]
        [Route("getStations")]
        public async Task<ActionResult<StationsModel>> getStationsById(int id)
        {
            try
            {
                var output = await _db.StationsGet(id);
                return _response.getResponse(output, "station not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllStations")]
        public async Task<ActionResult<IEnumerable<StationsModel>>> getAllStations()
        {
            string baseUrl = string.Format("{0}://{1}",
                       HttpContext.Request.Scheme, HttpContext.Request.Host);
            try
            {
                var output = await _db.StationsGetAll();
                //foreach (var data in output)
                //{
                //    data.ImagePath = $"{baseUrl}/Images/{data.ImagePath}";
                //}
                return _response.getResponse(output, "station not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        [HttpGet]
        [Route("getHistoricalDataStations")]
        public async Task<ActionResult<IEnumerable<HistoricalDataModel>>> getHistoricalDataStations(int stationId)
        {
            try
            {
                var output = await _db.StationsGetHistoricalData(stationId);
                return _response.getResponse(output, "station historical data not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateStations")]
        public async Task<ActionResult<StationsModel>> updateStations([FromBody] StationsModel model)
        {
            try
            {
                await _db.StationsUpdate(model);
                return _response.getResponse("", "station not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //delete
        [HttpGet]
        [Route("deleteStations")]
        public async Task<ActionResult<StationsModel>> deleteUserAsync(int id)
        {
            try
            {
                await _db.StationsDelete(id);
                return _response.getResponse("", "station Cold not be deleted");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //StationsGetGauge
        [HttpPost]
        [Route("StationsGetGauge")]
        public async Task<ActionResult<StationsModel>> StationsGetGauge(int id)
        {
            try
            {
                var output = await _db.StationsGetGauge(id);
                return _response.getResponse(output, "station Gauge Cold not be found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
