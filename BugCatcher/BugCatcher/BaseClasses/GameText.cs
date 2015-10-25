using System.Windows.Controls;

namespace BugCatcher.BaseClasses
{
    public abstract class GameText : GameObject
    {
        public GameText() : base()
        {
            TextBlock textBlock = new TextBlock();
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
