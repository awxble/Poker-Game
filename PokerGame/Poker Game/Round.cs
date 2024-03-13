using Microsoft.VisualBasic;
using System;
using System.Collections.Immutable;
using System.DirectoryServices;
using System.Reflection;

namespace Poker_Game
{
    public class Round
    {
        private Dictionary<string, int> cardValues = new Dictionary<string, int>()
        {
            {"2", 1}, {"3", 2}, {"4", 3}, {"5", 4}, {"6", 5}, {"7", 6}, {"8", 7},
            {"9", 8}, {"1", 9}, {"j", 10}, {"q", 11}, {"k", 12}, {"a", 13}
        };
        private Deck deck = new Deck();

        private string[] cards = new string[7];
        private int lastStraightCardValue = 0;
        private int firstFlushCardValue = 0;
        private int combinationValue = 0;
        public string combination = "";

        public void dealCards(Player[] players, string[] tableCardArray)
        {
            int countCard = 0;

            deck.Shuffle();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    players[i].hand[j] = deck.shuffledCards[countCard];
                    countCard++;
                }
            }

            countCard = 8;

            for (int i = 0; i < 5; i++)
            {
                tableCardArray[i] = deck.shuffledCards[countCard];
                countCard++;
            }
        }

        public void defineCombination(int id, Player[] players)
        {
            addCardsToArray(id);
            Dictionary<string, int> repeatedCards;
            repeatedCards = findRepeatedCards(cards);
            addCardsToArray(id);
            var firstCard = repeatedCards.FirstOrDefault();
            var secondCard = repeatedCards.Skip(1).FirstOrDefault();

            //high card
            combinationValue = cardValues[cards[0][0].ToString()];
            for (int i = 0; i < 6; i++)
            {
                if (combinationValue < cardValues[cards[i + 1][0].ToString()])
                {
                    combinationValue = cardValues[cards[i + 1][0].ToString()];
                }
            }
            combination = "High Card";
            int kicker = combinationValue;
            //pair
            if (firstCard.Value == 2)
            {
                combinationValue = 13;
                combinationValue += cardValues[firstCard.Key];
                combinationValue += kicker;
                combination = "One Pair";
            }
            //two pairs
            if (firstCard.Value == 2 && secondCard.Value == 2)
            {
                combinationValue = 39;
                combinationValue += cardValues[firstCard.Key];
                combinationValue += kicker;
                combination = "Two Pair";
            }
            //three of a kind
            if (firstCard.Value == 3)
            {
                combinationValue = 65;
                combinationValue += cardValues[firstCard.Key];
                combinationValue += kicker;
                combination = "Three Of A Kind";
            }
            //straight
            if (hasStraight(cards))
            {
                combinationValue = 91;
                combinationValue += lastStraightCardValue;
                combination = "Straight";
            }
            //flush
            if (hasFlush(cards))
            {
                combinationValue = 104;
                combinationValue += firstFlushCardValue;
                combination = "Flush";
            }
            //full house
            if (firstCard.Value == 3 && secondCard.Value >= 2)
            {
                combinationValue = 117;
                combinationValue += cardValues[firstCard.Key];
                combination = "Full House";
            }
            //four of a kind
            if (firstCard.Value == 4)
            {
                combinationValue = 130;
                combinationValue += cardValues[firstCard.Key];
                combination = "Four Of A Kind";
            }
            //straight flush
            if (hasStraight(cards) && hasFlush(cards))
            {
                combinationValue = 144;
                combination = "Straight Flush";
            }
            //royal flesh
            if (hasStraight(cards) && hasFlush(cards) && firstFlushCardValue == 13)
            {
                combinationValue = 145;
                combination = "Royal Flesh";
            }

            players[id].combination = combination;
            players[id].combinationValue = combinationValue;
        }

        Dictionary<string, int> findRepeatedCards(string[] strings)
        {
            Dictionary<string, int> stringCounts = new Dictionary<string, int>();
            for (int i = 0; i < strings.Length; i++)
            {
                if (!string.IsNullOrEmpty(strings[i]))
                {
                    strings[i] = strings[i][0].ToString();
                }
            }

            foreach (string str in strings)
            {
                if (stringCounts.ContainsKey(str))
                {
                    stringCounts[str]++;
                }
                else
                {
                    stringCounts[str] = 1;
                }
            }

            return stringCounts.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        bool hasStraight(string[] cards)
        {
            int[] cardsRanks = new int[cards.Length];

            for (int i = 0; i < cards.Length; i++)
            {
                cardsRanks[i] = cardValues[cards[i][0].ToString()];
            }

            Array.Sort(cardsRanks);

            for (int i = 0; i <= cards.Length - 5; i++)
            {
                if (cardsRanks[i] == cardsRanks[i + 1] - 1 &&
                    cardsRanks[i + 1] == cardsRanks[i + 2] - 1 &&
                    cardsRanks[i + 2] == cardsRanks[i + 3] - 1 &&
                    cardsRanks[i + 3] == cardsRanks[i + 4] - 1 )
                {
                    lastStraightCardValue = cardsRanks[i + 4];
                    return true;
                }
            }

            return false;
        }

        bool hasFlush(string[] cards)
        {
            int count = 0;
            int highCard = cardValues[cards[0][0].ToString()];
            int temp;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (cards[i][1] == cards[j][1])
                    {
                        temp = cardValues[cards[j][0].ToString()];
                        if (temp < highCard) highCard = temp;
                        count++;
                    }
                }
                if (count >= 5)
                {
                    firstFlushCardValue = highCard;
                    return true;
                }
                count = 0;
                highCard = 0;
            }

            return false;
        }

        public void addCardsToArray(int id)
        {
            int count = 8;

            switch (id)
            {
                case 0:
                    cards[0] = deck.shuffledCards[0];
                    cards[1] = deck.shuffledCards[1];
                    break;
                case 1:
                    cards[0] = deck.shuffledCards[2];
                    cards[1] = deck.shuffledCards[3];
                    break;
                case 2:
                    cards[0] = deck.shuffledCards[4];
                    cards[1] = deck.shuffledCards[5];
                    break;
                case 3:
                    cards[0] = deck.shuffledCards[6];
                    cards[1] = deck.shuffledCards[7];
                    break;
            }

            for (int i = 2; i < 7; i++)
            {
                cards[i] = deck.shuffledCards[count];
                count++;
            }
        }

        //private void defineWinner() { }
    }
}