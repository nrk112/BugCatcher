using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BugCatcher.BaseClasses;

namespace BugCatcher
{
    static class Global
    {
        #region game properties
        private static int enemySlowSpeed = 5;
        private static int enemyFastSpeed = 15;
        public static int catchesToGrow = 20;
        public static double maxPlayerScaleSize = 2.0;
        public static string playerImage = "basket.png";
        public static string SmallBugImage = "bug1.png";
        public static string MediumBugImage = "beetle_hot.png";
        public static string FlyingBugImage = "bee_big-nose.png";

        /// <summary>
        /// The slowest speed an enemy may use.
        /// Returns a ratio of screen width to keep consistent speeds across devices
        /// </summary>
        public static int EnemySlowSpeed
        {
            get { return (int)(MainWindow.canvas.Width / (MainWindow.canvas.Width / enemySlowSpeed)); }
            set { enemySlowSpeed = value; }
        }

        /// <summary>
        /// The fastest speed an enemy may use. 
        /// Returns a ratio of screen width to keep consistent speeds across devices
        /// </summary>
        public static int EnemyFastSpeed
        {
            get { return (int)(MainWindow.canvas.Width / (MainWindow.canvas.Width / enemyFastSpeed)); }
            set { enemyFastSpeed = value; }
        }


        #endregion
        public static readonly Random rand = new Random();

        static public bool CheckCollision(GameObject obj1, GameObject obj2)
        {
            if (Math.Abs(obj1.Y - obj2.Y) < ((obj1.ScaledHeight + obj2.ScaledHeight) / 2.0))
            {
                if (Math.Abs(obj1.X - obj2.X) < ((obj1.ScaledWidth + obj2.ScaledWidth) / 2.0))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
