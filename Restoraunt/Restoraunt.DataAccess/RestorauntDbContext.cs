using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Restoraunt.Restoraunt.BL.Auth.Entities;

namespace Restoraunt.Restoraunt.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class RestorauntDbContext : IdentityDbContext<UserModel, IdentityRole<int>, int>
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<FavoriteDish> FavoriteDishes { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Order> Orders { get; set; }

    public RestorauntDbContext(DbContextOptions<RestorauntDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure Identity entities
        builder.Entity<AdminRoleEntity>(entity =>
        {
            entity.ToTable("AdminRoles");
        });

        builder.Entity<IdentityRole<int>>(entity =>
        {
            entity.ToTable("Roles");
        });

        builder.Entity<IdentityUserRole<int>>(entity =>
        {
            entity.ToTable("UserRoles");
        });

        builder.Entity<IdentityUserClaim<int>>(entity =>
        {
            entity.ToTable("UserClaims");
        });

        builder.Entity<IdentityUserLogin<int>>(entity =>
        {
            entity.ToTable("UserLogins");
        });

        builder.Entity<IdentityUserToken<int>>(entity =>
        {
            entity.ToTable("UserTokens");
        });

        // Configure relationships
        builder.Entity<Admin>()
            .HasMany(a => a.Menus)
            .WithOne()
            .HasForeignKey(m => m.IdAdmin);

        builder.Entity<Dish>()
            .HasMany(d => d.Orders)
            .WithOne()
            .HasForeignKey(o => o.IdDish);

        builder.Entity<Dish>()
            .HasMany(d => d.Menus)
            .WithOne()
            .HasForeignKey(m=>m.IdDish);

        builder.Entity<Menu>()
            .HasOne(m => m._Dish)
            .WithMany(d => d.Menus) 
            .HasForeignKey(m => m.IdDish); 

        builder.Entity<Order>()
            .HasOne(m => m._Dish)
            .WithMany(d => d.Orders) 
            .HasForeignKey(m => m.IdDish); 

        builder.Entity<Order>()
            .HasOne(m => m._User)
            .WithMany(u => u.Orders) 
            .HasForeignKey(m => m.IdUser); 

        builder.Entity<FavoriteDish>()
            .HasOne(m => m._User)
            .WithMany(d => d.FavoriteDishes) 
            .HasForeignKey(m => m.IdUser); 
    }

   
}

