using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BugCatcher.GameObjects
{
    class Firetruck : BaseClasses.Enemy
    {
        private static BitmapImage bitMap = null;
        private double speedMultiplier = 3.0;
        private MediaPlayer honkSound = new MediaPlayer();

        public Firetruck()
        {
            string fullFileName = System.IO.Directory.GetCurrentDirectory() + "\\honk.mp3";
            Uri uriFile = new Uri(fullFileName);
            honkSound.Open(uriFile);
            honkSound.MediaEnded += new EventHandler(Media_Ended);

            UseImage(Global.FiretruckImage, bitMap);
            SetStartingPosition(true);
            Scale = 1.0;
            isHit = false;
            Level = 20;
            GetNewSpeed(speedMultiplier);
            list.Add(this);
            AddToGame();
        }

        private int waitCounter = 0;
        public override void Update()
        {
            waitCounter++;

            if (waitCounter < 250)
                return;

            if (isHit)
            {
                SetStartingPosition(true);
                waitCounter = 0;
                GetNewSpeed(speedMultiplier);
                isHit = false;
            }
            else if (X < -Width && startSide == StartSide.Right)
            {
                SetStartingPosition(true);
                waitCounter = 0;
                GetNewSpeed(speedMultiplier);
                if (GameEngine.Instance.player != null)
                    GameEngine.Instance.player.Misses++;
            }
            //If it goes off the screen on the right.
            else if (X > MainWindow.canvas.Width + this.Width && startSide == StartSide.Left)
            {
                SetStartingPosition(true);
                waitCounter = 0;
                GetNewSpeed(speedMultiplier);
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

        private bool soundLock = false;
        public override void PlaySound()
        {
            if (soundLock)
                return;
            soundLock = true; 
            honkSound.Stop();
            honkSound.Play();
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            soundLock = false;
        }
    }
}
