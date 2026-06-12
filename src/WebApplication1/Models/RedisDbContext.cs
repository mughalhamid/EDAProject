using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RedisApplication.Models;

public partial class RedisDbContext : DbContext
{
    public RedisDbContext()
    {
    }

    public RedisDbContext(DbContextOptions<RedisDbContext> options)
        : base(options)
    {
    }

    public DbSet<Claim> Claims { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=redisDB;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.ToTable("Claims");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}