using API_DIR.Handlers;
using API_DIR.Responses;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _env;
        public ImageHandlerPro _imageHandler = new();

        public GaugeRecordsController(IDataService db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        //create
        [HttpPost]
        [Route("createGaugeRecords")]
        public async Task<ActionResult<GaugeRecordsModel>> createGaugeRecords([FromForm] GaugeRecordsModel model)
        {
            try
            {
                //upload file
                if (model.ImageFile != null)
                {
                    var imageName = await _imageHandler.UploadFile(_env, model.ImageFile);
                    model.Imagepath = imageName;
                }
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
                string baseUrl = string.Format("{0}://{1}",
                       HttpContext.Request.Scheme, HttpContext.Request.Host);
                var output = await _db.GaugeRecordsGetAll();
                //foreach (var data in output)
                //{
                //    data.Imagepath = $"{baseUrl}/Images/{data.Imagepath}";
                //}
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
                //upload file
                if (model.ImageFile != null)
                {
                    var imageName = await _imageHandler.UploadFile(_env, model.ImageFile);
                    model.Imagepath = imageName;
                }
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
