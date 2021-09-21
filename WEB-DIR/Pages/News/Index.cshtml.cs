using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_DIR.Services;

namespace WEB_DIR.Pages.News
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _db;
        private readonly IWebHostEnvironment _env;

        public List<NewsModel> NewsModelList = new();
        public NewsModel NewsModel = new();
        public ImageHandler _imageHandler = new();
        public bool hasData = false;

        [BindProperty(SupportsGet = true)]
        public bool hasError { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public bool hasResponse { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public string errorMessage { get; set; }
        [BindProperty(SupportsGet = true)]
        public DbOperations dbOperation { get; set; }

        public IndexModel(IDataService db, IWebHostEnvironment env)
        {
            _env = env;
            _db = db;
        }

        public async Task OnGetAsync()
        {
            //get News
            NewsModelList = await _db.NewsGetAll();
            if (NewsModelList.Count() > 0)
            {
                hasData = true;
            }
            else
            {
                hasData = false;
            }
        }

        public async Task<IActionResult> OnPost(NewsModel model, DbOperations dbOperations, int deleteId)
        {
            //if deleting set operation to Delete
            dbOperations = deleteId > 0 ? DbOperations.Delete : dbOperations;

            //update image if present
            var imageName = await _imageHandler.UploadFile(_env, model.ImageFile);
            if (imageName != null)
            {
                model.ImagePath = imageName;
            }

            //replace
            model.UserId = 1;
            try
            {
                switch (dbOperations)
                {
                    case DbOperations.Create:
                        var id = await _db.NewsCreate(model);
                        break;
                    case DbOperations.Update:
                        await _db.NewsUpdate(model);
                        break;
                    case DbOperations.Delete:
                        await _db.NewsDelete(deleteId);
                        break;
                }
                return RedirectToPage("/News/Index", new
                {
                    dbOperation = deleteId > 0 ? DbOperations.Delete : dbOperations,
                    hasResponse = true
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToPage("/News/Index", new
                {
                    error = true,
                    errorMessage = e.Message,
                    hasResponse = true
                });
            }
        }

    }
}
