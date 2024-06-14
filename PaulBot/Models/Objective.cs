namespace PaulBot.Models;

enum Status
{
  Completed,
  Assigning,
  Processing,
}

class Objective
{
  public Objective(int _id, string _objectiveInfo, TimeSpan _expire)
  {
    Id = _id;
    ObjectiveInfo = _objectiveInfo;
  }

  public void SetStatus(Status _state) => Status = _state;

  public int Id { get; init; }
  public string ObjectiveInfo { get; init; }
  public Status Status { get; private set; } = Status.Assigning;
  public DateTime CreatedAt { get; init; } = DateTime.Now;
}



