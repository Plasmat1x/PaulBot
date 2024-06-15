using PaulBot.Models;
using PaulBot.Module.ObjectiveProcessor;

namespace PaulBot_Test.Modules;
public class ObjectiveProcessorTest
{

  [Fact]
  public void create_objective_With_objectiveprocessor()
  {

    int id = 1;
    string objectiveInfo = "Test creation";
    string objectiveCreatorTag = "DiscordUser";
    TimeSpan expirie = TimeSpan.FromMilliseconds(10);

    var objectiveProcessor = new ObjectiveProcessor();

    var exceptedObjective = new Objective(id, objectiveInfo, objectiveCreatorTag, expirie);

    var creationObjectiveResult = objectiveProcessor.CreateObjective(new(id, objectiveInfo, objectiveCreatorTag, expirie));

    bool assertResult = (creationObjectiveResult.Status == exceptedObjective.Status)
      && (creationObjectiveResult.Id == exceptedObjective.Id)
      && (creationObjectiveResult.ObjectiveInfo == exceptedObjective.ObjectiveInfo)
      && (creationObjectiveResult.ExecutorTag == exceptedObjective.ExecutorTag);

    Assert.True(assertResult);
  }
}
