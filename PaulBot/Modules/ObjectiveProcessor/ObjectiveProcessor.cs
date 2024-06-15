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

  public Objective CreateObjective(ObjectiveOptions _objectiveOptions)
  {
    var objective = new Objective(_objectiveOptions.id,
    _objectiveOptions.taskInfo,
    _objectiveOptions.objectiveCreatorTag,
    _objectiveOptions.expire);

    p_storage.Create(objective);
    p_logger.Log("objective created");

    return objective;
  }

  public ObjectiveProcessor UpdateStatus(int _id, Status _status)
  {
    var objective = p_storage.Read(_id).Result;

    if(objective == null)
      return this;

    objective.SetStatus(_status);

    p_storage.Update(objective);

    return this;

    throw new NotImplementedException();
  }

  public ObjectiveProcessor AssignExecutor(int _id, string _executorTag) => this;

  public Objective CheckStatus(int _id) => throw new NotImplementedException();

  public ObjectiveProcessor CompleteObjective(int _id) => this;
}

public record ObjectiveOptions(int id, string taskInfo, string objectiveCreatorTag, TimeSpan expire);

