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
    public class GaugeStationController : Controller
    {
        private readonly IDataService _db;
        public JsonResponse _response = new JsonResponse();

        public GaugeStationController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createGaugeStation")]
        public async Task<ActionResult<GaugeStationModel>> createGaugeStation([FromBody] GaugeStationModel model)
        {
            try
            {
                var output = await _db.GaugeStationCreate(model);
                return _response.getResponse(output, "Error while creating GaugeStation");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getGaugeStation")]
        public async Task<ActionResult<GaugeStationModel>> getGaugeStationById(int id)
        {
            try
            {
                var output = await _db.GaugeStationGet(id);
                return _response.getResponse(output, "GaugeStation not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllGaugeStation")]
        public async Task<ActionResult<IEnumerable<GaugeStationModel>>> getAllGaugeStation()
        {
            try
            {
                var output = await _db.GaugeStationGetAll();
                return _response.getResponse(output, "GaugeStation not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateGaugeStation")]
        public async Task<ActionResult<GaugeStationModel>> updateGaugeStation([FromBody] GaugeStationModel model)
        {
            try
            {
                await _db.GaugeStationUpdate(model);
                return _response.getResponse("", "GaugeStation not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("GaugeStationGetRecords")]
        public async Task<ActionResult<GaugeRecordsModel>> GaugeStationGetRecords(int id)
        {
            try
            {
                var output = await _db.GaugeStationGetRecords(id);
                return _response.getResponse(output, "GaugeStation not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
