using PaulBot.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulBot.CommandExecutor
{
  public class CommandsExecutor : ICommandsExecutor
  {
    private readonly TextWriter writer;
    private readonly List<ConsoleCommand> commands = new List<ConsoleCommand>();

    public CommandsExecutor(TextWriter writer)
    {
      this.writer = writer;
    }
    public void Register(ConsoleCommand command) 
    {
      commands.Add(command);
    }
    public string[] GetAvailableCommandName()
    {
      return commands.Select(c => c.Name).ToArray();
    }

    public ConsoleCommand FindCommandByName(string name)
    {
      return commands.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    public void Execute(string[] args)
    {
      if (args.Length == 0)
        writer.WriteLine("Please specify <command> as the first command line argument");
      var commandName = args[0];
      var cmd = FindCommandByName(commandName);
      if (cmd == null)
        writer.WriteLine("Sorry. Unknown command {0}", commandName);
      else
        cmd.Execute(args, Console.Out);
    }
  }
}
