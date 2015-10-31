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
        private double startingScale = 0.5;

        public int Hits { get; set; }
        public int Misses { get; set; }
        public int Level { get; set; }

        public Catcher()
        {
            Hits = 0;
            Misses = 0;
            Level = 1;

            UseImage(Global.playerImage, bitmap);

            mousePosition = Mouse.GetPosition(MainWindow.canvas);
            //lastPosition = mousePosition;
            X = mousePosition.X;
            Y = mousePosition.Y;
            Scale = startingScale;
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

            foreach (BaseClasses.Enemy enemy in BaseClasses.Enemy.list)
            {
                if (Global.CheckCollision(this, enemy))
                {
                    //Enemy is weaker than player
                    if (this.Level >= enemy.Level)
                    {
                        enemy.isHit = true;
                        Hits++;
                        GameEngine.Instance.IncreaseScore();
                        if (Hits % Global.catchesToGrow == 0 && Scale <= Global.maxPlayerScaleSize)
                        {
                            Scale += 0.3;
                            Level++;
                            GameEngine.Instance.IncreaseBonus();
                        }
                    }
                    //Enemy is stronger than player
                    else if (Scale > startingScale)
                    {
                        Scale -= 0.3;
                        Level--;
                        Hits = 0;
                        GameEngine.Instance.ClearBonus();
                    }
                }
            }
        }
    }
}
