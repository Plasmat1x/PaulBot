using PaulBot.Models;

namespace PaulBot_Test.Models;
public class ObjectiveTest
{
  [Fact]
  public void create_objective_Should_initilize_properties()
  {
    // Arrange
    int id = 1;
    string info = "Test Objective";
    string creatorTag = "Creator123";
    DateTime expire = DateTime.UtcNow.AddHours(1);

    // Act
    var objective = new Objective(id, info, creatorTag, expire);

    // Assert
    Assert.Equal(id, objective.Id);
    Assert.Equal(info, objective.ObjectiveInfo);
    Assert.Equal(creatorTag, objective.ObjectiveCreatorTag);
    Assert.Equal(expire, objective.Expire);
    Assert.Equal(Status.Assigning, objective.Status);
    Assert.Equal(DateTime.UtcNow.Hour, objective.CreatedAt.Hour);
  }

  [Fact]
  public void with_status_Should_return_new_objective_With_updated_status()
  {
    // Arrange
    var objective = new Objective(1, "Test", "Creator123", DateTime.UtcNow.AddHours(1));

    // Act
    var updatedObjective = objective.SetStatus(Status.Completed);

    // Assert
    Assert.NotSame(objective, updatedObjective);
    Assert.Equal(Status.Completed, updatedObjective.Status);
  }

  [Fact]
  public void With_executor_Should_return_new_objective_With_updated_executor()
  {
    // Arrange
    var objective = new Objective(1, "Test", "Creator123", DateTime.UtcNow.AddHours(1));

    // Act
    var updatedObjective = objective.SetExecutor("Executor456");

    // Assert
    Assert.NotSame(objective, updatedObjective);
    Assert.Equal("Executor456", updatedObjective.ExecutorTag);
  }
}
