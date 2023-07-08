using Discord;
using Discord.Interactions;

namespace EconomyBot.BLL.Commands
{
    public class OtherCommands : InteractionModuleBase<SocketInteractionContext>
    {
        /*
        * [--------------- Reactions [Without user] ---------------]
        */

        [SlashCommand("angry", "angry")]
        private async Task Angry()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736258706383175720/904067905874976818/angry.gif",
                "https://cdn.discordapp.com/attachments/736258706383175720/772196563313360896/angry.gif",
                "https://cdn.discordapp.com/attachments/736258706383175720/736259035447296100/angry.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("💢 Злость")
                .WithDescription($"**{guildUser.Username}** очень злой!")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("awkward", "awkward")]
        private async Task awkward()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736253855339249695/736253858308817007/awkward.gif",
                "https://cdn.discordapp.com/attachments/736253855339249695/736253895185268797/awkward.gif",
                "https://cdn.discordapp.com/attachments/736253855339249695/736253887203377172/awkward.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("😅 Неловкость")
                .WithDescription($"**{guildUser.Username}** чувствует себя неловко uwu")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("beg", "beg")]
        private async Task beg()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/907017776143683614/907018801076391956/beg.gif",
                "https://cdn.discordapp.com/attachments/907017776143683614/907017915247783988/beg.gif",
                "https://cdn.discordapp.com/attachments/907017776143683614/907018623535706172/beg.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🥺 Молить")
                .WithDescription($"Плииииз!")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("blush", "blush")]
        private async Task blush()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736260129418248242/736260165745246278/blush.gif",
                "https://cdn.discordapp.com/attachments/736260129418248242/736260165745246278/blush.gif",
                "https://cdn.discordapp.com/attachments/736260129418248242/736260343310844004/blush.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("😊 Смущается")
                .WithDescription($"Прекрати, ты смущаешь меня >///<")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("bored", "bored")]
        private async Task bored()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/834496715712888863/834497076426702939/bored.gif",
                "https://cdn.discordapp.com/attachments/834496715712888863/834497453180846121/bored.gif",
                "https://cdn.discordapp.com/attachments/834496715712888863/834497162427498586/bored.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🥱 Устал")
                .WithDescription($"**{guildUser.Username}** устал...")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("cry", "cry")]
        private async Task cry()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736255198808375307/736255492841537546/cry.gif",
                "https://cdn.discordapp.com/attachments/736255198808375307/736255442233196584/cry.gif",
                "https://cdn.discordapp.com/attachments/736255198808375307/834499627687477248/cry.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("😭 Грусть")
                .WithDescription($"**{guildUser.Username}** сейчас сильно грустит uwu")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("dab", "dab")]
        private async Task dab()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736253507618865215/736253518100299796/dab.gif",
                "https://cdn.discordapp.com/attachments/736253507618865215/736253511095943269/dab.gif",
                "https://cdn.discordapp.com/attachments/736253507618865215/736253522198396928/dab.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🆒 Дэб")
                .WithDescription($"**{guildUser.Username}** дэббит над хейтерами!")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("dance", "dance")]
        private async Task dance()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736255695296528484/834503187494469652/dance.gif",
                "https://cdn.discordapp.com/attachments/736255695296528484/834503054858387526/dance.gif",
                "https://cdn.discordapp.com/attachments/736255695296528484/881894470084345897/dance.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🕺 Танцы")
                .WithDescription($"**{guildUser.Username}** сейчас в настроение танцевать")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("drink", "drink")]
        private async Task drink()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/860580103284195358/860584699037745152/drink.gif",
                "https://cdn.discordapp.com/attachments/860580103284195358/860583931501084682/drink.gif",
                "https://cdn.discordapp.com/attachments/860580103284195358/860584584902213642/drink.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🍺 Напиток")
                .WithDescription($"Будь здоров!")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("facepalm", "facepalm")]
        private async Task facepalm()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736262744474517584/736262831544074250/facepalm.gif",
                "https://cdn.discordapp.com/attachments/736262744474517584/834504257276477510/facepalm.gif",
                "https://cdn.discordapp.com/attachments/736262744474517584/834504282911932486/facepalm.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🤦 Фэйспалм")
                .WithDescription($"Вам должно быть стыдно!")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("jump", "jump")]
        private async Task jump()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/834509030110003300/834509518033125416/jump.gif",
                "https://cdn.discordapp.com/attachments/834509030110003300/834509413934563328/jump.gif",
                "https://cdn.discordapp.com/attachments/834509030110003300/834509359094169621/jump.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("💨 Прыжок")
                .WithDescription($"{guildUser.Username} прыгает отсюда!")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        [SlashCommand("laugh", "laugh")]
        private async Task laugh()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736261908960903268/839473363210600448/laugh.gif",
                "https://cdn.discordapp.com/attachments/736261908960903268/736261943282892860/laugh.gif",
                "https://cdn.discordapp.com/attachments/736261908960903268/736262141799170140/laugh.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("😆 Смеется")
                .WithDescription($"{guildUser.Username} думает что это весело!")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }

        /*
       * [--------------- Reactions [With user] ---------------]
       */

        [SlashCommand("arrest", "arrest")]
        private async Task arrest(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/992095513073700994/992095681474986025/arrest.gif",
                "https://cdn.discordapp.com/attachments/992095513073700994/992095956130607295/arrest.gif",
                "https://cdn.discordapp.com/attachments/992095513073700994/992095593394622475/arrest.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("👮 Арест")
                .WithDescription($"{user.Username} ты арестован!")
                .WithImageUrl(img)
                .WithColor(Color.Magenta)
                .WithCurrentTimestamp();

            try
            {
                await RespondAsync(embed: embedBuiler.Build());
            }
            catch
            {
                await chnl.SendMessageAsync(embed: embedBuiler.Build());
            }
        }
    }
}
