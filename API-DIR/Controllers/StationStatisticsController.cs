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
    public class StationStatisticsController : Controller
    {
        private readonly IDataService _db;
        public JsonResponse _response = new JsonResponse();

        public StationStatisticsController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createStationStatistics")]
        public async Task<ActionResult<StationStatisticsModel>> createStationStatistics([FromBody] StationStatisticsModel model)
        {
            try
            {
                var output = await _db.StationStatisticsCreate(model);
                return _response.getResponse(output, "Error while creating StationStatistics");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getStationStatistics")]
        public async Task<ActionResult<StationStatisticsModel>> getStationStatisticsById(int id)
        {
            try
            {
                var output = await _db.StationStatisticsGet(id);
                return _response.getResponse(output, "StationStatistics not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllStationStatistics")]
        public async Task<ActionResult<IEnumerable<StationStatisticsModel>>> getAllStationStatistics()
        {
            try
            {
                var output = await _db.StationStatisticsGetAll();
                return _response.getResponse(output, "StationStatistics not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateStationStatistics")]
        public async Task<ActionResult<StationStatisticsModel>> updateStationStatistics([FromBody] StationStatisticsModel model)
        {
            try
            {
                await _db.StationStatisticsUpdate(model);
                return _response.getResponse("", "StationStatistics not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
