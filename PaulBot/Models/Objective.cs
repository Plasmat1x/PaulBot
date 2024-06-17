namespace PaulBot.Models;

// Перечисление статусов для Objective
public enum Status
{
  Completed,
  Assigning,
  Processing,
}

// Класс, представляющий Objective
public class Objective
{
  // Конструктор для инициализации Objective
  public Objective(int _id, string _objectiveInfo, string _objectiveCreatorTag, DateTime _expire)
  {
    Id = _id;
    ObjectiveInfo = _objectiveInfo;
    ObjectiveCreatorTag = _objectiveCreatorTag;
    Expire = _expire;
  }

  // Метод для обновления статуса Objective
  public Objective SetStatus(Status _status)
  {
    // Клонирование объекта и обновление статуса
    var updatedObjective = (Objective)this.MemberwiseClone();
    updatedObjective.Status = _status;
    return updatedObjective;
  }

  // Метод для назначения исполнителя Objective
  public Objective SetExecutor(string _executorTag)
  {
    // Клонирование объекта и обновление исполнителя
    var updatedObjective = (Objective)this.MemberwiseClone();
    updatedObjective.ExecutorTag = _executorTag;
    return updatedObjective;
  }

  // Уникальный идентификатор Objective
  public int Id { get; init; }

  // Информация об Objective
  public string ObjectiveInfo { get; init; }
  
  // Дата и время истечения Objective
  public DateTime Expire { get; init; }

  // Текущий статус Objective, по умолчанию "Assigning"
  public Status Status { get; private set; } = Status.Assigning;

  // Дата и время создания Objective
  public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

  // Тег исполнителя Objective
  public string ExecutorTag { get; private set; }

  // Тег создателя Objective
  public string ObjectiveCreatorTag { get; init; }
}



