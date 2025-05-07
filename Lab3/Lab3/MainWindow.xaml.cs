using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab3
{
    public partial class MainWindow : Window
    {
        private Button[,] buttons = new Button[3, 3];
        private bool isXTurn = true;
        private bool gameEnded = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGameBoard();
        }

        private void InitializeGameBoard()
        {
            GameGrid.Children.Clear();
            gameEnded = false;
            statusText.Text = "Хід: X";
            isXTurn = true;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button btn = new Button
                    {
                        FontSize = 32,
                        FontWeight = FontWeights.Bold,
                        Background = Brushes.White
                    };
                    btn.Click += Button_Click;
                    buttons[row, col] = btn;
                    GameGrid.Children.Add(btn);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameEnded) return;

            Button clicked = sender as Button;
            if (clicked.Content != null) return;

            clicked.Content = isXTurn ? "X" : "O";
            clicked.Foreground = isXTurn ? Brushes.Blue : Brushes.Red;

            if (CheckWinner())
            {
                gameEnded = true;
                statusText.Text = $"Переможець: {(isXTurn ? "X" : "O")}";
                return;
            }

            if (IsDraw())
            {
                gameEnded = true;
                statusText.Text = "Нічия!";
                return;
            }

            isXTurn = !isXTurn;
            statusText.Text = $"Хід: {(isXTurn ? "X" : "O")}";
        }

        private bool CheckWinner()
        {
            string current = isXTurn ? "X" : "O";

            for (int i = 0; i < 3; i++)
            {
                if ((buttons[i, 0].Content?.ToString() == current &&
                     buttons[i, 1].Content?.ToString() == current &&
                     buttons[i, 2].Content?.ToString() == current) ||
                    (buttons[0, i].Content?.ToString() == current &&
                     buttons[1, i].Content?.ToString() == current &&
                     buttons[2, i].Content?.ToString() == current))
                    return true;
            }

            if ((buttons[0, 0].Content?.ToString() == current &&
                 buttons[1, 1].Content?.ToString() == current &&
                 buttons[2, 2].Content?.ToString() == current) ||
                (buttons[0, 2].Content?.ToString() == current &&
                 buttons[1, 1].Content?.ToString() == current &&
                 buttons[2, 0].Content?.ToString() == current))
                return true;

            return false;
        }

        private bool IsDraw()
        {
            foreach (var btn in buttons)
                if (btn.Content == null)
                    return false;
            return true;
        }

        private void RestartGame(object sender, RoutedEventArgs e)
        {
            InitializeGameBoard();
        }
    }
}
