using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BugCatcher.GameObjects
{
    class Enemy : BaseClasses.GameObject
    {
        static BitmapImage bMap = null;
        public static List<Enemy> list = new List<Enemy>();
        public static int ballCount = 0;
        private static StartSide startSide;

        private enum StartSide
        {
            Left,
            Right,
            Top,
            Bottom
        }

        public Enemy()
        {
            UseImage("bug1.png", bMap);
            ballCount++;
            startSide = StartSide.Right;

            Y = Global.rand.Next(0, (int)MainWindow.canvas.Height);
            if (startSide == StartSide.Right)
                X = MainWindow.canvas.Width + this.Width;
            else if (startSide == StartSide.Left)
                X = -this.Width;

            Enemy.list.Add(this);
            AddToGame();
        }

        private double friction = 1;

        public override void Update()
        {
            dY = 0.0;
            dX = 20;

            dX *= friction;
            dY *= friction;
            X -= dX;
            Y += dY;
        }
    }
}
