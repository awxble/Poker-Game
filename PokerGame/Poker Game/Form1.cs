namespace Poker_Game
{
    public partial class GameForm : Form
    {
        private Player[] players = new Player[] { new Player(), new Player(), new Player(), new Player() };
        private Deck deck = new Deck();
        private PictureBox[] cardImageArray;

        public GameForm()
        {
            InitializeComponent();
            cardImageArray = new PictureBox[] { cardImage0_P0, cardImage1_P0, cardImage0_P1, cardImage1_P1, cardImage0_P2, 
                cardImage1_P2, cardImage0_P3, cardImage1_P3, cardImage0, cardImage1, cardImage2, cardImage3, cardImage4 };

            for (int i = 0; i < 13; i++)
            {
                cardImageArray[i].Image = Image.FromFile($"Materials\\{deck.shuffledCards[i]}.png");
            }
            deck.Shuffle();
        }

        public void betButton_Click(object sender, EventArgs e)
        {
            players[0].balance -= 100;
            balanceFieldP0.Text = players[0].balance.ToString();
            bidFieldP0.Text = (1000 - players[0].balance).ToString();
        }

        private void foldButton_Click(object sender, EventArgs e)
        {

        }
    }
}