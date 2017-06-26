namespace WedApiSeed
{
    public static class SetupConfig
    {
        public static Setting Setting { get; set; }
    }

    public class Setting
    {
        public long ServiceTimer { get; set; }
        public string Expiry { get; set; }
        public Connections Connections { get; set; }
        public MessageService MessageService { get; set; }
    }

    public class MessageService
    {
        public string SenderId { get; set; }
        public string BaseUrl { get; set; }
        public string SendMessageUrl { get; set; }
        public string CheckBalanceUrl { get; set; }
        public string ApiKey { get; set; }
        public bool IsActive { get; set; }
    }

    public class Connections
    {
        public string Name { get; set; }
        public string ApiKey { get; set; }
    }
}