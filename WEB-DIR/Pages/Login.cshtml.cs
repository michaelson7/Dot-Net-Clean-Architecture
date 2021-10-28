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

namespace WEB_DIR.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IDataService _db;
        public UsersModel usersModel = new();

        [BindProperty(SupportsGet = true)]
        public bool hasError { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public bool hasResponse { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public string errorMessage { get; set; }
        [BindProperty(SupportsGet = true)]
        public DbOperations dbOperation { get; set; }


        public LoginModel(IDataService db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(UsersModel model)
        {
            try
            {
                var data = await _db.UsersLogin(model.Email, model.Password);
                if (data != null)
                {
                    return RedirectToPage("/Index", new
                    { });
                }
                else
                {
                    return RedirectToPage("/Login", new
                    {
                        hasError = true,
                        errorMessage = "Account does not exist",
                        hasResponse = true
                    });
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToPage("/Login", new
                {
                    hasError = true,
                    errorMessage = e.Message,
                    hasResponse = true
                });
            }
        }
    }
}
