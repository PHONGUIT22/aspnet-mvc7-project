﻿using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace Bloggie.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTagsController : Controller
    {
        
         private readonly ITagRepository tagRepository;
        public AdminTagsController(ITagRepository tagRepository)
        {
           this.tagRepository = tagRepository;
        }

        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            //mapping Addtagrequest to Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            await tagRepository.AddAsync(tag);
            return RedirectToAction("List");
        }

        
        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            //use dbContext to read the tags
            var tags= await tagRepository.GetAllAsync();
            return View(tags);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag=await tagRepository.GetAsync(id);
            if(tag!=null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };
                return View(editTagRequest);
            }
            return View(null);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName=editTagRequest.DisplayName
            };

            var updatedTag= await tagRepository.UpdateAsync(tag);
            if(updatedTag!=null)
            {

            }
            else
            {

            }
            //show error notification

            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }
       
        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest) 
        {
            var deletedTag=await tagRepository.DeleteAsync(editTagRequest.Id);
            if (deletedTag != null)
            {
                //sucess
                return RedirectToAction("List");
            }

            //Show an Error
            return RedirectToAction("Edit",new {id=editTagRequest.Id });
        }
    }
}
