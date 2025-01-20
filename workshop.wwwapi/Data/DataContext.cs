﻿using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;
namespace workshop.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)  : base(options)
        { 
        }
        // DBSet 
        public DbSet<Pet> pets { get; set; }
    }
}
