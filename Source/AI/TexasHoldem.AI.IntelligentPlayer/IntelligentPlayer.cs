namespace TexasHoldem.AI.IntelligentPlayer
{
    using System;
    using System.Collections.Generic;
    using Logic;
    using Logic.Cards;
    using Logic.Players;
    using TexasHoldem.AI.IntelligentPlayer.Helpers;
    using TexasHoldem.Logic.Extensions;

    public class IntelligentPlayer : BasePlayer
    {
        public override string Name { get; }
        public override PlayerAction GetTurn(GetTurnContext context)
        {
            Card firstCard = this.FirstCard;
            Card secondCard = this.SecondCard;

            if (context.RoundType == GameRoundType.PreFlop)
            {
                return preflopLogic(firstCard, secondCard, context);
            }
            else if (context.RoundType == GameRoundType.Flop)
            {
                return flopLogic(firstCard, secondCard, context);
            }
            else if (context.RoundType == GameRoundType.Turn)
            {
                return turnLogic(firstCard, secondCard, context);
            }
            else if (context.RoundType == GameRoundType.River)
            {
                return riverLogic(firstCard, secondCard, context);
            }

            return PlayerAction.Fold();
        }

        private PlayerAction preflopLogic(Card firstCard, Card secondCard, GetTurnContext context)
        {
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
                var smallBlindsTimes = RandomProvider.Next(1, 5);
                return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
            }

            if (playHand == CardValuationType.Recommended)
            {
                var smallBlindsTimes = RandomProvider.Next(6, 14);
                return PlayerAction.Raise(context.SmallBlind * smallBlindsTimes);
            }
            return PlayerAction.Fold();
        }

        private PlayerAction flopLogic(Card firstCard, Card secondCard, GetTurnContext context)
        {

            return PlayerAction.Fold();
        }
        private PlayerAction turnLogic(Card firstCard, Card secondCard, GetTurnContext context)
        {

            return PlayerAction.Fold();
        }
        private PlayerAction riverLogic(Card firstCard, Card secondCard, GetTurnContext context)
        {

            return PlayerAction.Fold();
        }
    }
}
