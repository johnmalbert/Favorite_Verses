using System;
using Microsoft.EntityFrameworkCore;

namespace QuotingDojo.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Quote> Quotes {get;set;}
    }
}