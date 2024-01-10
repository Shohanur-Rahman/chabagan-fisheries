using Chabagan.Chabagan.Fisheries.Models.Area;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Chabagan.Chabagan.Fisheries.Models.Project
{
    public class DbProject : BaseClassInfo
    {
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(Area))]
        public long AreaId { get; set; }
        public virtual DbArea? Area { get; set; }
        public string? Avatar { get; set; }

    }
}
