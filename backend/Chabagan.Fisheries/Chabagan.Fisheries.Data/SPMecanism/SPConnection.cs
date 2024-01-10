using Microsoft.Extensions.Configuration;

namespace Chabagan.Fisheries.SPMecanism
{
    public interface ISPConnection
    {
        public string GetConnectionString();
    }

    public class SPConnection : ISPConnection
    {
        private IConfiguration _config;
        public SPConnection(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString()
        {
            return _config.GetConnectionString("DefaultConnection");
        }
    }
}
