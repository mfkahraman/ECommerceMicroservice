using StackExchange.Redis;

namespace ECommerce.Basket.Services
{
    public class RedisService
    {
        private string Host { get; set; }
        private int Port { get; set; }

        private ConnectionMultiplexer connectionMultiplexer;

        public RedisService(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public void Connect() => connectionMultiplexer = ConnectionMultiplexer.Connect($"{Host}:{Port}");

        public IDatabase GetDb(int db=1) => connectionMultiplexer.GetDatabase(db);
    }
}
