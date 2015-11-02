using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BugCatcher.GameObjects
{
    class FlyingBug : BaseClasses.Enemy
    {
        private static BitmapImage bitMap = null;

        public FlyingBug()
        {
            UseImage(Global.FlyingBugImage, bitMap);
            SetStartingPosition(true);
            Scale = 0.5;
            isHit = false;
            Level = 10;
            GetNewSpeed();
            list.Add(this);
            AddToGame();
        }

        public override void Update()
        {
            if (isHit)
            {
                SetStartingPosition(true);
                GetNewSpeed();
                isHit = false;
            }
            //If it goes off the screen on the left.
            else if (X < -Width && startSide == StartSide.Right)
            {
                SetStartingPosition(true);
                GetNewSpeed();
                if (GameEngine.Instance.player != null)
                    GameEngine.Instance.player.Misses++;
            }
            //If it goes off the screen on the right.
            else if (X > MainWindow.canvas.Width + this.Width && startSide == StartSide.Left)
            {
                SetStartingPosition(true);
                GetNewSpeed();
                if (GameEngine.Instance.player != null)
                    GameEngine.Instance.player.Misses++;
            }
            else
            {
                dY = 0.0;
                dX = speed;

                dX *= friction;
                dY *= friction;

                if (startSide == StartSide.Right)
                    X -= dX;
                else if (startSide == StartSide.Left)
                    X += dX;

                Y = GetYFromSin(X) + Y;
                powerup.SetXandY(X, (Y + this.Height / 5));
            }
        }

        PowerUp powerup = new PowerUp();

        private int amplitutde = 6;
        private double GetYFromSin(double angle)
        {
            //Normalize x
            angle = angle % 360;

            //Convert to radians
            angle = angle * Math.PI / 180;

            //Adjust period
            //angle = angle * period;

            //calculate y 
            return (amplitutde * Math.Sin(angle));
        }
    }
}
