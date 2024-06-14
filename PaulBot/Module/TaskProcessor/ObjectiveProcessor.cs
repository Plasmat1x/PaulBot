using PaulBot.Models;

namespace PaulBot.Module.ObjectiveProcessor;

class ObjectiveProcessor
{
  //TODO: IStorage

  //TODO: Add ILogger
  public ObjectiveProcessor()
  {

  }

  public Objective CreateTask(int _id, string _taskInfo, TimeSpan _expire) => new Objective(_id, _taskInfo, _expire);
  public Status TaskStatus(int _id) => throw new NotImplementedException();
  public void UpdateStatus(int _id, Status _status) => throw new NotImplementedException();
}
