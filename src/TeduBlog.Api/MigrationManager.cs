using Microsoft.EntityFrameworkCore;
using TeduBlog.Data;

namespace TeduBlog.Api
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)// phương thức mở rộng cho WebApplication để thực hiện việc migrate cơ sở dữ liệu
        {
            using(var scope = app.Services.CreateScope())// tạo một phạm vi dịch vụ mới để quản lý vòng đời của các dịch vụ được tạo ra trong phạm vi này
            {
                using (var context = scope.ServiceProvider.GetRequiredService<TeduBlogContext>())// lấy đối tượng TeduBlogContext từ dịch vụ DI
                {
                    context.Database.Migrate();// gọi phương thức Migrate để áp dụng các thay đổi cơ sở dữ liệu
                    new DataSeeder().SeedAsync(context).Wait();// gọi phương thức SeedAsync để thêm dữ liệu mặc định vào cơ sở dữ liệu
                }
            }
            return app;// trả về đối tượng WebApplication để có thể tiếp tục sử dụng trong chuỗi gọi phương thức
        }
    }
}
