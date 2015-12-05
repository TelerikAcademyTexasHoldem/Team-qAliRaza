namespace TexasHoldem.AI.IntelligentPlayer.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            else if (AreTwoPairs(cards, communityCards))
            {
                return HandRankType.TwoPairs;
            }
            else
            {
                return HandRankType.HighCard;
            }

            return HandRankType.HighCard;
        }

        private static bool AreTwoPairs(List<Card> ownCards, IReadOnlyCollection<Card> communityCards)
        {
            int pairs = 0;
            if (ownCards[0].Type == ownCards[1].Type)
            {
                ++pairs;
                bool hasToBreak = false;
                for (int i = 0; i < communityCards.Count; i++)
                {
                    if (hasToBreak)
                    {
                        break;
                    }
                    for (int j = i; j < communityCards.Count; j++)
                    {
                        if (communityCards.ElementAt(i).Type == communityCards.ElementAt(j).Type)
                        {
                            ++pairs;
                            hasToBreak = true;
                            break;
                        }
                    }
                }
            }

            if (pairs == 2)
            {
                return true;
            }
            else
            {
                pairs = 0;
            }

            for (int i = 0; i < ownCards.Count; i++)
            {
                for (int j = 0; j < communityCards.Count; j++)
                {
                    if(ownCards[i].Type == communityCards.ElementAt(j).Type)
                    {
                        ++pairs;
                        break;
                    }
                }
            }

            if (pairs == 2)
            {
                return true;
            }
            else
            {
                pairs = 0;
            }
            bool hasToBreakLast = false;
            for (int i = 0; i < ownCards.Count; i++)
            {
                if (hasToBreakLast)
                {
                    break;
                }
                for (int j = 0; j < communityCards.Count; j++)
                {
                    if (ownCards[i].Type == communityCards.ElementAt(j).Type)
                    {
                        ++pairs;
                        hasToBreakLast = true;
                        break;
                    }
                }
            }
            hasToBreakLast = false;
            for (int i = 0; i < communityCards.Count; i++)
            {
                if (hasToBreakLast)
                {
                    break;
                }
                for (int j = i; j < communityCards.Count; j++)
                {
                    if (communityCards.ElementAt(i).Type == communityCards.ElementAt(j).Type)
                    {
                        ++pairs;
                        hasToBreakLast = true;
                        break;
                    }
                }
            }

            if (pairs == 2)
            {
                return true;
            }
            return false;
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
