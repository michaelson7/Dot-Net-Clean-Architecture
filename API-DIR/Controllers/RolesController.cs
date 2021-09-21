using API_DIR.Models;
using API_DIR.Responses;
using Application.Interfaces;
using Domain.Models;
using Infrustructure.StoredProcedures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DIR.Controllers
{
    public class RolesController : Controller
    {
        private readonly IDataService _db;
        public JsonResponse _response = new JsonResponse();

        public RolesController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createRoles")]
        public async Task<ActionResult<RolesModel>> createRoles([FromBody] RolesModel model)
        {
            try
            {
                var output = await _db.RolesCreate(model);
                return _response.getResponse(output, "Error while creating roles");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getRoles")]
        public async Task<ActionResult<RolesModel>> getRolesById(int id)
        {
            try
            {
                var output = await _db.RolesGet(id);
                return _response.getResponse(output, "roles not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllRoles")]
        public async Task<ActionResult<IEnumerable<RolesModel>>> getAllRoles()
        {
            try
            {
                var output = await _db.RolesGetAll();
                return _response.getResponse(output, "roles not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateRoles")]
        public async Task<ActionResult<RolesModel>> updateRoles([FromBody] RolesModel model)
        {
            try
            {
                await _db.RolesUpdate(model);
                return _response.getResponse("", "roles not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //delete
        [HttpGet]
        [Route("deleteRoles")]
        public async Task<ActionResult<RolesModel>> deleteUserAsync(int id)
        {
            try
            {
                await _db.RolesDelete(id);
                return _response.getResponse("", "roles Cold not be deleted");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
