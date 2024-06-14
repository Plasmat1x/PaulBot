using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulBot.Writers
{
  public class PromptConsoleWriter : TextWriter
  {
    public override void WriteLine(string s)
    {
      Console.Out.WriteLine("> " + s);
    }

    public override Encoding Encoding => Console.Out.Encoding;
  }
}
