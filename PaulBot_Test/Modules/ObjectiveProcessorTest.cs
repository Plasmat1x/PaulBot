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

    var excepted = new Objective(id, objectiveInfo, objectiveCreatorTag, expirie);

    var res = objectiveProcessor.CreateObjective(new(id, objectiveInfo, objectiveCreatorTag, expirie));

    Assert.Equal(excepted, res);
  }
}
