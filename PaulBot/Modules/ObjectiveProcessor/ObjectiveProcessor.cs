using PaulBot.Models;
using PaulBot.Modules.Interfaces;

namespace PaulBot.Module.ObjectiveProcessor;

public class ObjectiveProcessor
{
  // Хранилище для объектов типа Objective
  private readonly IStorage<Objective> p_storage;
  // Система опроса
  private readonly IPollingSystem p_pollingSystem;
  // Логгер для записи логов
  private readonly ILogger p_logger;
  
  // Конструктор, инициализирующий зависимости
  public ObjectiveProcessor(IStorage<Objective> _storage, IPollingSystem _pollingSystem, ILogger _logger)
  {
    p_storage = _storage;
    p_pollingSystem = _pollingSystem;
    p_logger = _logger;
  }
  
  // Метод для создания нового Objective
  public async Task<Objective> CreateObjectiveAsync(ObjectiveOptions _objectiveOptions)
  {
    // Создаем новый Objective с заданными параметрами
    var objective = new Objective(_objectiveOptions.id,
    _objectiveOptions.taskInfo,
    _objectiveOptions.objectiveCreatorTag,
    _objectiveOptions.expire);

    // Сохраняем новый Objective в хранилище
    objective = await p_storage.CreateAsync(objective);
    p_logger.Log($"objective created with id: {objective.Id}");

    return objective;
  }
  
  // Метод для обновления статуса Objective
  public async Task<Objective> UpdateStatusAsync(int _id, Status _status, CancellationToken _cancelationToken = default)
  {
    // Получаем Objective по ID из хранилища
    var objective = await p_storage.ReadAsync(_id);

    if(objective == null)
    {
      // Логируем, если Objective не найден
      p_logger.Log($"objective {_id} not found");
      return null;
    }

    // Обновляем статус Objective
    objective = objective.SetStatus(_status);
    // Сохраняем обновленный Objective в хранилище
    objective = await p_storage.UpdateAsync(objective);
    // Логируем обновление статуса
    p_logger.Log($"Objective updated with status {objective.Status}");

    return objective;
  }
  
  // Метод для назначения исполнителя Objective
  public async Task<Objective> AssignExecutorAsync(int _id, string _executorTag, CancellationToken _cancelationToken = default)
  {
    // Получаем Objective по ID из хранилища
    var objective = await p_storage.ReadAsync(_id);

    if(objective == null)
    {
      // Логируем, если Objective не найден
      p_logger.Log($"objective {_id} not found");
      return null;
    }

    // Назначаем исполнителя Objective
    objective = objective.SetExecutor(_executorTag);
    // Сохраняем обновленный Objective в хранилище
    objective = await p_storage.UpdateAsync(objective);
    // Логируем назначение исполнителя
    p_logger.Log($"Objective updated with executor: {objective.ExecutorTag}");

    return objective;
  }

  // Метод для проверки статуса Objective
  public async Task<Objective> CheckStatusAsync(int _id, CancellationToken _cancelationToken = default)
  {
    // Получаем Objective по ID из хранилища
    var objective = await p_storage.ReadAsync(_id);

    if(objective == null)
    {
      // Логируем, если Objective не найден
      p_logger.Log($"objective {_id} not found");
      return null;
    }

    // Возвращаем найденный Objective
    return objective;
  }

  // Метод для завершения Objective
  public async Task<Objective> CompleteObjectiveAsync(int _id, CancellationToken _cancelationToken = default)
  {
    // Получаем Objective по ID из хранилища
    var objective = await p_storage.ReadAsync(_id);

    if(objective == null)
    {
      // Логируем, если Objective не найден
      p_logger.Log($"objective {_id} not found");
      return null;
    }

    // Обновляем статус Objective на "Завершен"
    objective = objective.SetStatus(Status.Completed);
    // Сохраняем обновленный Objective в хранилище
    objective = await p_storage.UpdateAsync(objective);

    return objective;
  }
}

// Класс для передачи параметров создания Objective
public record ObjectiveOptions(int id, string taskInfo, string objectiveCreatorTag, DateTime expire);

