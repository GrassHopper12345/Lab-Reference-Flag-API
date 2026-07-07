using LabReferenceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LabReferenceApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Biomarker> Biomarkers => Set<Biomarker>();
    public DbSet<ReferenceRange> ReferenceRanges => Set<ReferenceRange>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Set decimal precision globally
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetPrecision(10);
            property.SetScale(4);
        }

        modelBuilder.Entity<Biomarker>(entity =>
        {
            entity.HasIndex(b => b.Name).IsUnique();
        });

        modelBuilder.Entity<ReferenceRange>(entity =>
        {
            entity.HasIndex(r => new { r.BiomarkerId, r.SexFilter, r.MinAge, r.MaxAge });

            entity.HasOne(r => r.Biomarker)
                .WithMany(b => b.ReferenceRanges)
                .HasForeignKey(r => r.BiomarkerId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
