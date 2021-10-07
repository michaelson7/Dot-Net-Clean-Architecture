using API_DIR.Responses;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DIR.Controllers
{
    public class StationsController : Controller
    {
        private readonly IDataService _db;
        public JsonResponse _response = new JsonResponse();

        public StationsController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createStations")]
        public async Task<ActionResult<StationsModel>> createStations([FromBody] StationsModel model)
        {
            try
            {
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
            try
            {
                var output = await _db.StationsGetAll();
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
