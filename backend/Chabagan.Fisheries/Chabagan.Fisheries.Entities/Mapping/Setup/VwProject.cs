using Microsoft.AspNetCore.Http;

namespace Chabagan.Fisheries.Entities.Mapping.Setup
{

    public class VwProject : VwBaseInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Union { get; set; } = string.Empty;
        public int WordNumber { get; set; }
        public string? Avatar { get; set; }
        public IFormFile? Attachment { get; set; }
    }
}
