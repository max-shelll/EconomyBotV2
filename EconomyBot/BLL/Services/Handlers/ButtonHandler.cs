using Discord.WebSocket;
using EconomyBot.BLL.Commands.Groups;

namespace EconomyBot.BLL.Services.Handlers
{
    public class ButtonHandler
    {
        public async Task MyButtonHandler(SocketMessageComponent component)
        {
            switch (component.Data.CustomId)
            {
                case "roulette_red":
                    await GameGroup.RedBtn();
                    break;
                case "roulette_green":
                    await GameGroup.GreenBtn();
                    break;
                case "roulette_black":
                    await GameGroup.BlackBtn();
                    break;
                case "blackjack_stop":
                    await GameGroup.StopCard();
                    break;
                case "blackjack_keep":
                    await GameGroup.KeepCard();
                    break;
                case "blackjack_x2":
                    await GameGroup.AddMoney();
                    break;
            }
        }
    }
}
