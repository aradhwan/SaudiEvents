using System;
namespace SaudiEvents.Util
{
    public static class ServerURL
    {
        static string Server = "http://www.saudievents.sa";
        private static readonly string BASE_URL = Server;
        public static string GetURL()
        {
            return BASE_URL;
        }
    }
}
