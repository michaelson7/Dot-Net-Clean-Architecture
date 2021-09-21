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

namespace WEB_DIR.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _db;

        public List<RolesModel> rolesModelList = new();
        public RolesModel rolesModel = new();
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
            //get roles
            rolesModelList = await _db.RolesGetAll();
            if (rolesModelList.Count() > 0)
            {
                hasData = true;
            }
            else
            {
                hasData = false;
            }
        }

        public async Task<IActionResult> OnPost(RolesModel model, DbOperations dbOperations, int deleteId)
        {
            //if deleting set operation to Delete
            dbOperations = deleteId > 0 ? DbOperations.Delete : dbOperations;

            try
            {
                switch (dbOperations)
                {
                    case DbOperations.Create:
                        var id = await _db.RolesCreate(model);
                        break;
                    case DbOperations.Update:
                        await _db.RolesUpdate(model);
                        break;
                    case DbOperations.Delete:
                        await _db.RolesDelete(deleteId);
                        break;
                }
                return RedirectToPage("/Roles/Index", new
                {
                    dbOperation = deleteId > 0 ? DbOperations.Delete : dbOperations,
                    hasResponse = true
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToPage("/Roles/Index", new
                {
                    error = true,
                    errorMessage = e.Message,
                    hasResponse = true
                });
            }
        }
    }
}
