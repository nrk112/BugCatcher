using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BugCatcher.GameObjects
{
    class PowerUp : BaseClasses.Enemy
    {
        private static BitmapImage bitMap = null;

        public PowerUp()
        {
            UseImage(Global.PowerUpImage, bitMap);
            SetStartingPosition(true);
            Scale = 0.3;
            isHit = false;
            Level = 1;
            GetNewSpeed();
            list.Add(this);
            AddToGame();
        }

        public override void Update()
        {
            if (isActive)
            {
                if (isHit)
                {

                    isActive = false;
                }

            }
        }

        public void SetXandY(double x, double y)
        {
            X = x;
            Y = y;
        }

        private bool isActive { get; set; }
    }
}
