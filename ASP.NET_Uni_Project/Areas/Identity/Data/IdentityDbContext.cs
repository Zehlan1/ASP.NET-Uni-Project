using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Uni_Project.Data;

public class IdentityDbContext : IdentityDbContext<IdentityUser>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "admin", NormalizedName = "ADMIN".ToUpper() },
            new IdentityRole { Id = "2", Name = "user", NormalizedName = "USER".ToUpper() }
        );

        var hasher = new PasswordHasher<IdentityUser>();
        builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "90f50695-2d66-47bf-ac04-820ee7dc807d",
                UserName = "admin1@fake.fake",
                NormalizedUserName = "ADMIN1@FAKE.FAKE",
                Email = "admin1@fake.fake",
                NormalizedEmail = "ADMIN1@FAKE.FAKE",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "AdminPassword1!")
            },
            new IdentityUser
            {
                Id = "023d586c-fdba-4fab-8196-90685b128664",
                UserName = "test1@fake.fake",
                NormalizedUserName = "TEST1@FAKE.FAKE",
                Email = "test1@fake.fake",
                NormalizedEmail = "TEST1@FAKE.FAKE",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password1!")
            },
            new IdentityUser
            {
                Id = "e8d37b64-c354-41bd-ac1d-93e8e73b1b8f",
                UserName = "test2@fake.fake",
                NormalizedUserName = "TEST2@FAKE.FAKE",
                Email = "test2@fake.fake",
                NormalizedEmail = "TEST2@FAKE.FAKE",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password2!")
            },
            new IdentityUser
            {
                Id = "6da4ec6e-fc74-4846-96b6-68049794e89d",
                UserName = "test3@fake.fake",
                NormalizedUserName = "TEST3@FAKE.FAKE",
                Email = "test3@fake.fake",
                NormalizedEmail = "TEST3@FAKE.FAKE",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password3!")
            }
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "90f50695-2d66-47bf-ac04-820ee7dc807d"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "023d586c-fdba-4fab-8196-90685b128664"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "e8d37b64-c354-41bd-ac1d-93e8e73b1b8f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "6da4ec6e-fc74-4846-96b6-68049794e89d"
            }
        );
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
