using Discord;
using Discord.Commands;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupAttribute = Discord.Interactions.GroupAttribute;

namespace EconomyBot.BLL.Commands.Groups
{
    [Group("emj", "Group with Interaction commands")]
    public class ReactionGroup : InteractionModuleBase<SocketInteractionContext>
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

        [SlashCommand("no", "no")]
        private async Task no()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736254603410014320/736254688915226709/no.gif",
                "https://cdn.discordapp.com/attachments/736254603410014320/743053003820498964/no.gif",
                "https://cdn.discordapp.com/attachments/736254603410014320/736254674956714104/no.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("👎 Не Согласие")
                .WithDescription($"{guildUser.Username} не очень то и любит")
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

        [SlashCommand("nom", "nom")]
        private async Task nom()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736273366784278558/834833624872124476/nom.gif",
                "https://cdn.discordapp.com/attachments/736273366784278558/736273394412159106/nom.gif",
                "https://cdn.discordapp.com/attachments/736273366784278558/736273472153714719/nom.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🥢 Покормить")
                .WithDescription($"{guildUser.Username} голодный!")
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

        [SlashCommand("nosebleed", "nosebleed")]
        private async Task nosebleed()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736261590508371980/736261620728070174/nosebleed.gif",
                "https://cdn.discordapp.com/attachments/736261590508371980/736261644497190962/nosebleed.gif",
                "https://cdn.discordapp.com/attachments/736261590508371980/736261637320736838/nosebleed.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle(":drop_of_blood: Кровь из носа")
                .WithDescription($"{guildUser.Username} думает что это стрёмно! >.<")
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

        [SlashCommand("pout", "pout")]
        private async Task pout()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/834836041906126869/834836172979044352/pout.gif",
                "https://cdn.discordapp.com/attachments/834836041906126869/834836356278255687/pout.gif",
                "https://cdn.discordapp.com/attachments/834836041906126869/834836298757177404/pout.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("😡 Недовольный")
                .WithDescription($"{guildUser.Username} Бррррр...")
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

        [SlashCommand("run", "run")]
        private async Task run()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736259684763435059/736259754514579537/run.gif",
                "https://cdn.discordapp.com/attachments/736259684763435059/736259922651512865/run.gif",
                "https://cdn.discordapp.com/attachments/736259684763435059/736259730497994792/run.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🏃 Убегает")
                .WithDescription($"{guildUser.Username} бежит домой!")
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

        [SlashCommand("shrug", "shrug")]
        private async Task shrug()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/743231747415867483/743232226140880907/shrug.gif",
                "https://cdn.discordapp.com/attachments/743231747415867483/743232278288924752/shrug.gif",
                "https://cdn.discordapp.com/attachments/743231747415867483/821077491603079198/shrug.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🤷 Хз")
                .WithDescription($"{guildUser.Username} Хз (ツ)_/¯")
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

        [SlashCommand("sip", "sip")]
        private async Task sip()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/761612990784471041/1042439000289452132/sip.gif",
                "https://cdn.discordapp.com/attachments/761612990784471041/761613356704333847/sip.gif",
                "https://cdn.discordapp.com/attachments/761612990784471041/834837478748979270/sip.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("☕ Пить")
                .WithDescription($"{guildUser.Username} пьёт горячий чаёк")
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

        [SlashCommand("sing", "sing")]
        private async Task sing()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/874742187357773844/874742590652706918/sing.gif",
                "https://cdn.discordapp.com/attachments/874742187357773844/874742765756481576/sing.gif",
                "https://cdn.discordapp.com/attachments/874742187357773844/874742322699583538/sing.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🎤 Пой")
                .WithDescription($"{guildUser.Username} поёт! Какой прекрасный голос!")
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

        [SlashCommand("sleep", "sleep")]
        private async Task sleep()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736261025166524498/736261138173526076/sleep.gif",
                "https://cdn.discordapp.com/attachments/736261025166524498/736261165151420486/sleep.gif",
                "https://cdn.discordapp.com/attachments/736261025166524498/834838145089667132/sleep.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("💤 Спит")
                .WithDescription($"{guildUser.Username} сладко спит :3")
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

        [SlashCommand("smile", "smile")]
        private async Task smile()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736256980020101160/834840074671620198/smile.gif",
                "https://cdn.discordapp.com/attachments/736256980020101160/834840391966392330/smile.gif",
                "https://cdn.discordapp.com/attachments/736256980020101160/736257349651660870/smile.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("😄 Счастлив")
                .WithDescription($"{guildUser.Username} прямо сейчас очень счастлив ^^")
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

        [SlashCommand("smug", "smug")]
        private async Task smug()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736262910678007808/736263003573583901/smug.gif",
                "https://cdn.discordapp.com/attachments/736262910678007808/736263014059212880/smug.gif",
                "https://cdn.discordapp.com/attachments/736262910678007808/736262926553579640/smug.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("😏 Самодоволие")
                .WithDescription($"{guildUser.Username} выражает самодоволие")
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

        [SlashCommand("stare", "stare")]
        private async Task stare()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736260687633842216/834843460611604500/stare.gif",
                "https://cdn.discordapp.com/attachments/736260687633842216/834843254322888814/stare.gif",
                "https://cdn.discordapp.com/attachments/736260687633842216/736260930098298931/stare.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("👀 Глазеет")
                .WithDescription($"{guildUser.Username} видит всё...")
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

        [SlashCommand("yawn", "yawn")]
        private async Task yawn()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736262435501113465/736262569668640838/yawn.gif",
                "https://cdn.discordapp.com/attachments/736262435501113465/741228041199681546/yawn.gif",
                "https://cdn.discordapp.com/attachments/736262435501113465/736262468191649873/yawn.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🥱 Зевает")
                .WithDescription($"{guildUser.Username} зевает")
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

        [SlashCommand("yes", "yes")]
        private async Task yes()
        {
            var guildUser = Context.User;
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736254151620820993/736254160902553661/yes.gif",
                "https://cdn.discordapp.com/attachments/736254151620820993/736254166216998912/yes.gif",
                "https://cdn.discordapp.com/attachments/736254151620820993/736254234567376936/yes.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("👍 Согласен")
                .WithDescription($"{guildUser.Username} думает что всё классно!")
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

        [SlashCommand("baka", "baka")]
        private async Task baka(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736271836278423553/736271901420159007/baka.gif",
                "https://cdn.discordapp.com/attachments/736271836278423553/736271894315139123/baka.gif",
                "https://cdn.discordapp.com/attachments/736271836278423553/736271863457775656/baka.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("💢 Бака")
                .WithDescription($"{user.Username} перестань быть бакой!")
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

        [SlashCommand("bite", "bite")]
        private async Task bite(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736272811789779006/737035908699652136/bite.gif",
                "https://cdn.discordapp.com/attachments/736272811789779006/737035754651254834/bite.gif",
                "https://cdn.discordapp.com/attachments/736272811789779006/834489283703734302/bite.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle(":drop_of_blood: Кусь")
                .WithDescription($"{user.Username} вас кусьнул {Context.User.Username}")
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

        [SlashCommand("bonk", "bonk")]
        private async Task bonk(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/826095943748943913/826095979614044180/bonk.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🏏 Bonk")
                .WithDescription($"{user.Username} брысь в секс-тюрьму!")
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

        [SlashCommand("cuddle", "cuddle")]
        private async Task cuddle(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736279549121396816/736279565739229275/cuddle.gif",
                "https://cdn.discordapp.com/attachments/736279549121396816/834499908903501864/cuddle.gif",
                "https://cdn.discordapp.com/attachments/736279549121396816/736279761495785512/cuddle.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("👐 Прижаться")
                .WithDescription($"{Context.User.Username} прижимается!")
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

        [SlashCommand("highfive", "highfive")]
        private async Task highfive(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736274901673181216/736275079192903851/highfive.gif",
                "https://cdn.discordapp.com/attachments/736274901673181216/881895480227938334/highfive.gif",
                "https://cdn.discordapp.com/attachments/736274901673181216/881895480227938334/highfive.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("✋ Дать Пять")
                .WithDescription($"{user.Username} вы получили пятюню от {Context.User.Username}!")
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

        [SlashCommand("hug", "hug")]
        private async Task hug(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736277561373491265/736277610958684220/hug.gif",
                "https://cdn.discordapp.com/attachments/736277561373491265/736277840466542632/hug.gif",
                "https://cdn.discordapp.com/attachments/736277561373491265/834508740031938617/hug.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("👐 Обнимашки")
                .WithDescription($"{user.Username} вас обнял {Context.User.Username}!")
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

        [SlashCommand("kiss", "kiss")]
        private async Task kiss(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736280297171058759/834511717265309746/kiss.gif",
                "https://cdn.discordapp.com/attachments/736280297171058759/736280315030667384/kiss.gif",
                "https://cdn.discordapp.com/attachments/736280297171058759/736280505825361930/kiss.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("💋 Поцеловать")
                .WithDescription($"{user.Username} вас поцеловал {Context.User.Username}!")
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

        [SlashCommand("lapsit", "lapsit")]
        private async Task lapsit(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/969964503330586684/969964770348392448/lapsit.gif",
                "https://cdn.discordapp.com/attachments/969964503330586684/969964810634674177/lapsit.gif",
                "https://cdn.discordapp.com/attachments/969964503330586684/969964638131327017/lapsit.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle(":chair: Сидеть на коленочках")
                .WithDescription($"{user.Username}, {Context.User.Username} сидит на твоих коленях!!")
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

        [SlashCommand("lick", "lick")]
        private async Task lick(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736276719161311264/736276904692416642/lick.gif",
                "https://cdn.discordapp.com/attachments/736276719161311264/736276878918156340/lick.gif",
                "https://cdn.discordapp.com/attachments/736276719161311264/736276848769499206/lick.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("😋 Лизнуть")
                .WithDescription($"{user.Username}, вас лизнул {Context.User.Username}")
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

        [SlashCommand("love", "love")]
        private async Task love(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736277076868595794/736277148159049840/love.gif",
                "https://cdn.discordapp.com/attachments/736277076868595794/736277138906284173/love.gif",
                "https://cdn.discordapp.com/attachments/736277076868595794/736277193751265290/love.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("❤️ Признаться в Любви")
                .WithDescription($"{user.Username}, вам признался в любви {Context.User.Username}")
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

        [SlashCommand("marry", "marry")]
        private async Task marry(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736281363464060979/736281376898154546/marry.gif",
                "https://cdn.discordapp.com/attachments/736281363464060979/736281396355530812/marry.gif",
                "https://cdn.discordapp.com/attachments/736281363464060979/736281405088202782/marry.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("💍 Пожениться")
                .WithDescription($"{user.Username}, вы поженились с {Context.User.Username} Как мило! >-<")
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

        [SlashCommand("massage", "massage")]
        private async Task massage(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736276388226662420/736276400524492950/massage.gif",
                "https://cdn.discordapp.com/attachments/736276388226662420/736276427174969354/massage.gif",
                "https://cdn.discordapp.com/attachments/736276388226662420/736276394828627968/massage.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("💆 Массаж")
                .WithDescription($"{user.Username}, {Context.User.Username} сделал вам массаж!")
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

        [SlashCommand("pat", "pat")]
        private async Task pat(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736275536317382717/736275542193733702/pat.gif",
                "https://cdn.discordapp.com/attachments/736275536317382717/834835123949535252/pat.gif",
                "https://cdn.discordapp.com/attachments/736275536317382717/736275680597377064/pat.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🤚 Погладить")
                .WithDescription($"{user.Username}, вас погладил {Context.User.Username} ")
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

        [SlashCommand("poke", "poke")]
        private async Task poke(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736273767520665610/736273806900985922/poke.gif",
                "https://cdn.discordapp.com/attachments/736273767520665610/834835460034527242/poke.gif",
                "https://cdn.discordapp.com/attachments/736273767520665610/834835519157698560/poke.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("👉 Тыкнуть")
                .WithDescription($"{user.Username}, вас тыкнул {Context.User.Username} ")
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

        [SlashCommand("punch", "punch")]
        private async Task punch(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736270998772383826/834837274155155546/punch.gif",
                "https://cdn.discordapp.com/attachments/736270998772383826/736271092628324392/punch.gif",
                "https://cdn.discordapp.com/attachments/736270998772383826/736271107866493009/punch.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("👊 Ударить")
                .WithDescription($"{user.Username},  вас Ударил {Context.User.Username} ")
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

        [SlashCommand("reward", "reward")]
        private async Task reward(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736276242466078761/885568422241529946/reward.gif",
                "https://cdn.discordapp.com/attachments/736276242466078761/885569060773961880/reward.gif",
                "https://cdn.discordapp.com/attachments/736276242466078761/736276249969950781/reward.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🍓 Наградить")
                .WithDescription($"{user.Username}, Вы сделали что-то великое! В награду, я даю тебе эту клубнику!")
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

        [SlashCommand("slap", "slap")]
        private async Task slap(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736271623098990792/736271694947418152/slap.gif",
                "https://cdn.discordapp.com/attachments/736271623098990792/736271689603612772/slap.gif",
                "https://cdn.discordapp.com/attachments/736271623098990792/736271684645945364/slap.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("👏 Пощёчина")
                .WithDescription($"{user.Username}, дал вам пощёчину {Context.User.Username}!")
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

        [SlashCommand("squish", "squish")]
        private async Task squish(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/955386888624148491/955387448026873876/squish.gif",
                "https://cdn.discordapp.com/attachments/955386888624148491/955387385502400522/squish.gif",
                "https://cdn.discordapp.com/attachments/955386888624148491/955387465257082890/squish.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🍩 Тискать")
                .WithDescription($"{user.Username}, тебя тискает {Context.User.Username}!")
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

        [SlashCommand("steal", "steal")]
        private async Task steal(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736271960065048577/736271967300223079/steal.gif",
                "https://cdn.discordapp.com/attachments/736271960065048577/736272017590059038/steal.gif",
                "https://cdn.discordapp.com/attachments/736271960065048577/736271984941596682/steal.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("❔ Кража")
                .WithDescription($"{user.Username},  украл у  {Context.User.Username}!")
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

        [SlashCommand("throw", "throw")]
        private async Task throwC(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736272093900963923/736272137224060959/throw.gif",
                "https://cdn.discordapp.com/attachments/736272093900963923/860571381597863946/throw.gif",
                "https://cdn.discordapp.com/attachments/736272093900963923/736272109927530566/throw.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("💨 Кинуть что-то")
                .WithDescription($"{user.Username}, что-то кинул в {Context.User.Username}!")
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

        [SlashCommand("tickle", "tickle")]
        private async Task tickle(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736274285764542565/736274332023652482/tickle.gif",
                "https://cdn.discordapp.com/attachments/736274285764542565/736274294211870890/tickle.gif",
                "https://cdn.discordapp.com/attachments/736274285764542565/736274306392260608/tickle.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("🤣 Щекотка")
                .WithDescription($"{user.Username}, вас пощекотал  {Context.User.Username}!")
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

        [SlashCommand("wave", "wave")]
        private async Task wave(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/736274581492465665/736274730012770324/wave.gif",
                "https://cdn.discordapp.com/attachments/736274581492465665/736274631316734064/wave.gif",
                "https://cdn.discordapp.com/attachments/736274581492465665/736274618465386577/wave.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("👋 Махать рукой")
                .WithDescription($"{user.Username}, {Context.User.Username} махает вам рукой!!")
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

        [SlashCommand("yeet", "yeet")]
        private async Task yeet(IUser user)
        {
            var chnl = Context.Channel;

            var urls = new List<string>()
            {
                "https://cdn.discordapp.com/attachments/910944832845905980/910946009486614528/yeet.gif",
                "https://cdn.discordapp.com/attachments/910944832845905980/910945255141023755/yeet.gif",
                "https://cdn.discordapp.com/attachments/910944832845905980/910945543176454214/yeet.gif"
            };

            var random = new Random().Next(0, urls.Count);
            var img = urls[random];

            var embedBuiler = new EmbedBuilder()
                .WithTitle("💨 Швырнуть")
                .WithDescription($"{user.Username}, тебя швырнул {Context.User.Username}")
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
