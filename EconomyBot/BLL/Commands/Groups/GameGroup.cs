using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using EconomyBot.DAL.Models;
using EconomyBot.DAL.Repositories;

namespace EconomyBot.BLL.Commands.Groups
{
    [Group("game", "Group with games")]
    public class GameGroup : InteractionModuleBase<SocketInteractionContext>
    {
        private static UserRepository _userRepo;

        private static int rout_number;
        private static long rout_count;
        private static SocketUser rout_guildUser;
        private static bool rout_disableBtn;
        private static IMessageChannel rout_chnl;

        private static EmbedBuilder _embedGame;
        private static SocketUser guildUser;
        private static Dictionary<string, int> cards = new();
        private static bool isDisableBtn;
        private static Dictionary<string, int> userCards;
        private static Dictionary<string, int> croupCards;
        private static int userCount;
        private static int croupCount;
        private static long playCount;

        private static IMessageChannel chnl;

        public GameGroup(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [SlashCommand("casino", "Original casino")]
        private async Task Casino([Summary(description: "the money you play with")] long count)
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var random = new Random();
            var embedBuiler = new EmbedBuilder();

            int number = random.Next(0, 100);
            var userBd = await _userRepo.GetUserById(guildUser.Id);

            int multiplier = 0; // Множитель
            long winMoney = userBd.money;

            if (userBd.money < count || userBd == null)
            {
                try
                {
                    await RespondAsync("Недостаточно средств\nили :x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Недостаточно средств\nили :x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``");
                }
                return;
            }

            if (number > 30 && number <= 100)
            {
                winMoney = userBd.money - count;

                embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle(":game_die: Казино")
                .WithDescription($"К сожалению, вы все проиграли [-{count} :coin:] \n" + $"Множитель: x{multiplier}")
                .WithColor(Color.DarkBlue)
                .WithCurrentTimestamp();
            }
            else if (number > 17 && number <= 30) // 30%
            {
                winMoney = userBd.money - count / 2;

                embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle(":game_die: Казино")
                .WithDescription($"К сожалению, вы проиграли половину [-{count / 2} :coin:] \n" + $"Множитель: x{multiplier}")
                .WithColor(Color.DarkBlue)
                .WithCurrentTimestamp();
            }
            else if (number > 4 && number <= 17)
            {
                winMoney = userBd.money + count * 2;

                embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle(":game_die: Казино")
                .WithDescription($":partying_face: Поздравляем, вы выиграли [{count * 2} :coin:] \n" + $"Множитель: x{multiplier}")
                .WithColor(Color.Gold)
                .WithCurrentTimestamp();
            }
            else if (number <= 4)
            {
                winMoney = userBd.money + count * 5;

                embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle(":game_die: Казино")
                .WithDescription($":partying_face: Поздравляем, вы выиграли [:coin: {count * 5}] \n" + $"Множитель: x{multiplier}")
                .WithColor(Color.Gold)
                .WithCurrentTimestamp();
            }

            var newUser = new User
            {
                id = userBd.id,
                money = winMoney,
                roles = userBd.roles,
                work = userBd.work
            };
            await _userRepo.UpdateUser(guildUser.Id, newUser);

            try
            {
                await RespondAsync(embed: embedBuiler.Build(), ephemeral: true);
            }
            catch
            {
                await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: embedBuiler.Build());
            }
        }

