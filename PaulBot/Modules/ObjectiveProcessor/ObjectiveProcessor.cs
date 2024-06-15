using PaulBot.Models;

namespace PaulBot.Module.ObjectiveProcessor;

class ObjectiveProcessor
{
  //TODO: IStorage

  //TODO: Add ILogger
  public ObjectiveProcessor()
  {

  }

  public Objective CreateTask(ObjectiveCreate _objectiveCreate) =>
    new Objective(_objectiveCreate._id,
      _objectiveCreate._taskInfo,
      _objectiveCreate._objectiveCreatorTag,
      _objectiveCreate._expire);
  public Status TaskStatus(int _id) => throw new NotImplementedException();
  public void UpdateStatus(int _id, Status _status) => throw new NotImplementedException();
  public void AssignExecutor(int _id, string _executorTag) => throw new NotImplementedException();
}

record ObjectiveCreate(int _id, string _taskInfo, string _objectiveCreatorTag, TimeSpan _expire);
