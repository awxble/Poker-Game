﻿using System;
using System.DirectoryServices;

namespace Poker_Game
{
    public partial class Game
    {
        public void StartGame() {

        }

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

        private void DefineWinner() { }
    }
}