        [SlashCommand("roulette", "Original roulette")]
        private async Task Roulette([Summary(description: "the money you play with")] long count)
        {
            rout_guildUser = Context.User;
            rout_chnl = Context.Channel;

            var random = new Random();
            rout_number = random.Next(1, 26);
            rout_count = count;

            var user = await _userRepo.GetUserById(rout_guildUser.Id);

            if (user == null || user.money < count)
            {
                try
                {
                    await RespondAsync("Недостаточно средств\nили :x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``", ephemeral: true);
                }
                catch
                {
                    await rout_chnl.SendMessageAsync($"<@{rout_guildUser.Id}> Недостаточно средств\nили :x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``");
                }
                return;
            }

            var btnRoulette = new ComponentBuilder()
                .WithButton("1-12", "roulette_red", style: ButtonStyle.Danger)
                .WithButton("13", "roulette_green", style: ButtonStyle.Success)
                .WithButton("14-26", "roulette_black", style: ButtonStyle.Secondary);

            var embedBuiler = new EmbedBuilder()
                .WithAuthor(rout_guildUser.ToString(), rout_guildUser.GetAvatarUrl() ?? rout_guildUser.GetDefaultAvatarUrl())
                .WithTitle(":slot_machine:  Рулетка")
                .WithDescription($"Для создания ставки выберите цвет")
                .WithColor(Color.DarkerGrey)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build(), components: btnRoulette.Build(), ephemeral: true);
            }
            catch
            {
                await rout_chnl.SendMessageAsync($"<@{rout_guildUser.Id}>", embed: embedBuiler.Build(), components: btnRoulette.Build());
            }
        }

        public static async Task RedBtn()
        {
            var user = await _userRepo.GetUserById(rout_guildUser.Id);

            if (!rout_disableBtn)
            {
                if (rout_number <= 12)
                {
                    var embedBuiler = new EmbedBuilder()
                    .WithAuthor(rout_guildUser.ToString(), rout_guildUser.GetAvatarUrl() ?? rout_guildUser.GetDefaultAvatarUrl())
                    .WithTitle(":slot_machine:  Рулетка")
                    .WithDescription($"<@{rout_guildUser.Id}> На стол выпадает :red_circle:\n Поздравляем вы виграли x2")
                    .WithColor(Color.DarkerGrey)
                    .WithCurrentTimestamp();

                    var newUser = new User
                    {
                        id = user.id,
                        money = user.money + (rout_count * 2),
                        roles = user.roles,
                        work = user.work
                    };

                    await _userRepo.UpdateUser(rout_guildUser.Id, newUser);

                    await rout_chnl.SendMessageAsync(embed: embedBuiler.Build());
                }
                else
                {
                    var embedBuiler = new EmbedBuilder()
                    .WithAuthor(rout_guildUser.ToString(), rout_guildUser.GetAvatarUrl() ?? rout_guildUser.GetDefaultAvatarUrl())
                    .WithTitle(":slot_machine:  Рулетка")
                    .WithDescription($"<@{rout_guildUser.Id}> Увы, но вы проиграли")
                    .WithColor(Color.DarkerGrey)
                    .WithCurrentTimestamp();

                    var newUser = new User
                    {
                        id = user.id,
                        money = user.money - rout_count,
                        roles = user.roles,
                        work = user.work
                    };

                    await _userRepo.UpdateUser(rout_guildUser.Id, newUser);

                    await rout_chnl.SendMessageAsync(embed: embedBuiler.Build());
                }
                rout_disableBtn = true;
            }
            return;
        }

        public static async Task GreenBtn()
        {
            var user = await _userRepo.GetUserById(rout_guildUser.Id);

            if (!rout_disableBtn)
            {
                if (rout_number == 13)
                {
                    var embedBuiler = new EmbedBuilder()
                    .WithAuthor(rout_guildUser.ToString(), rout_guildUser.GetAvatarUrl() ?? rout_guildUser.GetDefaultAvatarUrl())
                    .WithTitle(":slot_machine:  Рулетка")
                    .WithDescription($"<@{rout_guildUser.Id}> На стол выпадает :green_circle:\n Поздравляем вы виграли x5")
                    .WithColor(Color.DarkerGrey)
                    .WithCurrentTimestamp();

                    var newUser = new User
                    {
                        id = user.id,
                        money = user.money + (rout_count * 5),
                        roles = user.roles,
                        work = user.work
                    };

                    await _userRepo.UpdateUser(rout_guildUser.Id, newUser);

                    await rout_chnl.SendMessageAsync(embed: embedBuiler.Build());
                }
                else
                {
                    var embedBuiler = new EmbedBuilder()
                    .WithAuthor(rout_guildUser.ToString(), rout_guildUser.GetAvatarUrl() ?? rout_guildUser.GetDefaultAvatarUrl())
                    .WithTitle(":slot_machine:  Рулетка")
                    .WithDescription($"<@{rout_guildUser.Id}> Увы, но вы проиграли")
                    .WithColor(Color.DarkerGrey)
                    .WithCurrentTimestamp();

                    var newUser = new User
                    {
                        id = user.id,
                        money = user.money - rout_count,
                        roles = user.roles,
                        work = user.work
                    };

                    await _userRepo.UpdateUser(rout_guildUser.Id, newUser);

                    await rout_chnl.SendMessageAsync(embed: embedBuiler.Build());
                }
                rout_disableBtn = true;
            }
            return;
        }

        public static async Task BlackBtn()
        {
            var user = await _userRepo.GetUserById(rout_guildUser.Id);

            if (!rout_disableBtn)
            {
                if (rout_number >= 14)
                {
                    var embedBuiler = new EmbedBuilder()
                    .WithAuthor(rout_guildUser.ToString(), rout_guildUser.GetAvatarUrl() ?? rout_guildUser.GetDefaultAvatarUrl())
                    .WithTitle(":slot_machine:  Рулетка")
                    .WithDescription($"<@{rout_guildUser.Id}> На стол выпадает :black_circle: \n Поздравляем вы виграли x2")
                    .WithColor(Color.DarkerGrey)
                    .WithCurrentTimestamp();

                    var newUser = new User
                    {
                        id = user.id,
                        money = user.money + (rout_count * 2),
                        roles = user.roles,
                        work = user.work
                    };

                    await _userRepo.UpdateUser(rout_guildUser.Id, newUser);

                    await rout_chnl.SendMessageAsync(embed: embedBuiler.Build());
                }
                else
                {
                    var embedBuiler = new EmbedBuilder()
                    .WithAuthor(rout_guildUser.ToString(), rout_guildUser.GetAvatarUrl() ?? rout_guildUser.GetDefaultAvatarUrl())
                    .WithTitle(":slot_machine:  Рулетка")
                    .WithDescription($"<@{rout_guildUser.Id}> Увы, но вы проиграли")
                    .WithColor(Color.DarkerGrey)
                    .WithCurrentTimestamp();

                    var newUser = new User
                    {
                        id = user.id,
                        money = user.money - rout_count,
                        roles = user.roles,
                        work = user.work
                    };

                    await _userRepo.UpdateUser(rout_guildUser.Id, newUser);

                    await rout_chnl.SendMessageAsync(embed: embedBuiler.Build());
                }
                rout_disableBtn = true;
            }
            return;
        }

        [SlashCommand("black-jack", "Original blackJack")]
        private async Task BlackJackCommand([Summary(description: "The money you play with")] long money)
        {
            guildUser = Context.User;
            isDisableBtn = false;
            userCards = new Dictionary<string, int>();
            croupCards = new Dictionary<string, int>();
            userCount = 0;
            croupCount = 0;

            playCount = money;
            var user = await _userRepo.GetUserById(guildUser.Id);

            chnl = Context.Channel;

            if (user.money < playCount || user == null)
            {
                try
                {
                    await RespondAsync("Недостаточно средств\nили вы :x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``", ephemeral: true);
                }
                catch
                {
                    await chnl.SendMessageAsync($"<@{guildUser.Id}> Недостаточно средств\nили вы :x: **На данный момент вы не зарегистрированы!**\nДля регистрации используйте команду ``/eco log_me``");
                }
                return;
            }

            if (cards.Count == 0)
            {
                cards.Add(":diamonds: 2-е Бубны", 2);
                cards.Add(":diamonds: 3 Бубны", 3);
                cards.Add(":diamonds: 4 Бубны", 4);
                cards.Add(":diamonds: 5 Бубн", 5);
                cards.Add(":diamonds: 6 Бубн", 6);
                cards.Add(":diamonds: 7 Бубн", 7);
                cards.Add(":diamonds: 8 Бубн", 8);
                cards.Add(":diamonds: 9 Бубн", 9);
                cards.Add(":diamonds: 10 Бубн", 10);

                cards.Add(":clubs: 2-е Крести", 2);
                cards.Add(":clubs: 3 Крести", 3);
                cards.Add(":clubs: 4 Крести", 4);
                cards.Add(":clubs: 5 Крести", 5);
                cards.Add(":clubs: 6 Крести", 6);
                cards.Add(":clubs: 7 Крести", 7);
                cards.Add(":clubs: 8 Крести", 8);
                cards.Add(":clubs: 9 Крести", 9);
                cards.Add(":clubs: 10 Крести", 10);

                cards.Add(":hearts: 2 Сердеца", 2);
                cards.Add(":hearts: 3 Сердец", 3);
                cards.Add(":hearts: 4 Сердец", 4);
                cards.Add(":hearts: 5 Сердец", 5);
                cards.Add(":hearts: 6 Сердец", 6);
                cards.Add(":hearts: 7 Сердец", 7);
                cards.Add(":hearts: 8 Сердец", 8);
                cards.Add(":hearts: 9 Сердец", 9);
                cards.Add(":hearts: 10 Сердец", 10);

                cards.Add(":spades: 2-е Пики", 2);
                cards.Add(":spades: 3 Пик", 3);
                cards.Add(":spades: 4 Пик", 4);
                cards.Add(":spades: 5 Пик", 5);
                cards.Add(":spades: 6 Пик", 6);
                cards.Add(":spades: 7 Пик", 7);
                cards.Add(":spades: 8 Пик", 8);
                cards.Add(":spades: 9 Пик", 9);
                cards.Add(":spades: 10 Пик", 10);

                cards.Add(":cowboy: Валет Бубн", 10);
                cards.Add(":cowboy: Валет Крестей", 10);
                cards.Add(":cowboy: Валет Сердец", 10);
                cards.Add(":cowboy: Валет Пик", 10);

                cards.Add(":person_with_crown: Король Бубн", 10);
                cards.Add(":princess: Королева Бубн", 10);
                cards.Add(":person_with_crown: Король Крестей", 10);
                cards.Add(":princess: Королева Крестей", 10);
                cards.Add(":person_with_crown: Король Сердец", 10);
                cards.Add(":princess: Королева Сердец", 10);
                cards.Add(":person_with_crown: Король Пик", 10);
                cards.Add(":princess: Королева Пик", 10);


                cards.Add(":flower_playing_cards: Туз Бубн", 11);
                cards.Add(":flower_playing_cards: Туз Крестей", 11);
                cards.Add(":flower_playing_cards: Туз Сердец", 11);
                cards.Add(":flower_playing_cards: Туз Пик", 11);
            }

            var btnBlackJack = new ComponentBuilder()
               .WithButton("Стоп", "blackjack_stop", style: ButtonStyle.Danger)
               .WithButton("Еще", "blackjack_keep", style: ButtonStyle.Success)
               .WithButton("Удвоить", "blackjack_x2", style: ButtonStyle.Primary);

            var embedBuiler = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle(":jigsaw: Блэкджек")
                .WithDescription($"Добрый день дамы и господа, ставим ставки и начинаем игру")
                .WithColor(Color.DarkerGrey)
                .WithCurrentTimestamp();

            _embedGame = new EmbedBuilder()
                .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                .WithTitle(":jigsaw: Блэкджек игра")
                .WithDescription($"Ваша картаᅠᅠᅠᅠᅠКарта крупье")
                .WithColor(Color.DarkerGrey);

            try
            {
                await RespondAsync(embed: embedBuiler.Build(), components: btnBlackJack.Build(), ephemeral: true);
            }
            catch
            {
                await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: embedBuiler.Build(), components: btnBlackJack.Build());
            }
        }

        public static async Task StopCard()
        {
            if (!isDisableBtn && croupCount != 0)
            {
                if (await CheckScores() == true)
                    return;

                var user = await _userRepo.GetUserById(guildUser.Id);

                while (croupCount < 17 && userCount != 21 && croupCount != 21)
                {
                    if (await CheckScores() == true)
                        return;

                    var cropNum = RandomCard();

                    var croupCardKey = cards.Keys.ElementAt(cropNum);
                    var croupCardValue = cards.Values.ElementAt(cropNum);

                    croupCards.Add(croupCardKey, croupCardValue);
                    croupCount += cards.Values.ElementAt(cropNum);
                    cards.Remove(croupCardKey);

                    if (await CheckScores() == true)
                        return;

                    _embedGame.AddField(croupCardKey.ToString(), "ᅠ", inline: true);
                    _embedGame.WithDescription("Крупье добирает карты..");
                    _embedGame.WithFooter($"Ваш счет: {userCount}   ᅠᅠᅠᅠ    Счет крупье: {croupCount}");
                    await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: _embedGame.Build());
                    _embedGame.Fields.Clear();

                    if (await CheckScores() == true)
                        return;
                }
                if (croupCount > userCount)
                {
                    var newUser = new User
                    {
                        id = user.id,
                        money = user.money - playCount,
                        roles = user.roles,
                        work = user.work
                    };
                    await _userRepo.UpdateUser(guildUser.Id, newUser);

                    _embedGame.AddField("Вы проиграли, крупье выиграл", $"Ваше кол-во очков {userCount} vs Кол-во очков крупье {croupCount}");
                    await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: _embedGame.Build());
                    userCards = null;
                    croupCards = null;
                    isDisableBtn = true;
                    return;
                }
                else if (croupCount < userCount)
                {
                    var newUser = new User
                    {
                        id = user.id,
                        money = user.money + (playCount * 2),
                        roles = user.roles,
                        work = user.work
                    };
                    await _userRepo.UpdateUser(guildUser.Id, newUser);

                    _embedGame.AddField("Вы выиграли, крупье проиграл", $"Ваше кол-во очков {userCount} vs Кол-во очков крупье {croupCount}");
                    await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: _embedGame.Build());
                    userCards = null;
                    croupCards = null;
                    isDisableBtn = true;
                    return;
                }
                else if (croupCount == userCount)
                {
                    _embedGame.AddField("Ничья", $"Ваше кол-во очков {userCount} vs Кол-во очков крупье {croupCount}");
                    await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: _embedGame.Build());
                    userCards = null;
                    croupCards = null;
                    isDisableBtn = true;
                    return;
                }

                if (await CheckScores() == true)
                    return;
                userCount = 0;
                croupCount = 0;
                userCards = null;
                croupCards = null;
                isDisableBtn = true;
            }
            return;
        }

        public static async Task KeepCard()
        {

            if (!isDisableBtn)
            {

                if (userCount != 21 || userCount < 21 || userCards != null)
                {
                    var userNum = RandomCard();
                    var cropNum = RandomCard();

                    var userCardKey = cards.Keys.ElementAt(userNum);
                    var userCardValue = cards.Values.ElementAt(userNum);

                    if (await CheckScores() == true)
                        return;

                    var croupCardKey = cards.Keys.ElementAt(cropNum);
                    var croupCardValue = cards.Values.ElementAt(cropNum);

                    userCards.Add(userCardKey, userCardValue);
                    userCount += cards.Values.ElementAt(userNum);
                    cards.Remove(userCardKey);
                    _embedGame.AddField(userCardKey.ToString(), "ᅠ", inline: true);

                    if (await CheckScores() == true)
                        return;

                    if (croupCards != null)
                    {
                        croupCards.Add(croupCardKey, croupCardValue);
                        croupCount += cards.Values.ElementAt(cropNum);
                        cards.Remove(croupCardKey);
                        _embedGame.WithFooter($"Ваш счет: {userCount}   ᅠᅠᅠᅠ    Счет крупье: {croupCount}");
                    }
                    _embedGame.AddField(croupCardKey.ToString(), "ᅠ", inline: true);

                    if (await CheckScores() == true)
                        return;

                    await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: _embedGame.Build());
                    _embedGame.Fields.Clear();
                }
            }
            return;
        }

        public static async Task AddMoney()
        {
            if (!isDisableBtn && _userRepo != null && guildUser != null)
            {
                var user = await _userRepo.GetUserById(guildUser.Id);

                if (user.money < playCount * 2)
                {
                    var embedBuiler = new EmbedBuilder()
                    .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                    .WithTitle(":jigsaw: Блэкджек")
                    .WithDescription($"<@{guildUser.Id}> У вас недостаточно средст чтобы удвоить")
                    .WithColor(Color.DarkerGrey)
                    .WithCurrentTimestamp();

                    await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: embedBuiler.Build());
                }
                else
                {
                    playCount *= 2;

                    var embedBuiler = new EmbedBuilder()
                    .WithAuthor(guildUser.ToString(), guildUser.GetAvatarUrl() ?? guildUser.GetDefaultAvatarUrl())
                    .WithTitle(":jigsaw: Блэкджек")
                    .WithDescription($"<@{guildUser.Id}> Вы удвоили вашу ставку")
                    .WithColor(Color.DarkerGrey)
                    .WithCurrentTimestamp();

                    await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: embedBuiler.Build());
                }
            }
        }

        private static int RandomCard()
        {
            var random = new Random();
            return random.Next(0, cards.Count);
        }

        private static async Task<bool> CheckScores()
        {
            var user = await _userRepo.GetUserById(guildUser.Id);

            if (userCount > 21 || croupCount == 21)
            {
                var newUser = new User
                {
                    id = user.id,
                    money = user.money - playCount,
                    roles = user.roles,
                    work = user.work
                };
                await _userRepo.UpdateUser(guildUser.Id, newUser);

                _embedGame.AddField("Вы проиграли, крупье выиграл", $"Ваше кол-во очков {userCount} vs Кол-во очков крупье {croupCount}");
                await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: _embedGame.Build());
                userCards = null;
                croupCards = null;
                isDisableBtn = true;
                return true;
            }
            else if (croupCount > 21 || userCount == 21)
            {
                var newUser = new User
                {
                    id = user.id,
                    money = user.money + (playCount * 2),
                    roles = user.roles,
                    work = user.work
                };
                await _userRepo.UpdateUser(guildUser.Id, newUser);

                _embedGame.AddField("Вы выиграли, крупье проиграл", $"Ваше кол-во очков {userCount} vs Кол-во очков крупье {croupCount}");
                await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: _embedGame.Build());
                userCards = null;
                croupCards = null;
                isDisableBtn = true;
                return true;
            }
            else if (userCount == 21 && croupCount == 21)
            {
                _embedGame.AddField("Ничья", $"Ваше кол-во очков {userCount} vs Кол-во очков крупье {croupCount}");
                await chnl.SendMessageAsync($"<@{guildUser.Id}>", embed: _embedGame.Build());
                userCards = null;
                croupCards = null;
                isDisableBtn = true;
                return true;
            }
            else
            {
                return false;
            }
            return false;

        }
    }
}

