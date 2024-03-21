using System;

namespace Poker_Game
{
    public class Player
    {
        public int id;
        public int balance;
        public bool isActive;
        public bool isAllIn;
        public Label balanceField;
        public Label bidField;
        public int combinationValue;
        public string combination;
        public string[] hand = new string[2];

        public Player()
        {
            isActive = true;
            isAllIn = false;
            balance = 1000;
        }
    }
}
