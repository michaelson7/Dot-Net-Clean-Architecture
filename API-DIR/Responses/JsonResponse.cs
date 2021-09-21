using API_DIR.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DIR.Responses
{
    public class JsonResponse : Controller
    {
        public ResponseModel response;

        public dynamic getResponse(dynamic output, string errorMessage)
        {
            if (output != null)
            {
                response = new ResponseModel
                {
                    error = false,
                    results = output
                };
                return Ok(response);
            }
            else
            {
                response = new ResponseModel
                {
                    error = true,
                    errorMessage = errorMessage
                };
                return Ok(response);
            }
        }

        public dynamic errorResponse(string ErrorMessage)
        {
            response = new ResponseModel
            {
                error = true,
                errorMessage = ErrorMessage
            };

            return BadRequest(response);
        }
    }
}
