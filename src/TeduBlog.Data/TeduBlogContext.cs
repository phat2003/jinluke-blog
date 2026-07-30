using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeduBlog.Core.Domain.Content;
using TeduBlog.Core.Domain.Identity;

namespace TeduBlog.Data
{
    public class TeduBlogContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public TeduBlogContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostActivityLog> PostActivityLogs { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<PostInSeries> PostInSeries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)//Cấu hình custom riêng cho các bảng trong cơ sở dữ liệu
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);//Cấu hình bảng AppUserClaims với khóa chính là Id(Guid)

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims")//Cấu hình bảng AppRoleClaims với khóa chính là Id(Guid)
            .HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);//Cấu hình bảng AppUserLogins với khóa chính là UserId(Guid)

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")//Cấu hình bảng AppUserRoles với khóa chính là RoleId và UserId(Guid)
            .HasKey(x => new { x.RoleId, x.UserId });

            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")//Cấu hình bảng AppUserTokens với khóa chính là UserId(Guid)
               .HasKey(x => new { x.UserId });
        }
    }
}
