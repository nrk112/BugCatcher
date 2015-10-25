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
            textBlock.FontSize = 100;

            Y = 100.0;
            X = (GameEngine.Instance.canvas.ActualWidth / 10) * 8;

            dX = 0.0;
            dY = 0.0;

            Scale = 0.5;

            textBlock.Foreground = Brushes.Black;
            AddToGame();
        }

        public override void Update()
        {
            textBlock.Text = "Bonus Multiplier: " + GameEngine.Instance.BonusMultiplier.ToString();
        }
    }
}
