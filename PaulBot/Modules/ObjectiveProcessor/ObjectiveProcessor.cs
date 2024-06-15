using PaulBot.Models;

namespace PaulBot.Module.ObjectiveProcessor;

public class ObjectiveProcessor
{
  public ObjectiveProcessor()
  {

  }

  public Objective CreateObjective(ObjectiveOptions _objectiveOptions) => new Objective(_objectiveOptions.id,
    _objectiveOptions.taskInfo,
    _objectiveOptions.objectiveCreatorTag,
    _objectiveOptions.expire);
  public void UpdateStatus(int _id, Status _status) => throw new NotImplementedException();
  public void AssignExecutor(int _id, string _executorTag) => throw new NotImplementedException();
}

public record ObjectiveOptions(int id, string taskInfo, string objectiveCreatorTag, TimeSpan expire);
