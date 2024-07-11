﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bloggie.Web.Models.ViewModels
{
    public class AddBlogPostRequest
    {
        public string? Heading { get; set; }
        public string pageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { set; get; }
        public string Author { get; set; }

        public bool Visible { get; set; }

        //Display Tags

        public IEnumerable<SelectListItem> Tags { get; set; }
        //Collect Tags

        public string[] SelectedTags { get; set; }=Array.Empty<string>();
    }
}