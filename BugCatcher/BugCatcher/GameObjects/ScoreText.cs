using System.Windows;
using System.Windows.Media;

namespace BugCatcher.GameObjects
{
    public class ScoreText : BaseClasses.GameText
    {
        public ScoreText() : base()
        {
            textBlock.FontFamily = new FontFamily("Arial Black");
            textBlock.Height = 100.0;
            textBlock.Width = 1000.0;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = 50;

            GridSize = 40;
            GridPositionX = 3;
            GridPositionY = 1;

            Scale = 1;

            textBlock.Foreground = Global.TextColor;
            AddToGame();
        }

        public override void Update()
        {
            textBlock.Text = "Score: " + GameEngine.Instance.Score.ToString();
        }
    }
}
