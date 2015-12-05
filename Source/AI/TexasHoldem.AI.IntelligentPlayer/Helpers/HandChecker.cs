namespace TexasHoldem.AI.IntelligentPlayer.Helpers
{
    using System;
    using System.Collections.Generic;
    using Logic;
    using Logic.Cards;

    public static class HandChecker
    {
        public static HandRankType CheckHand(Card firstCard, Card secondCard, IReadOnlyCollection<Card> communityCards)
        {
            List<Card> cards = new List<Card>()
            {
                firstCard,
                secondCard
            };

            //foreach (var communityCard in communityCards)
            //{
            //    cards.Add(communityCard);
            //}

            if (IsOnePair(cards, communityCards))
            {
                return HandRankType.Pair;
            }
            else
            {
                return HandRankType.HighCard;
            }

            return HandRankType.HighCard;
        }

        private static bool IsOnePair(List<Card> ownCards, IReadOnlyCollection<Card> communityCards)
        {
            bool isThereOnePair = false;
            if (ownCards[0].Type == ownCards[1].Type)
            {
                return true;
            }

            bool hasToBreak = false;
            for (int i = 0; i < ownCards.Count; i++)
            {
                if (hasToBreak)
                {
                    break;
                }
                foreach (var communityCard in communityCards)
                {
                    if (communityCard.Type == ownCards[i].Type)
                    {
                        isThereOnePair = true;
                        hasToBreak = true;
                        break;
                    }
                }
            }
            return isThereOnePair;
        }

    }
}
