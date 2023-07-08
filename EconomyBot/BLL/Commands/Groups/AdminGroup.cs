using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using EconomyBot.DAL.Models;
using EconomyBot.DAL.Repositories;

namespace EconomyBot.BLL.Commands.Groups
{
    [Group("admin", "Group with admins commands")]
    public class AdminGroup : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly WorkRepository _workRepo;
        private readonly UserRepository _userRepo;
        private readonly RoleRepository _roleRepo;

        public AdminGroup(WorkRepository workRepo, UserRepository userRepo, RoleRepository roleRepo)
        {
            _workRepo = workRepo;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        /*
        * [--------------- Work Admin ---------------]
        */

        [SlashCommand("add_work", "Add work")]
        private async Task AddWork(string workName, long salary, [Summary(description: "Set work time in minutes")] long workTime)
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            if (_workRepo.GetWorkByName(workName).Result != null)
            {
                try
                {
                    await RespondAsync("Данная работа уже добавлена", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Данная работа уже добавлена");
                }
                return;
            }

            var newWork = new DAL.Models.Work
            {
                name = workName,
                salary = salary,
                workTime = workTime,
            };

            await _workRepo.CreateWork(newWork);

            try
            {
                await RespondAsync($"Работа {workName} успешно добавлена", ephemeral: true);
            }
            catch
            {
                await chnl.SendMessageAsync($"<@{guildUser.Id}> Работа {workName} успешно добавлена");
            }
        }

        [SlashCommand("del_work", "Delete work")]
        private async Task DeleteWork(string workName)
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var work = await _workRepo.GetWorkByName(workName);

            if (work == null)
            {
                try
                {
                    await RespondAsync("Данной работы не существует!", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Данной работы не существует!");
                }
                return;
            }

            await _workRepo.DeleteWork(workName);

            var embedBuiler = new EmbedBuilder()
            .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
            .WithTitle("Внутренняя система")
            .WithDescription($"Работа {workName} удалена")
            .WithColor(Color.Green)
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

        /*
        * [--------------- User Admin ---------------]
        */

        [SlashCommand("ban", "Ban user from server")]
        private async Task BanUser(IUser user, string reason, [Summary(description: "Ban user time in days")] int time)
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            await Context.Guild.AddBanAsync(user, time, reason);

            try
            {
                await RespondAsync($"Пользователь {user.Username} забанен на {time}d по причине {reason}", ephemeral: true);
            }
            catch
            {
                await chnl.SendMessageAsync($"<@{guildUser.Id}> Пользователь {user.Username} забанен на {time}d по причине {reason}");
            }
        }

        [SlashCommand("kick", "Kick user from server")]
        private async Task KickUser(SocketGuildUser user, string reason)
        {
            var chnl = Context.Channel;

            await user.KickAsync(reason);

            try
            {
                await RespondAsync($"Пользователь {user.Username} кикнут по причине {reason}", ephemeral: true);
            }
            catch
            {
                await chnl.SendMessageAsync($"Пользователь {user.Username} кикнут по причине {reason}");
            }
        }

        [SlashCommand("mute", "Mute user in server")]
        private async Task MuteUser(SocketGuildUser user, [Summary(description: "Mute user time in minutes")] long time, string reason)
        {
            Thread thr = new Thread(() => MuteStart(Context.Channel, Context.User, user, time, reason));
            thr.Start();
        }
        private async void MuteStart(ISocketMessageChannel chnl, SocketUser guildUser, SocketGuildUser user, long time, string reason)
        {
            await user.AddRoleAsync(1126927385527341176); // Id роли мута

            var embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle("Система")
                .WithDescription($"<@{guildUser.Id}> выдал мут <@{user.Id}> на {time} минут по причине: ``{reason}``")
                .WithColor(Color.LighterGrey)
                .WithCurrentTimestamp();

            await chnl.SendMessageAsync(embed: embedBuiler.Build());

            while (time != 0)
            {
                Thread.Sleep(60000);
                time -= 1;
            }

            await user.RemoveRoleAsync(1126927385527341176); // Id роли мута
            var embedBuilerF = new EmbedBuilder()
              .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
               .WithTitle("Система")
              .WithDescription($"<@{user.Id}> время мута прошло, постарайтесь больше его не получать")
              .WithColor(Color.LighterGrey)
              .WithCurrentTimestamp();

            await chnl.SendMessageAsync(embed: embedBuilerF.Build());
        }

        [SlashCommand("change_balance", "Change user balance")]
        private async Task ChangeUserBalance(IUser user, long count, [Choice("Add", "add"), Choice("Remove", "remove"), Choice("Set", "set")] string choice)
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var userDb = await _userRepo.GetUserById(user.Id);

            var embedBuiler = new EmbedBuilder()
            .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
            .WithTitle("Внутренняя система")
            .WithCurrentTimestamp();

            switch (choice)
            {
                case "add":
                    userDb.money += count;
                    await _userRepo.UpdateUser(userDb.id, userDb);
                    embedBuiler
                        .WithDescription($"<@{user.Id}> добавлено {count} :coin:")
                        .WithColor(Color.Green);
                    break;
                case "remove":
                    userDb.money -= count;
                    await _userRepo.UpdateUser(userDb.id, userDb);
                    embedBuiler
                        .WithDescription($"<@{user.Id}> убавлено {count} :coin:")
                        .WithColor(Color.DarkRed);
                    break;
                case "set":
                    userDb.money = count;
                    await _userRepo.UpdateUser(userDb.id, userDb);
                    embedBuiler
                        .WithDescription($"<@{user.Id}> установлено {count} :coin:")
                        .WithColor(Color.Gold);
                    break;
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
        * [--------------- Role Admin ---------------]
        */

        [SlashCommand("add_role", "Add role to shop")]
        private async Task AddRoleToShop(IRole role, long cost)
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            if (_roleRepo.GetRoleById(role.Id).Result != null)
            {
                try
                {
                    await RespondAsync("Данная роль уже добавлена", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Данная роль уже добавлена");
                }
                return;
            }

            var newRole = new Role
            {
                id = role.Id,
                name = role.Name,
                cost = cost
            };

            await _roleRepo.CreateRole(newRole);

            try
            {
                await RespondAsync($"Роль {role.Name} успешно добавлена", ephemeral: true);
            }
            catch
            {
                await chnl.SendMessageAsync($"<@{guildUser.Id}> Роль {role.Name} успешна добавлена");
            }
        }

        [SlashCommand("del_role", "Delete role from shop")]
        private async Task DeleteRole(IRole role)
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var roleDb = await _roleRepo.GetRoleById(role.Id);

            if (roleDb == null)
            {
                try
                {
                    await RespondAsync("Данной роли не существует!", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Данной роли не существует!");
                }
                return;
            }

            await _roleRepo.DeleteRole(role.Id);

            var embedBuiler = new EmbedBuilder()
            .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
            .WithTitle("Внутренняя система")
            .WithDescription($"Роль {role.Mention} удалена")
            .WithColor(Color.Green)
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
    }
}
