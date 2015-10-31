using System.Collections.Generic;

namespace BugCatcher.BaseClasses
{
    abstract class Enemy : GameObject
    {
        protected double friction = 1.0;
        protected int speed;
        protected static StartSide startSide;
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
        /// </summary>
        protected void SetStartingPosition()
        {
            Y = Global.rand.Next(0, (int)MainWindow.canvas.Height);
            if (startSide == StartSide.Right)
                X = MainWindow.canvas.Width + this.Width;
            else if (startSide == StartSide.Left)
                X = -this.Width;
        }

        protected void GetNewSpeed()
        {
            speed = Global.rand.Next(Global.EnemySlowSpeed, Global.EnemyFastSpeed);
        }
    }
}
