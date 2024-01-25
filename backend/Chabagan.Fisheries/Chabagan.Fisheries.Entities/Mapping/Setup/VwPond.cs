using Microsoft.AspNetCore.Http;

namespace Chabagan.Fisheries.Entities.Mapping.Setup
{
    public class VwPond : VwBaseInfo
    {
        public string Name { get; set; } = string.Empty;
        public long ProjectId { get; set; }
        public string? Avatar { get; set; }
        public IFormFile? Attachment { get; set; }
    }
}
