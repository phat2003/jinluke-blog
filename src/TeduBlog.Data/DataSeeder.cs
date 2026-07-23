using Microsoft.AspNetCore.Identity;
using TeduBlog.Core.Domain.Identity;

namespace TeduBlog.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(TeduBlogContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            var rootAdminRoleId = Guid.NewGuid();
            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name = "RootAdmin",
                    NormalizedName = "ADMIN",
                    DisplayName = "Quản trị viên"
                });
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())//nếu chưa có user nào trong bảng Users    
            {
                var userId = Guid.NewGuid();//tạo một Guid mới cho userId
                var user = new AppUser()
                {
                    Id = userId,
                    FirstName = "Toan",
                    LastName = "Tedu",
                    Email = "admin@tedu.com.vn",
                    NormalizedEmail = "ADMIN@TEDU.COM.VN",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.Now
                };//tạo một user mới với các thông tin cơ bản
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123$");//mã hóa mật khẩu của user là Admin@123$
                await context.Users.AddAsync(user);//thêm user vào bảng Users
                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = rootAdminRoleId,
                    UserId = userId,
                });//thêm user vào bảng UserRoles với vai trò là RootAdmin
                await context.SaveChangesAsync();//lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}
