using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace BugCatcher.BaseClasses
{
    abstract class Enemy : GameObject
    {
        protected double friction = 1.0;
        protected int speed;
        protected StartSide startSide;
        protected enum StartSide
        {
            Left,
            Right,
            Top,
            Bottom
        }

        public static List<Enemy> list = new List<Enemy>();
        public bool isHit { get; set; }
        public int Level { get; set; }

        public Enemy()
        {
        }

        /// <summary>
        /// Sets the starting position of the enemy. Can be used to reset as well.
        /// Must set starting side first.
        /// </summary>
        protected void SetStartingPosition(bool randomSide = false)
        {
            if (randomSide == true)
            {
                if (Global.rand.NextDouble() > 0.5)
                    startSide = StartSide.Right;
                else
                    startSide = StartSide.Left;
            }
            else
            {
                startSide = StartSide.Right;
            }

            //Set a random Y position
            Y = Global.rand.Next(0, (int)MainWindow.canvas.Height);

            //Set an X position based on the side.
            if (startSide == StartSide.Right)
            {
                X = MainWindow.canvas.Width + this.Width;
                ((Image)Element).LayoutTransform = new ScaleTransform(1, 1);
            }
            else if (startSide == StartSide.Left)
            {
                X = -this.Width;
                ((Image)Element).LayoutTransform = new ScaleTransform(-1, 1);
            }
                
        }

        /// <summary>
        /// Gets a random value between the specified settings and applies it to this objects speed property.
        /// </summary>
        protected void GetNewSpeed(double multiplier = 1)
        {
            speed = (int)(Global.rand.Next(Global.EnemySlowSpeed, Global.EnemyFastSpeed) * multiplier);
        }

        /// <summary>
        /// Plays the sound of a specific object.
        /// </summary>
        public virtual void PlaySound()
        {

        }
    }
}
