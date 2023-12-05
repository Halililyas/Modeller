using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Models;
using WebApi.Repositoriys.Config;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Repositoriys
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options) :
            base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = WebApi; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
        public DbSet<Book> Books { get; set; }
    }
}
