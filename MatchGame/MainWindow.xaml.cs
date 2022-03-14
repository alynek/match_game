using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> characterEmoji = new List<string>()
            {
                "🧙‍♂️", "🧙‍♂️",
                "🧝🏻‍♂️", "🧝🏻‍♂️",
                "🌋", "🌋",
                "🐉", "🐉",
                "🏰", "🏰",
                "💍", "💍",
                "👑", "👑",
                "🐴", "🐴"
            };

            Random random = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(characterEmoji.Count);
                string nextEmoji = characterEmoji[index];
                textBlock.Tag = nextEmoji;
                textBlock.Text = "?";
                characterEmoji.RemoveAt(index);
            }
        }

        TextBlock lastTextBlockClicked;
        bool firstClick = true;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock currentTextBlock = sender as TextBlock;

            if(firstClick)
            {
                currentTextBlock.Text = (string)currentTextBlock.Tag;
                lastTextBlockClicked = currentTextBlock; 
                firstClick = false; 
            }

            else if(lastTextBlockClicked.Tag == currentTextBlock.Tag)
            {
                currentTextBlock.Text = (string)currentTextBlock.Tag;
                firstClick = true;
            }
            else
            {
                lastTextBlockClicked.Text = "?";
                firstClick = true;
            }
        }
    }
}
