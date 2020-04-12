namespace ECommerce.Data.Singletons
{
    public class AppSettingsDto
    {
        public static AppSettings AppSetting { get; set; }

        public class AppSettings
        {
            public string ConnectionString { get; set; }
            public string Website { get; set; }
            public SMTP SMTP { get; set; }
        }

        public class SMTP
        {
            public string Server { get; set; }
            public int Port { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}