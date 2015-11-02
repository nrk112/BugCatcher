using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BugCatcher.GameObjects
{
    public class Catcher : BaseClasses.GameObject
    {
        private static BitmapImage bitmap = null;
        private Point mousePosition = new Point();
        private double startingScale = 0.5;
        private MediaPlayer splatSound = new MediaPlayer();
        private MediaPlayer levelDownSound = new MediaPlayer();

        public int Hits { get; set; }
        public int Misses { get; set; }
        public int Level { get; set; }

        public Catcher()
        {
            Hits = 0;
            Misses = 0;
            Level = 1;

            UseImage(Global.playerImage, bitmap);

            string fullFileName = System.IO.Directory.GetCurrentDirectory() + "\\splat.mp3";
            Uri uriFile = new Uri(fullFileName);
            splatSound.Open(uriFile);

            fullFileName = System.IO.Directory.GetCurrentDirectory() + "\\splat.mp3";
            uriFile = new Uri(fullFileName);
            levelDownSound.Open(uriFile);

            mousePosition = Mouse.GetPosition(MainWindow.canvas);
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
                        splatSound.Stop();
                        splatSound.Play();
                        Hits++;
                        GameEngine.Instance.IncreaseScore();

                        if (Hits % Global.catchesToGrow == 0)
                        {
                            GameEngine.Instance.IncreaseBonus();

                            if (this.Level < Global.maxPlayerLevel)
                                Level++;

                            if (Scale <= Global.maxPlayerScaleSize)
                                Scale += 0.3;
                        }

                    }
                    //Player hits a really strong enemy
                    else if ((enemy.Level - this.Level) >= 10)
                    {
                        enemy.PlaySound();
                        Scale = startingScale;
                        Level = 1;
                        Hits = 0;
                        GameEngine.Instance.ClearBonus();
                    }
                    //Enemy is stronger than player
                    else if (Scale > startingScale && this.Level < enemy.Level)
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
