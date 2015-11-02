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
            SetStartingPosition(true);
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
                SetStartingPosition(true);
                GetNewSpeed();
                isHit = false;
            }
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

                Y += dY;
            }
        }
    }
}