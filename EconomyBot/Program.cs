using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using EconomyBot.BLL.Services.Handlers;
using Discord.Interactions;
using EconomyBot.BLL.Services.Logger;
using Microsoft.Extensions.Configuration;
using EconomyBot.DAL.Repositories;

namespace EconomyBot
{
    public class Program
    {
        private readonly IServiceProvider _services;
        private readonly DiscordSocketClient _client;
        private readonly ButtonHandler _buttonHandler;

        private readonly DiscordSocketConfig _socketConfig = new()
        {
            GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.GuildMembers,
            AlwaysDownloadUsers = true,
        };

        public Program()
        {

            _services = new ServiceCollection()
                .AddSingleton(_socketConfig)
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordSocketClient>()))
                .AddSingleton<InteractionHandler>()
                .AddSingleton<UserRepository>()
                .AddSingleton<WorkRepository>()
                .AddSingleton<RoleRepository>()
                .BuildServiceProvider();

            _client = _services.GetRequiredService<DiscordSocketClient>();
            _buttonHandler = new ButtonHandler();
        }

        static void Main(string[] args)
            => new Program().RunAsync().GetAwaiter().GetResult();

        public async Task RunAsync()
        {
            _client.Log += LogService.LogAsync; // Подключение логера
            _client.ButtonExecuted += _buttonHandler.MyButtonHandler;

            await _services.GetRequiredService<InteractionHandler>()
                .InitializeAsync();

            await _client.LoginAsync(TokenType.Bot, "MTEyNjgwNzE1NTQ5Mjc4MjE3Mg.GU9Fxi.XDIoxkm259yF1sh03tayJPUyb6uqJ6r0kF3Fu4");
            await _client.StartAsync();


            await Task.Delay(Timeout.Infinite);
        }

        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}