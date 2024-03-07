namespace Poker_Game
{
    public partial class GameForm : Form
    {
        private Game game = new Game();
        private Deck deck = new Deck();
        private Random random = new Random();
        private string previousCard = "";
        private int randomNumber;
        private int score = 0;

        public GameForm()
        {
            InitializeComponent();
            randomNumber = random.Next(0, 52);
            TestBox.Image = Image.FromFile($"Materials\\{deck.cards[randomNumber]}.png");
        }



        private void betButton_Click(object sender, EventArgs e)
        {
            previousCard = deck.cards[randomNumber];
            randomNumber = random.Next(0, 52);
            TestBox.Image = Image.FromFile($"Materials\\{deck.cards[randomNumber]}.png");
            if (game.defineCardValue(previousCard) <= game.defineCardValue(deck.cards[randomNumber]))
            {
                score++;
                label1.Text = score.ToString();
            }
            else
            {
                score = 0;
                label1.Text = "0";
            }
        }

        private void foldButton_Click(object sender, EventArgs e)
        {
            previousCard = deck.cards[randomNumber];
            randomNumber = random.Next(0, 52);
            TestBox.Image = Image.FromFile($"Materials\\{deck.cards[randomNumber]}.png");
            if (game.defineCardValue(previousCard) >= game.defineCardValue(deck.cards[randomNumber]))
            {
                score++;
                label1.Text = score.ToString();
            }
            else
            {
                score = 0;
                label1.Text = "0";
            }
        }
    }
}