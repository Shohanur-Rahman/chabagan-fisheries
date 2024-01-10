using Chabagan.Fisheries.Common.SMTP;

namespace Chabagan.Fisheries.WebApi.Utilities.Interfaces
{
    public interface IConfigSettings
    {
        string GetAPIRootPath();
        string GetJWTKey();
        string GetWebSiteLink();
        SMTPSettings GetSMTPSettings();
    }
}
