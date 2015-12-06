﻿namespace TexasHoldem.AI.IntelligentPlayer.Helpers
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
            else if (IsThreeOfAKind(cards, communityCards))
            {
                return HandRankType.ThreeOfAKind;
            }
            else if (IsStraight(cards, communityCards))
            {
                return HandRankType.Straight;
            }
            else if (IsFlush(cards, communityCards))
            {
                return HandRankType.Flush;
            }
            else if (IsFullHouse(cards, communityCards))
            {
                
            }
            else if (IsFourOfAKind(cards, communityCards))
            {
                
            }
            else
            {
                return HandRankType.HighCard;
            }

            return HandRankType.HighCard;
        }

        private static bool IsFourOfAKind(List<Card> cards, IReadOnlyCollection<Card> communityCards)
        {
            throw new NotImplementedException();
        }

        private static bool IsFullHouse(List<Card> cards, IReadOnlyCollection<Card> communityCards)
        {
            throw new NotImplementedException();
        }

        private static bool IsFlush(List<Card> cards, IReadOnlyCollection<Card> communityCards)
        {
            bool isFlush = false;
            int foundFromTheSameSuit;
            if (cards[0].Suit == cards[1].Suit)
            {
                foundFromTheSameSuit = 2;
                for (int i = 0; i < communityCards.Count; i++)
                {
                    if (foundFromTheSameSuit == 5)
                    {
                        isFlush = true;
                        break;
                    }
                    if (cards[0].Suit == communityCards.ElementAt(i).Suit)
                    {
                        ++foundFromTheSameSuit;
                    }
                }
            }

            if (isFlush)
            {
                foundFromTheSameSuit = 0;
                return true;
            }

            //Checks with first card TODO: REMOVE REPETITIONS
            foundFromTheSameSuit = 1;
            for (int i = 0; i < communityCards.Count; i++)
            {
                if (foundFromTheSameSuit == 5)
                {
                    isFlush = true;
                    break;
                }
                if (cards[0].Suit == communityCards.ElementAt(i).Suit)
                {
                    ++foundFromTheSameSuit;
                }
            }

            if (isFlush)
            {
                foundFromTheSameSuit = 0;
                return true;
            }

            //Checks with second card TODO: REMOVE REPETITIONS
            foundFromTheSameSuit = 1;
            for (int i = 0; i < communityCards.Count; i++)
            {
                if (foundFromTheSameSuit == 5)
                {
                    isFlush = true;
                    break;
                }
                if (cards[1].Suit == communityCards.ElementAt(i).Suit)
                {
                    ++foundFromTheSameSuit;
                }
            }

            return isFlush;
        }

        private static bool IsStraight(List<Card> cards, IReadOnlyCollection<Card> communityCards)
        {
            // TODO: To implement it..
            return false;
            //bool isStraight = false;
            //List<Card> currentCards = new List<Card>()
            //{
            //    cards[0],
            //    cards[1]
            //};
            //foreach (var communityCard in communityCards)
            //{
            //    currentCards.Add(communityCard);
            //}

            //int equalCards = 0;
            //for (int i = 1; i <= currentCards.Count; i++)
            //{
            //    if ((int)currentCards[i-1].Type - 1 == (int)currentCards[i].Type - 1)
            //    {
            //        equalCards += 2;
            //        for (int j = i; j < communityCards.Count; j++)
            //        {

            //        }
            //    }
            //}

            //return isStraight;
        }

        private static bool IsThreeOfAKind(List<Card> ownCards, IReadOnlyCollection<Card> communityCards)
        {
            bool isThreeOfAKind = false;
            bool hasToBreak = false;
            if (ownCards[0].Type == ownCards[1].Type)
            {
                for (int i = 0; i < communityCards.Count; i++)
                {
                    if (communityCards.ElementAt(i).Type == ownCards[0].Type)
                    {
                        isThreeOfAKind = true;
                        break;
                    }
                }
            }

            if (isThreeOfAKind)
            {
                return true;
            }

            for (int i = 0; i < ownCards.Count; i++)
            {
                if (hasToBreak)
                {
                    break;
                }
                int num = 1;
                for (int j = 0; j < communityCards.Count; j++)
                {
                    if (num == 2)
                    {
                        isThreeOfAKind = true;
                        hasToBreak = true;
                        break;
                    }
                    if (communityCards.ElementAt(j).Type == ownCards[i].Type)
                    {
                        num++;
                    }
                }
            }

            return isThreeOfAKind;
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
