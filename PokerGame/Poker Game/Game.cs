using System.ComponentModel.Design.Serialization;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Poker_Game
{
    public partial class Game : Form
    {
        public static Player[] players = new Player[] { new Player(), new Player(), new Player(), new Player() };
        public string[] tableCardArray = new string[5];
        private Round round = new Round();
        private PictureBox[] playerCardImageArray;
        private PictureBox[] tableCardImageArray;
        private Label[] bidFields;
        private Label[] balanceFields;
        private List<int> winners = new List<int>();
        private int pot;
        private int roundStatus = 0;
        private int delayBotMove = 300;
        private Color activeColor = Color.Gold;
        private Color notActiveColor = Color.Transparent;

        private enum gameStage{
            Preflop,
            Flop,
            Turn,
            River,
            ShowDown
        }

        public Game()
        {
            InitializeComponent();
            playerCardImageArray = new PictureBox[] { cardImage0_P0, cardImage1_P0, cardImage0_P1, cardImage1_P1,
                                                      cardImage0_P2, cardImage1_P2, cardImage0_P3, cardImage1_P3 };
            tableCardImageArray = new PictureBox[] { cardImage0, cardImage1, cardImage2, cardImage3, cardImage4 };
            bidFields = new Label[] { bidFieldP0, bidFieldP1, bidFieldP2, bidFieldP3 };
            balanceFields = new Label[] { balanceFieldP0, balanceFieldP1, balanceFieldP2, balanceFieldP3 };
            for (int i = 0; i < 4; i++)
            {
                players[i].bidField = bidFields[i];
                players[i].balanceField = balanceFields[i];
            }

            gameRound(gameStage.Preflop);
            roundStatus++;
        }

        public void betButton_Click(object sender, EventArgs e)
        {
            raiseBid(0, 100);


            gameRound((gameStage)roundStatus);
            roundStatus++;
        }

        public void foldButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        async private void gameRound(gameStage stage)
        {
            switch (stage)
            {
                case gameStage.Preflop:
                    balanceFieldP0.BackColor = activeColor;
                    round.dealCards(players, tableCardArray);
                    showPlayerCards(1);
                    showTableCards(0);
                    break;
                case gameStage.Flop:
                    botMove();
                    await Task.Delay(delayBotMove * 3);
                    showTableCards(3);
                    break;
                case gameStage.Turn:
                    botMove();
                    await Task.Delay(delayBotMove * 3);
                    showTableCards(4);
                    break;
                case gameStage.River:
                    botMove();
                    await Task.Delay(delayBotMove * 3);
                    showTableCards(5);
                    break;
                case gameStage.ShowDown:
                    botMove();
                    await Task.Delay(delayBotMove * 3 + 100);
                    showPlayerCards(4);
                    defineWinner();
                    await Task.Delay(4000);
                    clearBidFileds();
                    distributionPot();
                    reloadFields();
                    roundStatus = 0;
                    gameRound(gameStage.Preflop);
                    roundStatus++;
                    break;
                default:
                    break;
            }
        }

        async private void botMove()
        {
            switchControlsActivity(false);
            balanceFieldP0.BackColor = notActiveColor;

            for (int i = 1; i < 4; i++)
            {
                players[i].balanceField.BackColor = activeColor;
                await Task.Delay(delayBotMove);
                raiseBid(i, 100);
                players[i].balanceField.BackColor = notActiveColor;
            }

            clearBidFileds();
            switchControlsActivity(true);
            balanceFieldP0.BackColor = activeColor;
        }

        private static void clearBidFileds()
        {
            for (int i = 0; i < 4; i++)
            {
                players[i].bidField.Text = "0";
            }
        }

        private void defineWinner()
        {
            int[] scores = new int[4];

            for (int i = 0; i < 4; i++)
            {
                round.defineCombination(i, players);
                scores[i] = players[i].combinationValue;
            }

            for (int i = 0; i < 4; i++)
            {
                if (scores.Max() == scores[i])
                {
                    winners.Add(i);
                }
            }

            for (int i = 0; i < winners.Count; i++)
            {
                players[winners[i]].bidField.BackColor = Color.LightGreen;
            }

            for (int i = 0; i < 4; i++)
            {
                players[i].bidField.Text = players[i].combination;
            }

            scores = new int[4];
        }

        private void distributionPot()
        {
            for (int i = 0; i < winners.Count; i++)
            {
                players[winners[i]].balance += pot / winners.Count;
            }

            winners.Clear();
            pot = 0;
        }

        private void reloadFields()
        {
            for (int i = 0; i < 4; i++)
            {
                players[i].balanceField.Text = players[i].balance.ToString();
                players[i].bidField.BackColor = Color.Transparent;
            }

            potField.Text = pot.ToString();
        }

        private void switchControlsActivity(bool isSwitch)
        {
            betButton.Enabled = isSwitch;
            checkButton.Enabled = isSwitch;
            foldButton.Enabled = isSwitch;
        }

        private void raiseBid(int playerId, int bid)
        {
            players[playerId].balance -= bid;
            players[playerId].bidField.Text = bid.ToString();
            pot += bid;
            reloadFields();
        }

        private void foldCards(int playerId)
        {
            players[playerId].isActive = false;
        }

        private void showTableCards(int cardQuantity)
        {
            
            for (int i = 0; i < 5; i++)
            {
                tableCardImageArray[i].Image = Image.FromFile($"Materials\\backCard.png");
            }
            
            for (int i = 0; i < cardQuantity; i++)
            {
                tableCardImageArray[i].Image = Image.FromFile($"Materials\\{tableCardArray[i]}.png");
            }
        }

        private void showPlayerCards(int playersNumber)
        {
            int cardCount = 0;

            for (int i = 0; i < playersNumber; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    playerCardImageArray[cardCount].Image = Image.FromFile($"Materials\\{players[i].hand[j]}.png");
                    cardCount++;
                }
            }

            if (playersNumber == 1)
            {
                for (int i = 2; i < 8; i++)
                {
                    playerCardImageArray[i].Image = Image.FromFile($"Materials\\backCard.png");
                }
            }
        }
    }
}