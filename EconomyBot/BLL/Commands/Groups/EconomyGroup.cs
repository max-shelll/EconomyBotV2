using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using EconomyBot.DAL.Models;
using EconomyBot.DAL.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyBot.BLL.Commands.Groups
{
    [Group("eco", "Group with economy commands")]
    public class EconomyGroup : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly UserRepository _userRepo;
        private readonly RoleRepository _roleRepo;

        public EconomyGroup(UserRepository userRepo, RoleRepository roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        /*
        * [--------------- Economy Show ---------------]
        */

        [SlashCommand("help", "Show all commands")]
        private async Task Help([Choice("Economy", "eco"), Choice("Work", "work"), Choice("Game", "game")] string choice)
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle("Информация по выбраному разделу")
                .WithColor(Color.Teal)
                .WithCurrentTimestamp();

            switch (choice)
            {
                case "eco":
                    embedBuiler.WithDescription(
                "**/eco log_me** — ``Зарегестрироваться``\n" +
                "**/eco balance** — ``Показать баланс``\n" +
                "**/eco shop** — ``Открыть магазин ролей``\n" +
                "**/eco forbes** — ``Открыть список Forbes``\n" +
                "**/eco buy_role [role]** — ``Покупка роли``");
                    break;
                case "work":
                    embedBuiler.WithDescription(
                "**/work list** — ``информация об работах``\n" +
                "**/work start [name]** — ``устроиться на работу``\n" +
                "**/work info** — ``посмотреть информацию о текущей работе``\n");
                    break;
                case "game":
                    embedBuiler.WithDescription(
                "**/game casino [сумма]** — ``Испытать удачу бросив кубики``\n" +
                "**/game roulette [сумма]** — ``Испытать удачу выбрав цвет``\n" +
                "**/game blackjack [сумма]** — ``Старая добрая игра с крупье, двадцать одно``\n");
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

        [SlashCommand("shop", "Show items in shop")]
        private async Task Shop()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var roles = await _roleRepo.GetRoles();
            var sortedRoles = roles.OrderBy(x => x.cost);

            var embedBuiler = new EmbedBuilder()
            .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
            .WithTitle("Магазин ролей")
            .WithColor(Color.Green)
            .WithThumbnailUrl(Context.Guild.IconUrl)
            .WithCurrentTimestamp();


            var number = 1;
            foreach (var item in sortedRoles)
            {
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Id == item.id);

                embedBuiler.AddField("ᅠ", $"{number}): {role.Mention}\n **cost**: ``{item.cost}`` :coin:");
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

        [SlashCommand("forbes", "Shows the richest server users")]
        private async Task Forbes()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var users = await _userRepo.GetUsers();
            var sortedList = users.OrderByDescending(u => u.money);

            var embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle("Forbes")
                .WithColor(Color.Gold)
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithCurrentTimestamp();

            var number = 1;
            foreach (var user in sortedList)
            {
                if (number <= 9) // Максимание кол-во участников в Forbes
                {
                    if (number == 1)
                        embedBuiler.AddField("________", $":first_place: :small_orange_diamond: <@{user.id}>\n **money**: ``{user.money}`` :coin:");
                    else if (number == 2)
                        embedBuiler.AddField("________", $":second_place: :small_orange_diamond: <@{user.id}>\n **money**: ``{user.money}`` :coin:");
                    else if (number == 3)
                        embedBuiler.AddField("________", $":third_place:  :small_orange_diamond: <@{user.id}>\n **money**: ``{user.money}`` :coin:");
                    else
                        embedBuiler.AddField("________", $"**#**{number} :small_orange_diamond: <@{user.id}>\n **money**: ``{user.money}`` :coin:");
                }
                number += 1;
            }

            await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: embedBuiler.Build());
        }

        [SlashCommand("balance", "Shows your balance")]
        private async Task Balance()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var user = await _userRepo.GetUserById(guildUser.Id);

            if (user == null)
            {
                try
                {
                    await RespondAsync(":x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> :x: **На данный момент вы не зарегистрированы! **\nДля регистрации используйте команду ``/eco log_me``");
                }
                return;
            }

            var embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle("Банковская выписка")
                .WithDescription($":coin: **Ваш текущий баланс** - ``{user.money}``$")
                .WithColor(Color.Green)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build(), ephemeral: true);
            }
            catch
            {
                await chnl.SendMessageAsync($"<@{guildUser.Id}>");
            }
        }

        /*
        * [--------------- Economy Event ---------------]
        */

        [SlashCommand("buy_role", "Buy role from shop")]
        private async Task BuyRole(IRole role)
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var userBd = await _userRepo.GetUserById(guildUser.Id);
            var roleBd = await _roleRepo.GetRoleById(role.Id);

            if (userBd == null || roleBd == null)
            {
                try
                {
                    await RespondAsync($"Нету роли **Name:** ```{role.Name}```\nили :x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Нету роли **Name:** ```{role.Name}```\nили :x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``");
                }
                return;
            }
            else if (userBd.money < roleBd.cost || (userBd.roles != null && userBd.roles.Where(r => r.id == role.Id).First() != null))
            {
                try
                {
                    await RespondAsync($"Вы уже имеете данную роль или недостаточно средств", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Вы уже имеете данную роль или недостаточно средств");
                }
                return;
            }

            var newRole = new Role
            {
                id = roleBd.id,
                name = roleBd.name,
                cost = roleBd.cost
            };

            // Проверка и добавление в пользователя роль
            var discordUserRoleList = userBd.roles;
            var roleForUser = new Role
            {
                id = roleBd.id,
                name = roleBd.name,
                cost = roleBd.cost
            };

            if (discordUserRoleList == null)
            {
                discordUserRoleList = new List<Role>
                {
                    roleForUser
                };
            }
            else
            {
                discordUserRoleList.Add(roleForUser);
            }

            var newUser = new User
            {
                id = userBd.id,
                money = userBd.money -= roleBd.cost,
                work = userBd.work,
                roles = discordUserRoleList
            };

            await _userRepo.UpdateUser(guildUser.Id, newUser);
            await _roleRepo.UpdateRole(role.Id, newRole);

            try
            {
                var user = (SocketGuildUser)guildUser;
                await user.AddRoleAsync(role);

                try
                {
                    await RespondAsync($"**Спасибо за покупку роли** ```{roleBd.name}```", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> **Спасибо за покупку роли** ```{roleBd.name}```");
                }
            }
            catch (Exception ex)
            {
                try
                {
                    await RespondAsync($"Недостаточно прав", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Недостаточно прав");
                }
                Console.WriteLine(ex);
                return;
            }
        }

        [SlashCommand("log_me", "Create bank account")]
        public async Task LoginAccount()
        {
            var user = Context.User;
            var chnl = Context.Channel;

            var userBd = new User { id = user.Id, money = 0, roles = null };
            var tryGetUser = await _userRepo.GetUserById(user.Id);

            if (tryGetUser == null)
            {
                await _userRepo.CreateUser(userBd);
                try
                {
                    await RespondAsync("Вы успешно зарегистрировались!", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{user.Id}> Вы успешно зарегистрировались!");
                }
            }
            else
            {
                try
                {
                    await RespondAsync(":x: **На данный момент вы уже зарегистрированы!**", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{user.Id}> :x: **На данный момент вы уже зарегистрированы!**");
                }
            }
        }
    }
}
