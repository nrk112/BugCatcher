using System.Windows.Controls;

namespace BugCatcher.BaseClasses
{
    public abstract class GameText : GameObject
    {
        public GameText() : base()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Width = 10;
            textBlock.Height = 10;
            Element = textBlock;
        }

        protected TextBlock textBlock
        {
            get
            {
                return (TextBlock)Element;
            }
        }
    }
}
