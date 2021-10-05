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
    public class NewsController : Controller
    {
        private readonly IDataService _db;
        public JsonResponse _response = new JsonResponse();

        public NewsController(IDataService db)
        {
            _db = db;
        }

        //create
        [HttpPost]
        [Route("createNews")]
        public async Task<ActionResult<NewsModel>> createNews([FromBody] NewsModel model)
        {
            try
            {
                var output = await _db.NewsCreate(model);
                return _response.getResponse(output, "Error while creating News");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //get
        [HttpGet]
        [Route("getNews")]
        public async Task<ActionResult<NewsModel>> getNewsById(int id)
        {
            try
            {
                var output = await _db.NewsGet(id);
                return _response.getResponse(output, "News not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //getAll
        [HttpGet]
        [Route("getAllNews")]
        public async Task<ActionResult<IEnumerable<NewsModel>>> getAllNews()
        {
            try
            {
                var output = await _db.NewsGetAll();
                return _response.getResponse(output, "News not found");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //update
        [HttpPost]
        [Route("updateNews")]
        public async Task<ActionResult<NewsModel>> updateNews([FromBody] NewsModel model)
        {
            try
            {
                await _db.NewsUpdate(model);
                return _response.getResponse("", "News not updated");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }

        //delete
        [HttpGet]
        [Route("deleteNews")]
        public async Task<ActionResult<NewsModel>> deleteUserAsync(int id)
        {
            try
            {
                await _db.NewsDelete(id);
                return _response.getResponse("", "News Cold not be deleted");
            }
            catch (Exception e)
            {
                return _response.errorResponse(e.Message);
            }
        }
    }
}
