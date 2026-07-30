using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduBlog.Core.Domain.Identity
{
    [Table("AppRoles")]//tạo bảng với tên AppRoles trong cơ sở dữ liệu, vì mặc định Identity sẽ ghi là AspNetRoles nên mình đổi lại cho dễ nhìn
    public class AppRole : IdentityRole<Guid>
    {
        [Required]
        [MaxLength(200)]
        public required string DisplayName { get; set; }
    }
}
