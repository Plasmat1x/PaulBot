namespace PaulBot.Modules.Interfaces;
public interface IStorage<T>
{
  Task<T> ReadAsync(int _id, CancellationToken _cancelationToken = default);
  Task<T> CreateAsync(T _entity, CancellationToken _cancelationToken = default);
  Task<T> UpdateAsync(T _entity, CancellationToken _cancelationToken = default);
  Task<T> DeleteAsync(T _entity, CancellationToken _cancelationToken = default);
}
