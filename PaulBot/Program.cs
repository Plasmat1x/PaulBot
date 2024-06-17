using PaulBot.Commands;
using PaulBot.Writers;
using PaulBot.CommandExecutor;
using PaulBot.Interfaces;

namespace PaulBot
{
  internal class Program
  {
    private static ICommandsExecutor CreateExecutor()
    {
      var executor = new CommandsExecutor(Console.Out);
      executor.Register(new HelpCommand(executor));
      return executor;
    }

    static void Main(string[] args)
    {
      ICommandsExecutor executor = CreateExecutor();
      if (args.Length > 0)
        executor.Execute(args);
      else
        RunInteractiveMode(executor);
    }

    public static void RunInteractiveMode(ICommandsExecutor executor)
    {
      while (true)
      {
        var line = Console.ReadLine();
        if (line == null || line == "exit") return;
        executor.Execute(line.Split(' '));
      }
    }
  }
}
