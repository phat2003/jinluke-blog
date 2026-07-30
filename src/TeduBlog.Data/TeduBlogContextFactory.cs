using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduBlog.Data
{
    public class TeduBlogContextFactory : IDesignTimeDbContextFactory<TeduBlogContext>
    {
        public TeduBlogContext CreateDbContext(string[] args)// method này được gọi khi chạy lệnh dotnet ef migrations add <MigrationName> để tạo migration
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())// lấy đường dẫn hiện tại của project
                 .AddJsonFile("appsettings.json")// đọc file appsettings.json
                 .Build();// build configuration từ file appsettings.json
            var builder = new DbContextOptionsBuilder<TeduBlogContext>();// tạo builder để cấu hình DbContext
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));// lấy connection string từ file appsettings.json
            return new TeduBlogContext(builder.Options);// trả về một instance của TeduBlogContext với cấu hình đã được thiết lập
        }
    }
}
