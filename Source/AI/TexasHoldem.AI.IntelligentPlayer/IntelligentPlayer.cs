namespace TexasHoldem.AI.IntelligentPlayer
{
    using System;
    using System.Collections.Generic;
    using Helpers;
    using Logic;
    using Logic.Cards;
    using Logic.Players;

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
            bool sameCardsSuit = CardsChecker.CheckIfTheCardsSuitIsTheSame(new List<Card>() {firstCard, secondCard});
            bool sameCardsType = CardsChecker.CheckIfTheCardsTypeIsTheSame(new List<Card>() {firstCard, secondCard});

            if (sameCardsSuit)
            {
                return PlayerAction.Raise(8);
            }
            else if (sameCardsType)
            {
                return PlayerAction.Raise(25);
            }
            else if (sameCardsType == true && sameCardsSuit == true)
            {
                return PlayerAction.Raise(33);
            }
            else
            {
                return PlayerAction.CheckOrCall();
            }
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
