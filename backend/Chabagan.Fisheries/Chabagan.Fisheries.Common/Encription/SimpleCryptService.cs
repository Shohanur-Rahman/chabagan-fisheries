namespace Chabagan.Fisheries.Common.Encription
{
    public class SimpleCryptService : SimpleCryptServiceBase
    {
        protected override string EncryptionKey => "ThisIsMyTidyBookApp0123456789@#$=";

        public static SimpleCryptService Factory()
        {
            return new SimpleCryptService();
        }
    }
}
