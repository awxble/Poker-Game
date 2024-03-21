using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Tracing;
using System.DirectoryServices;
using System.Drawing.Text;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Poker_Game
{
    public partial class Game : Form
    {
        public static Player[] players = new Player[] { new Player(), new Player(), new Player(), new Player() };
        public string[] tableCardArray = new string[5];
        private Round round = new Round();
        private Random random = new Random(DateTime.Now.Millisecond);
        private PictureBox[] playerCardImageArray;
        private PictureBox[] tableCardImageArray;
        private PictureBox[] moveImageArray;
        private Label[] bidFields;
        private Label[] balanceFields;
        private List<int> winners = new List<int>();
        private List<int> bids = new List<int>() { 0, 0, 0, 0 };
        private int pot;
        private int roundStatus = 0;
        private int delayBotMove = 1000;
        private Color activeColor = Color.Gold;
        private Color notActiveColor = Color.Transparent;

        private void Log(string message)
        {
            textBoxLogs.AppendText(message + Environment.NewLine);
        }

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
            moveImageArray = new PictureBox[] { moveImageP0, moveImageP1, moveImageP2, moveImageP3 };
            for (int i = 0; i < 4; i++)
            {
                players[i].bidField = bidFields[i];
                players[i].balanceField = balanceFields[i];
            }

            gameRound(gameStage.Preflop);
        }

        public void betButton_Click(object sender, EventArgs e)
        {
            if (trackBar.Visible)
            {
                trackBar.Visible = false;
                raiseField.Visible = false;
                callField.Visible = false;
                clearStatusFields();
                moveImageArray[0].Image = Image.FromFile($"Materials\\raiseStatus.png");
                raiseBid(0, Convert.ToInt32(raiseField.Text));
                gameRound((gameStage)roundStatus);
            }
            else
            {
                trackBar.Visible = true;
                raiseField.Visible = true;
                if (bids.Max() >= players[0].balance) trackBar.Minimum = players[0].balance;
                else trackBar.Minimum = bids.Max();
                trackBar.Maximum = players[0].balance;
                raiseField.Text = trackBar.Value.ToString();
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            raiseField.Text = trackBar.Value.ToString();
        }

        private void raiseBid(int id, int bid)
        {
            
            if (players[id].balance > bid) { }
            else 
            {
                bid = players[id].balance; 
                players[id].isAllIn = true; 
                players[id].isActive = false;
            }

            players[id].balance -= bid;
            players[id].bidField.Text = (bids[id] + bid).ToString();
            pot += bid;
            bids[id] = bids[id] + bid;

            reloadBalanceFileds();
            for (int i = 0; i < 4; i++)
            {
                if (!players[i].isActive) bids[i] = bids.Max();
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            trackBar.Visible = false;
            raiseField.Visible = false;
            callField.Visible = false;
            check(0);
            gameRound((gameStage)roundStatus);
        }
        
        private void check(int id)
        {
            raiseBid(id, bids.Max() - bids[id]);
            moveImageArray[id].Image = Image.FromFile($"Materials\\checkStatus.png");
        }

        public void foldButton_Click(object sender, EventArgs e)
        {
            trackBar.Visible = false;
            raiseField.Visible = false;
            callField.Visible = false;
            foldCards(0);
            gameRound((gameStage)roundStatus);
        }

        public void foldCards(int id)
        {
            moveImageArray[id].Image = Image.FromFile($"Materials\\foldStatus.png");
            players[id].isActive = false;
            bids[id] = bids.Max();
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
                    roundStatus++;
                    break;
                case gameStage.Flop:
                    await botMove();
                    if (bids.All(x => x == bids[0]))
                    {
                        showTableCards(3);
                        clearStatusFields();
                        clearBidFileds();
                        roundStatus++;
                    }
                    break;
                case gameStage.Turn:
                    await botMove();
                    if (bids.All(x => x == bids[0]))
                    {
                        showTableCards(4);
                        clearStatusFields();
                        clearBidFileds();
                        roundStatus++;
                    }
                    break;
                case gameStage.River:
                    await botMove();
                    if (bids.All(x => x == bids[0]))
                    {
                        showTableCards(5);
                        clearStatusFields();
                        clearBidFileds();
                        roundStatus++;
                    }
                    break;
                case gameStage.ShowDown:
                    await botMove();
                    if (bids.All(x => x == bids[0]))
                    {
                        Log("Зашли в ШД");
                        showPlayerCards(4);
                        clearStatusFields();
                        clearBidFileds();
                        defineWinner();
                        await Task.Delay(4000);
                        clearBidFileds();
                        distributionPot();
                        reloadBalanceFileds();
                        roundStatus = 0;

                        if (players[0].balance == 0)
                        {
                            MessageBox.Show("Вы проиграли :(", "В следущий раз повезёт!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                        }
                        else if (players[0].balance == 4000)
                        {
                            MessageBox.Show("Вы победили!", "Поздравляем!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                        }

                        for (int i = 0; i < 4; i++)
                        {
                            if (players[i].balance == 0)
                            {
                                moveImageArray[i].Image = Image.FromFile($"Materials\\foldStatus.png");
                                players[i].isAllIn = false;
                                removePlayer(i);
                            }
                            else
                            {
                                moveImageArray[i].Image = null;
                                players[i].isActive = true;
                                players[i].isAllIn = false;
                            }
                        }

                        gameRound(gameStage.Preflop);
                    }
                    break;
                default:
                    break;
            }

            if (players[0].isActive) switchControlsActivity(true);
        }

        async private Task botMove()
        {
            int randNum;

            switchControlsActivity(false);
            balanceFieldP0.BackColor = notActiveColor;

            for (int i = 1; i < 4; i++)
            {
                if (players[i].isActive)
                {
                    players[i].balanceField.BackColor = activeColor;
                    await Task.Delay(delayBotMove);
                    randNum = random.Next(0, 101);
                    if (bids[i - 1] > bids[i])
                    {
                        if (randNum < 10) foldCards(i);
                        else if (randNum < 90) check(i);
                        else
                        {
                            raiseBid(i, bids[i - 1] + random.Next(1, 2) * 50);
                            clearStatusFields();
                            moveImageArray[i].Image = Image.FromFile($"Materials\\raiseStatus.png");
                        }
                    }
                    else
                    {
                        if (randNum < 85) check(i);
                        else
                        {
                            raiseBid(i, bids[i - 1] + random.Next(1, 2) * 50);
                            clearStatusFields();
                            moveImageArray[i].Image = Image.FromFile($"Materials\\raiseStatus.png");
                        }
                    }
                    
                    players[i].balanceField.BackColor = notActiveColor;
                }
            }

            await Task.Delay(delayBotMove);
            callField.Text = (bids.Max() - bids[0]).ToString();
            if (bids.Max() - bids[0] > 0) callField.Visible = true;
            if (players[0].isActive) balanceFieldP0.BackColor = activeColor;
            else
            {
                Log("Вызван " + (gameStage)roundStatus);
                gameRound((gameStage)roundStatus);
            }
        }

        private void removePlayer(int id)
        {
            playerCardImageArray[id * 2].Visible = false;
            playerCardImageArray[id * 2 + 1].Visible = false;
            players[id].balanceField.Visible = false;
            players[id].bidField.Visible = false;
        }

        private void clearBidFileds()
        {
            for (int i = 0; i < 4; i++)
            {
                players[i].bidField.Text = "0";
                bids[i] = 0;
            }
        }

        private void clearStatusFields()
        {
            for (int i = 0; i < 4; i++)
            {
                if (players[i].isActive)
                {
                    moveImageArray[i].Image = null;
                }
            }
        }

        private void defineWinner()
        {
            int[] scores = new int[4];

            for (int i = 0; i < 4; i++)
            {
                if (players[i].isActive || players[i].isAllIn)
                {
                    round.defineCombination(i, players);
                    scores[i] = players[i].combinationValue;
                }
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
                players[i].combination = "0";
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

        private void reloadBalanceFileds()
        {
            for (int i = 0; i < 4; i++)
            {
                players[i].balanceField.Text = players[i].balance.ToString();
                players[i].bidField.BackColor = Color.Transparent;
                if (players[i].balance == 0) players[i].balanceField.Text = "All In!";
            }

            potField.Text = pot.ToString();
        }

        private void switchControlsActivity(bool isSwitch)
        {
            betButton.Enabled = isSwitch;
            checkButton.Enabled = isSwitch;
            foldButton.Enabled = isSwitch;
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