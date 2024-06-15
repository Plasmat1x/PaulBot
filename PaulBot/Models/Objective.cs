﻿namespace PaulBot.Models;

public enum Status
{
  Completed,
  Assigning,
  Processing,
}

public class Objective
{
  public Objective(int _id, string _objectiveInfo, string _objectiveCreatorTag, TimeSpan _expire)
  {
    Id = _id;
    ObjectiveInfo = _objectiveInfo;
    ObjectiveCreatorTag = _objectiveCreatorTag;
    Expire = CreatedAt.Add(_expire);
  }

  public void SetStatus(Status _state) => Status = _state;
  public void SetExecutor(string _executorTag) => ExecutorTag = _executorTag;

  public int Id { get; init; }
  public string ObjectiveInfo { get; init; }
  public DateTime Expire { get; init; }
  public Status Status { get; private set; } = Status.Assigning;
  public DateTime CreatedAt { get; init; } = DateTime.Now;
  public string ExecutorTag { get; private set; }
  public string ObjectiveCreatorTag { get; init; }
}


