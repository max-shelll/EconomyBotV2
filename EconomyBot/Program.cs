using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using EconomyBot.BLL.Services.Handlers;
using EconomyBot.BLL.Services.Logger;
using EconomyBot.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

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
            _client.Ready += Client_Ready;

            await _services.GetRequiredService<InteractionHandler>()
                .InitializeAsync();

            await _client.LoginAsync(TokenType.Bot, "");
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

        public async  Task Client_Ready()
        {
            Thread thr = new Thread(SendMsgs);
            thr.Start();
        }

        private async void SendMsgs()
        {
            long time = 120; // Кд на отправку сообщений в минутах
            var chnl = _client.GetChannel(1061872136412733470) as IMessageChannel; // Id чата куда отправляются сообщения

            var embedBuiler = new EmbedBuilder()
                   .WithTitle("Система")
                   .WithDescription($"У вас есть какие то идеи по улучшению сервера, тогда пишите --> \n<#1072025835336368168>")
                   .WithColor(Color.DarkPurple)
                   .WithCurrentTimestamp();

            while (true)
            {
                while (time != 0)
                {
                    Thread.Sleep(60000);
                    time -= 1;
                }
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
                time = 120;

            }
        }
    }
}