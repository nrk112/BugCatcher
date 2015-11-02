using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace BugCatcher.GameObjects
{
    class Background : BaseClasses.GameObject
    {
        public Background()
        {
            Image background = new Image();
            background.Width = MainWindow.canvas.Width;
            background.Height = MainWindow.canvas.Height;
            background.Stretch = System.Windows.Media.Stretch.Fill;

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(Global.BackgroundImage);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(background, image);
            ImageBehavior.SetRepeatBehavior(background, RepeatBehavior.Forever);

            Element = background;
            X = MainWindow.canvas.Width / 2;
            Y = MainWindow.canvas.Height / 2;
            AddToGame();
        }

        public override void Update()
        {
        }
    }
}
