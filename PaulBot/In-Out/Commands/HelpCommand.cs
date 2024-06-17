
using PaulBot.Interfaces;

namespace PaulBot.Commands
{
  public class HelpCommand : ConsoleCommand
  {
    private readonly ICommandsExecutor executor;
    public HelpCommand(ICommandsExecutor executor)
      : base("h", "h    # prints available commands list")
    {
      this.executor = executor;
    }

    public override void Execute(string[] args, TextWriter w)
    {
      w.WriteLine("Available commands: " + string.Join(", ", executor.GetAvailableCommandName()));
    }
  }
}
