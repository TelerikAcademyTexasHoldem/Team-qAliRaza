namespace TexasHoldem.AI.IntelligentPlayer
{
    using System;
    using System.Collections.Generic;
    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;
    using TexasHoldem.AI.IntelligentPlayer.Helpers;
    using TexasHoldem.Logic.Extensions;
    partial class IntelligentPlayer : BasePlayer
    {
        private PlayerAction PreflopLogic(Card firstCard, Card secondCard, GetTurnContext context)
        {
            
            var playHand = HandStrengthValuation.PreFlop(this.FirstCard, this.SecondCard);
            if (playHand == CardValuationType.Unplayable)
            {
                if (context.CurrentPot < 15 && context.MoneyLeft > 100)
                {
                    return PlayerAction.CheckOrCall();
                }
                else
                {
                    return PlayerAction.Fold();
                }
            }
            else if (playHand == CardValuationType.NotRecommended)
            {
                if (!context.CanCheck && context.MyMoneyInTheRound <= 500)
                {
                    return PlayerAction.Fold();
                }
            }
            else if (playHand == CardValuationType.Risky)
            {
                if (context.MoneyLeft <= 500 && !context.CanCheck)
                {
                    return PlayerAction.Fold();
                }
                var smallBlindsTimes = RandomProvider.Next(5, 15);
                return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
            }
            else if (playHand == CardValuationType.Recommended)
            {
                var smallBlindsTimes = RandomProvider.Next(10, 25);
                return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
            }

            // default
            return PlayerAction.Fold();
        }
    }
}