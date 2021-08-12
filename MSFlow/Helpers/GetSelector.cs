using MSFlow.Helpers.Resources;
using System;

namespace MSFlow.Helpers
{
    public static class GetSelector
    {
        public static string GetMobileSelectorByName(string name)
        {
            switch (name)
            {
                case "Plinko":
                    return MainResources.MobileTurboPlinkoButton;
                case "Mines":
                    return MainResources.MobileTurboMinesButton;
                case "Goal":
                    return MainResources.MobileTurboGoalButton;
                case "HiLo":
                    return MainResources.MobileTurboHiloButton;
                case "Dice":
                    return MainResources.MobileTurboDiceButton;
                case "Mini Roulette":
                    return MainResources.MobileTurboMiniRouletteButton;
                case "Dominoes":
                    return MainResources.MobileTableDominoesButton;
                case "Bura":
                    return MainResources.MobileTableBuraButton;
                case "Backgammon":
                    return MainResources.MobileTableBackgammonButton;
                case "Seka":
                    return MainResources.MobileTableSekaButton;
                default:
                    throw new NotSupportedException("Selector not found");
            }
        }
    }
}
