using Microsoft.EntityFrameworkCore;
using Users_Mangament.Domain.Models;

namespace Users_Mangament.Infrastructure.Data


{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-Many relationship between User and Role
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Many-to-Many relationship between Role and Permission
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);


            // Add default roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );

            // Add default permissions
            modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, Name = "Read" },
                new Permission { Id = 2, Name = "Add" },
                new Permission { Id = 3, Name = "Update" },
                new Permission { Id = 4, Name = "Delete" }
            );

            // Add default users with roles
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    Email = "admin@example.com",
                    Password = "hashed_password", // يجب تخزين كلمة المرور المشفرة هنا
                    PhoneNumber = "123456789",
                    FullName = "Admin User",
                    BirthDate = DateTime.Parse("1990-01-01"),
                    IsActive = true,
                    ProfilePicturePath = "/profile_pics/admin.jpg"
                },
                new User
                {
                    Id = 2,
                    UserName = "user",
                    Email = "user@example.com",
                    Password = "hashed_password",
                    PhoneNumber = "987654321",
                    FullName = "Regular User",
                    BirthDate = DateTime.Parse("1995-05-15"),
                    IsActive = true,
                    ProfilePicturePath = "/profile_pics/user.jpg"
                }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 2, RoleId = 2 }
            );

            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission { RoleId = 1, PermissionId = 1 },
                new RolePermission { RoleId = 1, PermissionId = 2 },
                new RolePermission { RoleId = 1, PermissionId = 3 },
                new RolePermission { RoleId = 1, PermissionId = 4 },
                new RolePermission { RoleId = 2, PermissionId = 1 },
                new RolePermission { RoleId = 2, PermissionId = 2 }
            );

        }


}
}



