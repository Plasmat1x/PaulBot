namespace PaulBot.Models;

enum State
{
  Completed,
  Assigning,
  Processing,
}

class Task
{
  public Task(int _id, string _taskInfo)
  {
    Id = _id;
    TaskInfo = _taskInfo;
  }

  public void SetState(State _state) => State = _state;

  public int Id { get; init; }
  public string TaskInfo { get; init; }
  public State State { get; private set; } = State.Assigning;
}



