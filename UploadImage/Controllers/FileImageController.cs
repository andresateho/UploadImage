namespace UploadImage.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using Model;
    using Utils;
    using System;

    [ApiController]
    [Route("api/[controller]")]
    public class FileImageController : ControllerBase
    {
        // POST api/<FileImageController>
        [HttpPost]
        public IActionResult Post([FromForm] FileImageModel image)
        {
            int statusCode = 400;
            HttpRequest req = HttpContext.Request;

            try
            {
                if (ValidateImage.ValidateHeaders(req))
                {
                    if(ValidateImage.ValidateExtension(image.Image.FileName))
                    {
                        string PathImage = "C:/ApiC#/UploadImage/UploadImage/Files/" + image.Image.FileName;
                        var fileStream = new FileStream(PathImage, FileMode.Create);
                        image.Image.CopyToAsync(fileStream);                        
                        bool validateImage = ValidateImage.ValidateSize(PathImage, image.Image.FileName);
                        fileStream.Close();
                        System.IO.File.Delete(PathImage);

                        if (validateImage)
                        {
                            statusCode = 200;
                        }              
                    }                    
                }

                return StatusCode(statusCode);
            }
            catch (Exception)
            {
                return StatusCode(statusCode);
            }            
        } 
    }
}
