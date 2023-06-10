using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;

namespace WeatherAPI;

public partial class ColourContext : DbContext
{
    public ColourContext(DbContextOptions<ColourContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colour> Colour { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}