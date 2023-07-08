using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using EconomyBot.DAL.Models;
using EconomyBot.DAL.Repositories;

namespace EconomyBot.BLL.Commands.Groups
{
    [Group("work", "Group with works commands")]
    public class Workroup : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly UserRepository _userRepo;
        private readonly WorkRepository _workRepo;

        public Workroup(UserRepository userRepo, WorkRepository workRepo)
        {
            _userRepo = userRepo;
            _workRepo = workRepo;
        }

        /*
         * [--------------- Work Show ---------------]
         */

        [SlashCommand("info", "Show your current work")]
        private async Task ShowWorkInfo()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var userBd = await _userRepo.GetUserById(guildUser.Id);

            if (userBd == null || userBd.work == null)
            {
                try
                {
                    await RespondAsync("Вы не работаете!", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Вы не работаете!");
                }

                return;
            }

            var embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle("Информация о работе")
                .WithDescription($"**Название:** ``{userBd.work.name}``\n" +
                $"**Зарплата:** ``{userBd.work.salary}`` :coin:\n" +
                $"**До конца рабочей смены:** ``{userBd.work.workTime} минут``")
                .WithColor(Color.Teal)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build(), ephemeral: true);
            }
            catch
            {
                await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: embedBuiler.Build());
            }
        }

        [SlashCommand("list", "Show all works")]
        private async Task ShowWorkList()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var works = await _workRepo.GetWorks();
            var sortedWorks = works.OrderBy(x => x.workTime);

            var embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle("Список работ :angel: ")
                .WithColor(Color.Green)
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithCurrentTimestamp();

            var number = 1; // Номер работы (просто число для перечисления)
            foreach (var item in sortedWorks)
            {
                embedBuiler.AddField("ᅠ", $"{number}) {item.name}\n **-Зарплата**: ``{item.salary}`` :coin:\n **-Время работы**: ``{item.workTime} минут``");
                number += 1;
            }

            try
            {
                await RespondAsync(embed: embedBuiler.Build(), ephemeral: true);
            }
            catch
            {
                await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: embedBuiler.Build());
            }
        }

        /*
         * [--------------- Work Event ---------------]
         */

        [SlashCommand("start", "Start work")]
        private async Task StartWork(string workName)
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var user = await _userRepo.GetUserById(guildUser.Id);
            var work = await _workRepo.GetWorkByName(workName);

            if (work == null)
            {
                try
                {
                    await RespondAsync("Данной работы нет, перепроверьте правильное написание работы", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Данной работы нет, перепроверьте правильное написание работы");
                }
                return;
            }
            else if (user == null || user.work != null)
            {
                try
                {
                    await RespondAsync("Вы уже на работе, закончите смену прежде чем начинать новую\nили :x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Вы уже на работе, закончите смену прежде чем начинать новую\nили :x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``");
                }
                return;
            }

            var newUser = new User
            {
                id = user.id,
                money = user.money,
                roles = user.roles,
                work = work
            };

            await _userRepo.UpdateUser(guildUser.Id, newUser);

            var embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle("Работа")
                .WithDescription($"**Вы успешно устроились на работу** - ``{workName}``")
                .WithColor(Color.LightGrey)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build(), ephemeral: true);
            }
            catch
            {
                await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: embedBuiler.Build());
            }

            // Запуск работы
            Thread thr = new Thread(() => StartWorking(chnl, guildUser));
            thr.Start();
        }
        private async void StartWorking(ISocketMessageChannel chnl, SocketUser guildUser)
        {
            var user = _userRepo.GetUserById(guildUser.Id).Result;
            var newUser = new User();

            var salary = user.work.salary;

            while (user.work.workTime != 0)
            {
                Thread.Sleep(60000);
                user.work.workTime -= 1;

                newUser = new User
                {
                    id = user.id,
                    money = user.money,
                    roles = user.roles,
                    work = user.work
                };
                await _userRepo.UpdateUser(user.id, newUser);
            }

            newUser = new User
            {
                id = user.id,
                money = user.money += salary,
                roles = user.roles,
                work = null
            };

            await _userRepo.UpdateUser(guildUser.Id, newUser);

            var embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle("Работа")
                .WithDescription($"<@{guildUser.Id}> **Вы завершили работу**\n**Ваша зарплата** - ``{salary}`` :coin:")
                .WithColor(Color.LighterGrey)
                .WithCurrentTimestamp();

            await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: embedBuiler.Build());
        }

    }
}
