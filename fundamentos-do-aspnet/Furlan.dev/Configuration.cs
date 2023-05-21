namespace Furlan.dev
{
    public static class Configuration
    {
        public static string JwtKey  = "batatinha_quando_nasce_se_espalharrama_pelo_chao";
        public static string ApiKeyName  = "api_key";
        public static string ApiKey  = "kappapapa";
        public static SmtpConfiguration Smtp = new();
    
        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}