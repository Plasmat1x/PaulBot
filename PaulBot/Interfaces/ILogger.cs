using Discord;

namespace PaulBot.Interfaces
{
    public interface ILogger
    {
        public Task Log(LogMessage message);
    }
}
