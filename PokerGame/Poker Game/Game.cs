using System;
using System.DirectoryServices;

namespace Poker_Game
{
    public partial class Game : GameForm
    {
        private string[] cards = new string[7];

        public int defineCardValue(string card)
        {
            switch (card[0])
            {
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                case '1': return 10;
                case 'j': return 11;
                case 'q': return 12;
                case 'k': return 13;
                case 'a': return 14;
                default: return 0;
            }
        }

        private int defineCombination(int id)
        {
            int combinationValue = 0;
            int count = 0;
            int temp;

            for (int i = 0; i < 2; i++)
            {
                cards[i] = players[id].hand[i];
            }

            for (int i = 2; i < 7; i++)
            {
                cards[i] = tableCardArray[count];
                count++;
            }

            //high card
            temp = defineCardValue(cards[0]);
            if (temp >= defineCardValue(cards[1])) { combinationValue = temp; return combinationValue; }
            else { combinationValue = defineCardValue(cards[1]); return combinationValue; }
            //pair
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 6 && j == 6) break;
                    if (i == j) j++;
                    if (cards[i][0] == cards[j][0]) return combinationValue;
                }
            }
        }

        private void defineWinner() { }
    }
}
