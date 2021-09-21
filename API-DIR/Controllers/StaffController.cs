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
    public class StaffController : Controller
    {
        private readonly IDataService _db;
        public JsonResponse _response = new JsonResponse();

        public StaffController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createStaff")]
        public async Task<ActionResult<StaffModel>> createStaff([FromBody] StaffModel model)
        {
            try
            {
                var output = await _db.StaffCreate(model);
                return _response.getResponse(output, "Error while creating Staff");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getStaff")]
        public async Task<ActionResult<StaffModel>> getStaffById(int id)
        {
            try
            {
                var output = await _db.StaffGet(id);
                return _response.getResponse(output, "Staff not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllStaff")]
        public async Task<ActionResult<IEnumerable<StaffModel>>> getAllStaff()
        {
            try
            {
                var output = await _db.StaffGetAll();
                return _response.getResponse(output, "Staff not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateStaff")]
        public async Task<ActionResult<StaffModel>> updateStaff([FromBody] StaffModel model)
        {
            try
            {
                await _db.StaffUpdate(model);
                return _response.getResponse("", "Staff not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
