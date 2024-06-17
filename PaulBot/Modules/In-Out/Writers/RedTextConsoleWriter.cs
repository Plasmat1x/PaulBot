using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulBot.Writers
{
  public class RedTextConsoleWriter : TextWriter
  {
    public override void Write(char value)
    {
      var prev = Console.ForegroundColor;

      try
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Out.Write(value);
      }
      finally
      {
        Console.ForegroundColor = prev;
      }
    }

    public override Encoding Encoding => Console.Out.Encoding;
  }
}
