using System.Drawing.Text;

namespace Poker_Game
{
    public partial class Game : Form
    {
        public static Player[] players = new Player[] { new Player(), new Player(), new Player(), new Player() };
        public string[] tableCardArray = new string[5];
        private Round round = new Round();
        private PictureBox[] playerCardImageArray;
        private PictureBox[] tableCardImageArray;
        private Random rand = new Random();
        private int pot;
        private int roundStatus = 0;
        private Color activeColor = Color.Gold;
        private Color notActiveColor = Color.Transparent;

        public Game()
        {
            InitializeComponent();
            playerCardImageArray = new PictureBox[] { cardImage0_P0, cardImage1_P0, cardImage0_P1, cardImage1_P1,
                                                      cardImage0_P2, cardImage1_P2, cardImage0_P3, cardImage1_P3 };
            tableCardImageArray = new PictureBox[] { cardImage0, cardImage1, cardImage2, cardImage3, cardImage4 };
            players[0].bidField = bidFieldP0;
            players[0].balanceField = balanceFieldP0;
            players[1].bidField = bidFieldP1;
            players[1].balanceField = balanceFieldP1;
            players[2].bidField = bidFieldP2;
            players[2].balanceField = balanceFieldP2;
            players[3].bidField = bidFieldP3;
            players[3].balanceField = balanceFieldP3;

            balanceFieldP0.BackColor = activeColor;
            round.dealCards(players, tableCardArray);
            /*showPlayerCards();
            showTableCards(5);*/
            playerCardImageArray[0].Image = Image.FromFile($"Materials\\{players[0].hand[0]}.png");
            playerCardImageArray[1].Image = Image.FromFile($"Materials\\{players[0].hand[1]}.png");
        }

        public void betButton_Click(object sender, EventArgs e)
        {
            raiseBid(0, 100);
            gameRound();
        }

        public void foldButton_Click(object sender, EventArgs e)
        {

        }

        async private void gameRound()
        {
            switchControlsActivity(false);
            balanceFieldP0.BackColor = notActiveColor;

            for (int i = 1; i < 4; i++)
            {
                players[i].balanceField.BackColor = activeColor;
                await Task.Delay(500);
                movePlayer(i);
                players[i].balanceField.BackColor = notActiveColor;
            }

            for (int i = 0; i < 4; i++)
            {
                players[i].bidField.Text = "0";
            }

            roundStatus++;
            switch (roundStatus)
            {
                case 1: showTableCards(3); break;
                case 2: showTableCards(4); break;
                case 3: showTableCards(5); break;
                case 4: 
                    showPlayerCards();
                    players[0].bidField.Text = round.defineCombination(0).ToString();
                    players[0].balanceField.Text = round.combination;
                    players[1].bidField.Text = round.defineCombination(1).ToString();
                    players[1].balanceField.Text = round.combination;
                    players[2].bidField.Text = round.defineCombination(2).ToString();
                    players[2].balanceField.Text = round.combination;
                    players[3].bidField.Text = round.defineCombination(3).ToString();
                    players[3].balanceField.Text = round.combination;
                    break;
            }

            switchControlsActivity(true);
            balanceFieldP0.BackColor = activeColor;
        }

        private void switchControlsActivity(bool isSwitch)
        {
            betButton.Enabled = isSwitch;
            checkButton.Enabled = isSwitch;
            foldButton.Enabled = isSwitch;
        }

        private void movePlayer(int id)
        {
            raiseBid(id, 100);
        }

        private void raiseBid(int playerId, int bid)
        {
            players[playerId].balance -= bid;
            players[playerId].balanceField.Text = players[playerId].balance.ToString();
            players[playerId].bidField.Text = bid.ToString();
            pot += bid;
            potField.Text = pot.ToString();
        }

        private void foldCards(int playerId)
        {
            players[playerId].isActive = false;
        }

        private void showTableCards(int cardQuantity)
        {
            for (int i = 0; i < cardQuantity; i++)
            {
                tableCardImageArray[i].Image = Image.FromFile($"Materials\\{tableCardArray[i]}.png");
            }
        }

        private void showPlayerCards()
        {
            int cardCount = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    playerCardImageArray[cardCount].Image = Image.FromFile($"Materials\\{players[i].hand[j]}.png");
                    cardCount++;
                }
            }
        }
    }
}