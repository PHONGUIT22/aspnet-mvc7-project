﻿using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Bloggie.Web.Data
{
    public class BloggieDbContext:DbContext
    {
        public BloggieDbContext(DbContextOptions<BloggieDbContext> options) : base(options)
        { 

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<BlogPostLike> BlogPostLike { get; set;}

        public DbSet<BlogPostComment> BlogPostComment { get; set;}
    }
} //Khi add-migration thi ta se co 2 bang nay
