using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BugCatcher.GameObjects
{
    class MediumBug : BaseClasses.Enemy
    {
        private static BitmapImage bitMap = null;

        public MediumBug()
        {
            UseImage(Global.MediumBugImage, bitMap);
            startSide = StartSide.Right;
            SetStartingPosition();
            Scale = 0.5;
            isHit = false;
            Level = 2;
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
                Y += dY;
            }
        }
    }
}