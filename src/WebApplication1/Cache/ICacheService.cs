namespace RedisApplication.Cache
{
    public interface ICacheService
    {
        T GetData<T>();
        bool SetData<T>(T value);
        object RemoveData();

        List<T> GetListData<T>();
        bool SetListData<T>(List<T> value);
    }
}
