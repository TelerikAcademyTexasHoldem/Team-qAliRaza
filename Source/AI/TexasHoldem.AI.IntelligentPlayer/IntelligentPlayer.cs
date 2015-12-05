namespace TexasHoldem.AI.IntelligentPlayer
{
    using System;
    using System.Collections.Generic;
    using Logic;
    using Logic.Cards;
    using Logic.Players;
    using TexasHoldem.AI.IntelligentPlayer.Helpers;
    using TexasHoldem.Logic.Extensions;

    public partial class IntelligentPlayer : BasePlayer
    {
        public override string Name { get; }

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            Card firstCard = this.FirstCard;
            Card secondCard = this.SecondCard;

            if (context.RoundType == GameRoundType.PreFlop)
            {
                return PreflopLogic(firstCard, secondCard, context);
            }
            else if (context.RoundType == GameRoundType.Flop)
            {
                return FlopLogic(firstCard, secondCard, context);
            }
            else if (context.RoundType == GameRoundType.Turn)
            {
                return TurnLogic(firstCard, secondCard, context);
            }
            else if (context.RoundType == GameRoundType.River)
            {
                return RiverLogic(firstCard, secondCard, context);
            }

            return PlayerAction.Fold();
        }

        private PlayerAction FlopLogic(Card firstCard, Card secondCard, GetTurnContext context)
        {

            // default
            return PlayerAction.CheckOrCall();
        }

        private PlayerAction TurnLogic(Card firstCard, Card secondCard, GetTurnContext context)
        {
            // default
            return PlayerAction.CheckOrCall();
        }

        private PlayerAction RiverLogic(Card firstCard, Card secondCard, GetTurnContext context)
        {
            // default
            return PlayerAction.CheckOrCall();
        }
        private int HandDefiner(Card firstCard, Card secondCard, IReadOnlyCollection<Card> communityCards)
        {
            return 0;
        }
    }
}
