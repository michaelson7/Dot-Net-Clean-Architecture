using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEB_DIR.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _db;

        public List<UsersModel> UsersModelList = new();
        public UsersModel UsersModel = new();
        public List<RolesModel> roles = new();
        public bool hasData = false;

        [BindProperty(SupportsGet = true)]
        public bool hasError { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public bool hasResponse { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public string errorMessage { get; set; }
        [BindProperty(SupportsGet = true)]
        public DbOperations dbOperation { get; set; }

        public IndexModel(IDataService db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            //get Users
            UsersModelList = await _db.UsersGetAll();
            roles = await _db.RolesGetAll();
            if (UsersModelList.Count() > 0)
            {
                hasData = true;
            }
            else
            {
                hasData = false;
            }
        }

        public async Task<IActionResult> OnPost(UsersModel model, DbOperations dbOperations, int deleteId)
        {
            //if deleting set operation to Delete
            dbOperations = deleteId > 0 ? DbOperations.Delete : dbOperations;

            try
            {
                switch (dbOperations)
                {
                    case DbOperations.Create:
                        var id = await _db.UsersCreate(model);
                        break;
                    case DbOperations.Update:
                        await _db.UsersUpdate(model);
                        break;
                    case DbOperations.Delete:
                        await _db.UsersDelete(deleteId);
                        break;
                }
                return RedirectToPage("/Users/Index", new
                {
                    dbOperation = deleteId > 0 ? DbOperations.Delete : dbOperations,
                    hasResponse = true
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToPage("/Users/Index", new
                {
                    error = true,
                    errorMessage = e.Message,
                    hasResponse = true
                });
            }
        }
    }
}
