public interface IDempotency
{
  bool TryGetResponse(string key, out object? response);
  void SaveResponse(string key, object response);
}