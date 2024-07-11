﻿using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bloggie.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRespository imageRespository;
        public ImagesController(IImageRespository imageRespository)
        {
            this.imageRespository = imageRespository;
        }
        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            //call a repository
            var imageURl=await imageRespository.UploadAsync(file);
            if(imageURl == null)
            {
                return Problem("Something went wrong", null, (int)HttpStatusCode.InternalServerError);

            }
            return new JsonResult(new { link = imageURl});
        }
    }
}
