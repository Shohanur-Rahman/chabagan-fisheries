using Chabagan.Fisheries.Entities.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chabagan.Chabagan.Fisheries.Models.User
{
    [Index(nameof(Email), IsUnique = true)]
    public class DbUser : BaseClassInfo
    {
        [Required]
        [StringLength(100)]
        [MinLength(1, ErrorMessage = "Value should be at least one character")]
        public string Name { get; set; } = string.Empty;
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public bool IsLock { get; set; }
        public string? ForgetPasswordToken { get; set; }
        public DateTime? PasswordRequestDate { get; set; }
        public virtual DbRole? Role { get; set; }
    }
}
