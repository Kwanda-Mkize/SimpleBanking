public class IdempotencyStore : IDempotency
{
  private readonly Dictionary<string, object> _CacheStore = new();

  public bool TryGetResponse(string key, out object? response)
  {
    return _CacheStore.TryGetValue(key, out response);
  }

  public void SaveResponse(string key, object response)
  {
    if (!_CacheStore.ContainsKey(key))
    {
      _CacheStore[key] = response;
    }
  }
}