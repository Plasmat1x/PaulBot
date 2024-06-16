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

    p_storage.CreateAsync(objective);
    p_logger.Log("objective created");

    return objective;
  }

  public async Task<ObjectiveProcessor> UpdateStatusAsync(int _id, Status _status, CancellationToken _cancelationToken = default)
  {
    var objective = p_storage.ReadAsync(_id).Result;

    if(objective == null)
      return this;

    objective.SetStatus(_status);

    p_storage.UpdateAsync(objective);

    return this;

    throw new NotImplementedException();
  }

  public async Task<ObjectiveProcessor> AssignExecutorAsync(int _id, string _executorTag, CancellationToken _cancelationToken = default) => this;

  public async Task<Objective> CheckStatusAsync(int _id, CancellationToken _cancelationToken = default) => throw new NotImplementedException();

  public async Task<ObjectiveProcessor> CompleteObjectiveAsync(int _id, CancellationToken _cancelationToken = default) => this;
}

public record ObjectiveOptions(int id, string taskInfo, string objectiveCreatorTag, DateTime expire);

