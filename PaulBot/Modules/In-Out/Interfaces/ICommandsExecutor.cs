using PaulBot.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulBot.Interfaces
{
  public interface ICommandsExecutor
  {
    ConsoleCommand FindCommandByName(string name);
    string[] GetAvailableCommandName();
    void Execute(string[] args);
  }
}
