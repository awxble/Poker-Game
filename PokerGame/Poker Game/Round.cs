using System;

namespace Poker_Game
{
    public class Round
    {
        private int pot;
        private enum roundStatus
        {
            Preflop,
            Flop,
            Turn,
            River
        }

        private void CheckEndOfBetting() { }
        private void ChangeActivePlayer() { }
        private void ChangeNewRound() { }
        private void DealCards() { }
    }
}
