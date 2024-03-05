using System;

namespace Poker_Game
{
    public class Player
    {
        public int id;
        public int balance;
        public int[] hand = new int[2];

        public int TakeBalance() { return 0; }

        public Player(int id)
        {
            this.id = id;
            balance = 1000;
        }
    }
}
