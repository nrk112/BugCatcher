using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BugCatcher.GameObjects
{
    class SmallBug : Enemy
    {
        private static BitmapImage bitMap = null;

        public SmallBug()
        {
            UseImage(Global.enemyImage, bitMap);
            startSide = StartSide.Right;
            SetStartingPosition();
            Scale = 0.3;
            isHit = false;
            speed = Global.rand.Next(Global.EnemySlowSpeed, Global.EnemyFastSpeed);
            Enemy.list.Add(this);
            AddToGame();
        }

        public override void Update()
        {
            if (isHit)
            {
                SetStartingPosition();
                isHit = false;
            }
            else if (X < -Width)
            {
                SetStartingPosition();
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
