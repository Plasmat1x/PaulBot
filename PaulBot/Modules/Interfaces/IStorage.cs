namespace PaulBot.Modules.Interfaces;
public interface IStorage<T>
{
  Task<T> Read(int _id, CancellationToken _cancelationToken = default);
  Task<T> Create(T _entity, CancellationToken _cancelationToken = default);
  Task<T> Update(T _entity, CancellationToken _cancelationToken = default);
  Task<T> Delete(T _entity, CancellationToken _cancelationToken = default);
}
