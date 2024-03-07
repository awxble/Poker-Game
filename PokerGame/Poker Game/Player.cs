using System;

namespace Poker_Game
{
    public class Player
    {
        public int id;
        public int balance;
        public string[] hand = new string[2];

        public int TakeBalance() { return 0; }

        public Player()
        {
            balance = 1000;
        }
    }
}
