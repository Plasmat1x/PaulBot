namespace PaulBot.Modules.Interfaces;

// Обобщенный интерфейс для работы с хранилищем данных
public interface IStorage<T>
{
  // Асинхронный метод для чтения объекта по ID
  Task<T> ReadAsync(int _id, CancellationToken _cancelationToken = default);

  // Асинхронный метод для создания нового объекта
  Task<T> CreateAsync(T _entity, CancellationToken _cancelationToken = default);

  // Асинхронный метод для обновления существующего объекта
  Task<T> UpdateAsync(T _entity, CancellationToken _cancelationToken = default);

  // Асинхронный метод для удаления объекта
  Task<T> DeleteAsync(T _entity, CancellationToken _cancelationToken = default);
}
