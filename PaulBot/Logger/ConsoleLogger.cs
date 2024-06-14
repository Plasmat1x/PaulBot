using Discord;
using PaulBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulBot.Logger
{
  public class ConsoleLogger : ILogger
  {
    public ConsoleLogger()
    {
    }
    public Task Log(LogMessage message)
    {
      return Task.Factory.StartNew(() =>
      {
        Console.WriteLine(message.ToString());
      });
    }
  }
}
