using System.Windows;
using System.Windows.Media;

namespace BugCatcher.GameObjects
{
    public class BonusText : BaseClasses.GameText
    {
        public BonusText() : base()
        {
            textBlock.FontFamily = new FontFamily("Arial Black");
            textBlock.Height = 100.0;
            textBlock.Width = 1000.0;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = 50;

            Y = 100.0;
            X = (MainWindow.canvas.Width / 10) * 8;

            dX = 0.0;
            dY = 0.0;

            Scale = 1;

            textBlock.Foreground = Brushes.Black;
            AddToGame();
        }

        public override void Update()
        {
            textBlock.Text = "Bonus Multiplier: " + GameEngine.Instance.BonusMultiplier.ToString();
        }
    }
}
