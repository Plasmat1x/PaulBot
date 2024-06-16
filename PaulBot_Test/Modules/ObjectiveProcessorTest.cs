using Moq;

using PaulBot.Models;
using PaulBot.Module.ObjectiveProcessor;
using PaulBot.Modules.Interfaces;

namespace PaulBot_Test.Modules;
public class ObjectiveProcessorTest
{

  [Fact]
  public async Task create_objective_With_objectiveprocessor()
  {

    // Arrange
    var storageMock = new Mock<IStorage<Objective>>();
    var loggerMock = new Mock<ILogger>();
    var pollingSystemMock = new Mock<IPollingSystem>();
    var expire = DateTime.UtcNow.AddHours(1);
    var objectiveOptions = new ObjectiveOptions(1, "Test Task", "CreatorTag", expire);
    var processor = new ObjectiveProcessor(storageMock.Object, pollingSystemMock.Object, loggerMock.Object);

    // Act
    var result = await processor.CreateObjectiveAsync(objectiveOptions);

    // Assert
    storageMock.Verify(s => s.CreateAsync(It.IsAny<Objective>(), CancellationToken.None), Times.Once);
    loggerMock.Verify(l => l.Log("Objective created"), Times.Once);

    Assert.NotNull(result);
    Assert.Equal(1, result.Id);
    Assert.Equal("Test Task", result.ObjectiveInfo);
    Assert.Equal("CreatorTag", result.ObjectiveCreatorTag);
    Assert.Equal(expire, result.Expire);
  }
}
