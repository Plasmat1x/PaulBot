using PaulBot.Models;
using PaulBot.Modules.Interfaces;

namespace PaulBot.Module.ObjectiveProcessor;

public class ObjectiveProcessor
{
  private readonly IStorage<Objective> p_storage;
  private readonly IPollingSystem p_pollingSystem;
  private readonly ILogger p_logger;

  public ObjectiveProcessor(IStorage<Objective> _storage, IPollingSystem _pollingSystem, ILogger _logger)
  {
    p_storage = _storage;
    p_pollingSystem = _pollingSystem;
    p_logger = _logger;
  }

  public async Task<Objective> CreateObjectiveAsync(ObjectiveOptions _objectiveOptions)
  {
    var objective = new Objective(_objectiveOptions.id,
    _objectiveOptions.taskInfo,
    _objectiveOptions.objectiveCreatorTag,
    _objectiveOptions.expire);

    objective = await p_storage.CreateAsync(objective);
    p_logger.Log($"objective created with id: {objective.Id}");

    return objective;
  }

  public async Task<Objective> UpdateStatusAsync(int _id, Status _status, CancellationToken _cancelationToken = default)
  {
    var objective = await p_storage.ReadAsync(_id);

    if(objective == null)
    {
      p_logger.Log($"objective {_id} not found");
      return null;
    }


    objective = objective.SetStatus(_status);
    objective = await p_storage.UpdateAsync(objective);
    p_logger.Log($"Objective updated with status {objective.Status}");

    return objective;
  }

  public async Task<Objective> AssignExecutorAsync(int _id, string _executorTag, CancellationToken _cancelationToken = default)
  {
    var objective = await p_storage.ReadAsync(_id);

    if(objective == null)
    {
      p_logger.Log($"objective {_id} not found");
      return null;
    }


    objective = objective.SetExecutor(_executorTag);
    objective = await p_storage.UpdateAsync(objective);
    p_logger.Log($"Objective updated with executor: {objective.ExecutorTag}");

    return objective;
  }

  public async Task<Objective> CheckStatusAsync(int _id, CancellationToken _cancelationToken = default)
  {
    var objective = await p_storage.ReadAsync(_id);

    if(objective == null)
    {
      p_logger.Log($"objective {_id} not found");
      return null;
    }

    return objective;
  }

  public async Task<Objective> CompleteObjectiveAsync(int _id, CancellationToken _cancelationToken = default)
  {
    var objective = await p_storage.ReadAsync(_id);

    if(objective == null)
    {
      p_logger.Log($"objective {_id} not found");
      return null;
    }

    objective = objective.SetStatus(Status.Completed);
    objective = await p_storage.UpdateAsync(objective);

    return objective;
  }
}

public record ObjectiveOptions(int id, string taskInfo, string objectiveCreatorTag, DateTime expire);

