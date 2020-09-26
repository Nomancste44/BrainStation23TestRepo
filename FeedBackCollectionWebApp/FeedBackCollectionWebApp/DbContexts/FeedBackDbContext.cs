using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using FeedBackCollectionWebApp.Models;

namespace FeedBackCollectionWebApp.DbContexts
{
    public class FeedBackDbContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public FeedBackDbContext():base("DefaultConnection")
        {
            
        }
    }
}