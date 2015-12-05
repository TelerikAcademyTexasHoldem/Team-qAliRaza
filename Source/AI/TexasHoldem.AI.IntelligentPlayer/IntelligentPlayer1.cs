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
            if (context.MyMoneyInTheRound != context.MoneyToCall)
            {
                
            }
            var playHand = HandStrengthValuation.PreFlop(this.FirstCard, this.SecondCard);
            if (playHand == CardValuationType.Unplayable)
            {
                if (context.CanCheck)
                {
                    return PlayerAction.CheckOrCall();
                }
                else
                {
                    return PlayerAction.Fold();
                }
            }

            if (playHand == CardValuationType.Risky)
            {
                if (context.MoneyLeft <= 500 && !context.CanCheck)
                {
                    return PlayerAction.Fold();
                }
                var smallBlindsTimes = RandomProvider.Next(1, 4);
                return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
            }

            if (playHand == CardValuationType.Recommended)
            {
                var smallBlindsTimes = RandomProvider.Next(6, 14);
                return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
            }

            if (playHand == CardValuationType.NotRecommended)
            {
                if (!context.CanCheck && context.MyMoneyInTheRound <= 500)
                {
                    return PlayerAction.Fold();
                }
            }

            // default
            return PlayerAction.Fold();
        }
    }
}