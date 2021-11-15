using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_DIR.Handlers
{
    public class ImageHandlerPro
    {
        public async Task<string> UploadFile(IWebHostEnvironment _env, IFormFile formFile, string folderName = "Images")
        {
            if (formFile != null)
            {
                try
                {
                    var uniqueFileName = GetUniqueFileName(formFile.FileName);
                    //var dir = Path.Combine(_env.WebRootPath, folderName);
                    var dir = "C:\\inetpub\\wwwroot\\HydroApplication\\Website\\wwwroot\\Images";
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    var filePath = Path.Combine(dir, uniqueFileName);
                    await formFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
                    return uniqueFileName;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Image Upload ERROR: {e}");
                    throw new ArgumentException($"Image Upload ERROR: {e}");
                }
            }
            else
            {
                return null;
            }
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Guid.NewGuid().ToString().Substring(0, 15)
                   + Path.GetExtension(fileName);
        }

    }
}
