using System;
using System.Diagnostics;

namespace Poker_Game
{
    public class Deck
    {
        private string[] cards = { "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "1h", "jh", "qh", "kh", "ah",
                                   "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "1s", "js", "qs", "ks", "as",
                                   "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "1d", "jd", "qd", "kd", "ad",
                                   "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "1c", "jc", "qc", "kc", "ac"};
        public string[] suffledCards = new string[13];
        private Random random = new Random();

        private void Shuffle() 
        {
            for (int i = 0; i < suffledCards.Length; i++)
            {
                while (true)
                {
                    int randomNumber = random.Next(0, 52);
                    if (cards[randomNumber] != "0")
                    {
                        suffledCards[i] = cards[randomNumber];
                        cards[randomNumber] = "0";
                        break;
                    }
                }
            }
        }
    }
}
