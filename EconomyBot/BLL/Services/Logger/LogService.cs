using Discord.Commands;
using Discord.WebSocket;
using Discord;

namespace EconomyBot.BLL.Services.Logger
{
    public class LogService
    {
        public LogService(DiscordSocketClient client, CommandService command)
        {
            client.Log += LogAsync;
            command.Log += LogAsync;
        }
        public static Task LogAsync(LogMessage message)
        {
            if (message.Exception is CommandException cmdException)
            {
                Console.WriteLine($"[Command/{message.Severity}] {cmdException.Command.Aliases.First()}" + $" failed to execute in {cmdException.Context.Channel}.");
                Console.WriteLine(cmdException);
            }
            else
            {
                Console.WriteLine($"[General/{message.Severity}] {message}");
            }

            return Task.CompletedTask;
        }
    }
}
