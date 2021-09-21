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
    public class GaugeRecordsController : Controller
    {
        private readonly IDataService _db;
        public JsonResponse _response = new JsonResponse();

        public GaugeRecordsController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createGaugeRecords")]
        public async Task<ActionResult<GaugeRecordsModel>> createGaugeRecords([FromBody] GaugeRecordsModel model)
        {
            try
            {
                var output = await _db.GaugeRecordsCreate(model);
                return _response.getResponse(output, "Error while creating GaugeRecords");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getGaugeRecords")]
        public async Task<ActionResult<GaugeRecordsModel>> getGaugeRecordsById(int id)
        {
            try
            {
                var output = await _db.GaugeRecordsGet(id);
                return _response.getResponse(output, "GaugeRecords not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllGaugeRecords")]
        public async Task<ActionResult<IEnumerable<GaugeRecordsModel>>> getAllGaugeRecords()
        {
            try
            {
                var output = await _db.GaugeRecordsGetAll();
                return _response.getResponse(output, "GaugeRecords not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateGaugeRecords")]
        public async Task<ActionResult<GaugeRecordsModel>> updateGaugeRecords([FromBody] GaugeRecordsModel model)
        {
            try
            {
                await _db.GaugeRecordsUpdate(model);
                return _response.getResponse("", "GaugeRecords not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //delete
        [HttpGet]
        [Route("deleteGaugeRecords")]
        public async Task<ActionResult<GaugeRecordsModel>> deleteUserAsync(int id)
        {
            try
            {
                await _db.GaugeRecordsDelete(id);
                return _response.getResponse("", "GaugeRecords Cold not be deleted");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
