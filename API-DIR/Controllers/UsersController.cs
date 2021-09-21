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
    public class UsersController : Controller
    {
        private readonly IDataService _db;
        public JsonResponse _response = new JsonResponse();

        public UsersController(IDataService db)
        {
            _db = db;
        }

        //check if account exits
        public async Task<bool> isExistAsync(UsersModel model)
        {
            var exists = await _db.UsersLogin(email: model.Email, password: model.Password);
            if (exists == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //create
        [HttpPost]
        [Route("createUsers")]
        public async Task<ActionResult<UsersModel>> createUsers([FromBody] UsersModel model)
        {
            try
            {
                var exists = await isExistAsync(model);
                if (!exists)
                {
                    var output = await _db.UsersCreate(model);
                    return _response.getResponse(output, "Error while creating Users");
                }
                else
                {
                    return _response.getResponse(null, "Account already exists");
                }


            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getUsers")]
        public async Task<ActionResult<UsersModel>> getUsersById(int id)
        {
            try
            {
                var output = await _db.UsersGet(id);
                return _response.getResponse(output, "Users not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<ActionResult<IEnumerable<UsersModel>>> getAllUsers()
        {
            try
            {
                var output = await _db.UsersGetAll();
                return _response.getResponse(output, "Users not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateUsers")]
        public async Task<ActionResult<UsersModel>> updateUsers([FromBody] UsersModel model)
        {
            try
            {
                await _db.UsersUpdate(model);
                return _response.getResponse("", "Users not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //delete
        [HttpGet]
        [Route("deleteUsers")]
        public async Task<ActionResult<UsersModel>> deleteUserAsync(int id)
        {
            try
            {
                await _db.UsersDelete(id);
                return _response.getResponse("", "Users Cold not be deleted");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //change password
        [HttpPost]
        [Route("updateUserPassword")]
        public async Task<ActionResult<UsersModel>> updateUserPassword(string newPassword, int id)
        {
            try
            {
                await _db.UsersChangePassword(id, newPassword);
                return _response.getResponse("", "Password Not Updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //Login
        [HttpPost]
        [Route("loginUser")]
        public async Task<ActionResult<UsersModel>> loginUser(string email, string password)
        {
            try
            {
                var output = await _db.UsersLogin(email, password);
                return _response.getResponse(output, "Account does not exist");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
