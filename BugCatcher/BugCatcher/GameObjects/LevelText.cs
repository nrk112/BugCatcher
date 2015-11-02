using System.Windows;
using System.Windows.Media;

namespace BugCatcher.GameObjects
{
    public class LevelText : BaseClasses.GameText
    {
        public LevelText() : base()
        {
            textBlock.FontFamily = new FontFamily("Arial Black");
            textBlock.Height = 100.0;
            textBlock.Width = 1000.0;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = 50;

            GridSize = 40;
            GridPositionX = 4;
            GridPositionY = 2;

            Scale = 1;

            textBlock.Foreground = Global.TextColor;
            AddToGame();
        }

        public override void Update()
        {
            textBlock.Text = "Player Level: " + GameEngine.Instance.player.Level;
        }
    }
}
