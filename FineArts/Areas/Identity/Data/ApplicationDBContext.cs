using FineArts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FineArts.Areas.Identity.Data;

public class ApplicationDBContext : IdentityDbContext<user>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }
    public DbSet<Student> students { get; set; }
    public DbSet<Competition> competitions { get; set; }
    public DbSet<Customer> customers { get; set; }
    public DbSet<Evaluation> evaluations { get; set; }
    public DbSet<Exhibition> exhibitions { get; set; }
    public DbSet<ExhibitionPainting> exhibitionpaintings { get; set; }

    public DbSet<Painting> paintings { get; set; }
    public DbSet<PaintingSale> paintingsales { get; set; }
    public DbSet<Staff> staffs { get; set; }
    public DbSet<Award> awards { get; set; }

    public DbSet<StaffRequest> staffRequests { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new userconfiguration());




        builder.Entity<Evaluation>()
        .HasOne(e => e.Staff)
        .WithMany()
        .HasForeignKey(e => e.StaffId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Evaluation>()
            .HasOne(e => e.Painting)
            .WithMany()
            .HasForeignKey(e => e.PaintingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ExhibitionPainting>()
    .Property(e => e.QuotedPrice)
    .HasPrecision(18, 2);

        builder.Entity<ExhibitionPainting>()
            .Property(e => e.SoldPrice)
            .HasPrecision(18, 2);

        builder.Entity<PaintingSale>()
    .Property(p => p.Amount)
    .HasPrecision(18, 2);

        builder.Entity<Award>()
    .Property(a => a.PrizeAmount)
    .HasPrecision(18, 2);

    }
    internal class userconfiguration : IEntityTypeConfiguration<user>
    {
        public void Configure(EntityTypeBuilder<user> builder)
        {
        }

    }

}
