using AuthorBookAuthorDetails1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AuthorBookAuthorDetails1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorDetails> AuthorDetailss { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
