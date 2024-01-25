using Chabagan.Chabagan.Fisheries;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chabagan.Fisheries.Entities.Models.Setup
{
    public class DbPond : BaseClassInfo
    {
        public string Name { get; set; } = string.Empty;
        [ForeignKey(nameof(Project))]
        public long ProjectId { get; set; }
        public virtual DbProject? Project { get; set; }
        public string? Avatar { get; set; }
    }
}
