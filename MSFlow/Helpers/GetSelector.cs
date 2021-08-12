using MSFlow.Helpers.Resources;
using System;

namespace MSFlow.Helpers
{
    public static class GetSelector
    {
        public static string GetMobileSelectorByName(string name)
        {
            return name switch
            {
                "Plinko" => MainResources.MobileTurboPlinkoButton,
                "Mines" => MainResources.MobileTurboMinesButton,
                "Goal" => MainResources.MobileTurboGoalButton,
                "HiLo" => MainResources.MobileTurboHiloButton,
                "Dice" => MainResources.MobileTurboDiceButton,
                "Mini Roulette" => MainResources.MobileTurboMiniRouletteButton,
                "Dominoes" => MainResources.MobileTableDominoesButton,
                "Bura" => MainResources.MobileTableBuraButton,
                "Backgammon" => MainResources.MobileTableBackgammonButton,
                "Seka" => MainResources.MobileTableSekaButton,
                "Mobile Poker" => MainResources.MobileHeaderNavigationPoker,
                "Play New Poker" => MainResources.MobilePlayPokerButton,
                _ => throw new NotSupportedException("Selector not found"),
            };
        }
    }
}
