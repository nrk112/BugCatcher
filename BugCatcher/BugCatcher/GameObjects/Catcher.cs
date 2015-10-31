using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BugCatcher.GameObjects
{
    public class Catcher : BaseClasses.GameObject
    {
        private static BitmapImage bitmap = null;
        private Point lastPosition = new Point();
        private Point mousePosition = new Point();

        public int Hits { get; set; }
        public int Misses { get; set; }

        public Catcher()
        {
            Hits = 0;
            Misses = 0;

            UseImage(Global.playerImage, bitmap);

            mousePosition = Mouse.GetPosition(MainWindow.canvas);
            lastPosition = mousePosition;
            X = mousePosition.X;
            Y = mousePosition.Y;
            Scale = 0.5;
            AddToGame();
        }

        double friction = 0.1;
        public override void Update()
        {
            mousePosition = Mouse.GetPosition(MainWindow.canvas);
            dX = (X - mousePosition.X) * friction;
            dY = (Y - mousePosition.Y) * friction;

            X = mousePosition.X;
            Y = mousePosition.Y;

            foreach (Enemy enemy in Enemy.list)
            {
                if (Global.CheckCollision(this, enemy))
                {
                    enemy.isHit = true;
                    Hits++;
                    if (Hits % Global.catchesToGrow == 0 && Scale <= Global.maxPlayerScaleSize)
                    {
                        Scale += 0.1;
                    }
                }
            }
        }
    }
}
