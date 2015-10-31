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
            startSide = StartSide.Right;
            SetStartingPosition();
            Scale = 0.5;
            isHit = false;
            Level = 3;
            GetNewSpeed();
            list.Add(this);
            AddToGame();
        }

        public override void Update()
        {
            if (isHit)
            {
                SetStartingPosition();
                GetNewSpeed();
                isHit = false;
            }
            else if (X < -Width)
            {
                SetStartingPosition();
                GetNewSpeed();
                if (GameEngine.player != null)
                    GameEngine.player.Misses++;
            }
            else
            {
                dY = 0.0;
                dX = speed;

                dX *= friction;
                dY *= friction;

                X -= dX;
                Y = GetYFromSin(X) + Y;
            }
        }

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
