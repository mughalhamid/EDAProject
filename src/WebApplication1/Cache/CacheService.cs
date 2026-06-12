using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisApplication.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _db;
        private readonly string _redisKey = "_claims_";
        private readonly DateTimeOffset _expirationTime = DateTimeOffset.Now.AddYears(100);


        public CacheService()
        {
            _db = ConnectionHelper.Connection.GetDatabase();
        }
        public T GetData<T>()
        {
            var value = _db.StringGet(_redisKey);
            if (!value.IsNull)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }       

        public object RemoveData()
        {
            throw new NotImplementedException();
        }

        public bool SetData<T>(T value)
        {
            TimeSpan expiryTime = _expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _db.StringSet(_redisKey, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }

        public List<T> GetListData<T>()
        {
            var value = _db.StringGet(_redisKey);
            if (!value.IsNull)
            {
                return JsonConvert.DeserializeObject<List<T>>(value);
            }
            return default;
        }

        public bool SetListData<T>(List<T> value)
        {
            TimeSpan expiryTime = _expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _db.StringSet(_redisKey, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
    }
}
