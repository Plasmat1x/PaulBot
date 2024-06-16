namespace PaulBot.Models;

public enum Status
{
  Completed,
  Assigning,
  Processing,
}

public class Objective
{
  public Objective(int _id, string _objectiveInfo, string _objectiveCreatorTag, DateTime _expire)
  {
    Id = _id;
    ObjectiveInfo = _objectiveInfo;
    ObjectiveCreatorTag = _objectiveCreatorTag;
    Expire = _expire;
  }

  public Objective SetStatus(Status _status)
  {
    var updatedObjective = (Objective)this.MemberwiseClone();
    updatedObjective.Status = _status;
    return updatedObjective;
  }
  public Objective SetExecutor(string _executorTag)
  {
    var updatedObjective = (Objective)this.MemberwiseClone();
    updatedObjective.ExecutorTag = _executorTag;
    return updatedObjective;
  }

  public int Id { get; init; }
  public string ObjectiveInfo { get; init; }
  public DateTime Expire { get; init; }
  public Status Status { get; private set; } = Status.Assigning;
  public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
  public string ExecutorTag { get; private set; }
  public string ObjectiveCreatorTag { get; init; }
}



