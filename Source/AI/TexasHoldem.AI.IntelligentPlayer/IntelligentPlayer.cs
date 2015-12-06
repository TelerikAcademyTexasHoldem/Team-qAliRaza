namespace TexasHoldem.AI.IntelligentPlayer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Logic;
    using Logic.Cards;
    using Logic.Players;
    using TexasHoldem.AI.IntelligentPlayer.Helpers;
    using TexasHoldem.Logic.Extensions;

    public partial class IntelligentPlayer : BasePlayer
    {
        public override string Name { get; } = "IntelligentPlayer." + Guid.NewGuid();

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
                return FlopLogic(firstCard, secondCard, context);
            }
            else if (context.RoundType == GameRoundType.River)
            {
                return FlopLogic(firstCard, secondCard, context);
            }

            return PlayerAction.Fold();
        }

        private PlayerAction FlopLogic(Card firstCard, Card secondCard, GetTurnContext context)
        {
            var playHand = HandStrengthValuation.PreFlop(this.FirstCard, this.SecondCard);
            var handRank = HandChecker.CheckHand(firstCard, secondCard, CommunityCards);

            // TODO: Change raise values
            if (handRank == HandRankType.HighCard)
            {
                return PlayerAction.CheckOrCall();
            }
            else if (handRank == HandRankType.Pair)
            {
                return PlayerAction.Raise(RandomProvider.Next(2,6));
            }
            else if (handRank == HandRankType.TwoPairs)
            {
                return PlayerAction.Raise(RandomProvider.Next(5,11));
            }
            else if (handRank == HandRankType.ThreeOfAKind)
            {
                return PlayerAction.Raise(RandomProvider.Next(8,20));
            }
            else if (handRank == HandRankType.Straight)
            {
                return PlayerAction.Raise(RandomProvider.Next(10,23));
            }
            else if (handRank == HandRankType.Flush)
            {
                return PlayerAction.Raise(RandomProvider.Next(11, 25));
            }
            else if (handRank == HandRankType.FullHouse)
            {
                return PlayerAction.Raise(RandomProvider.Next(13, 26));
            }
            else if (handRank == HandRankType.FourOfAKind)
            {
                return PlayerAction.Raise(RandomProvider.Next(14, 26));
            }

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
