using System.Windows.Controls;

namespace BugCatcher.BaseClasses
{
    public abstract class GameText : GameObject
    {
        public GameText() : base()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Width = 1;
            textBlock.Height = 1;
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
