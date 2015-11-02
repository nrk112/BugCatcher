using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BugCatcher.BaseClasses;
using System.Windows.Media;
using System.Media;

namespace BugCatcher
{
    static class Global
    {
        #region game properties
        private static int enemySlowSpeed = 5;
        private static int enemyFastSpeed = 15;
        private static SoundPlayer sp = new SoundPlayer();

        public static int maxPlayerLevel = 10;
        public static int catchesToGrow = 20;
        public static double maxPlayerScaleSize = 2.0;
        public static Brush TextColor = Brushes.Yellow;
        public static string playerImage = "basket.png";
        public static string SmallBugImage = "bug1.png";
        public static string MediumBugImage = "beetle_hot.png";
        public static string FlyingBugImage = "bee_big-nose.png";
        public static string PowerUpImage = "present_12.png";
        public static string FiretruckImage = "firetruck.png";
        public static string BackgroundImage = @"C:\Users\nrk11\Documents\GitHub\BugCatcher\BugCatcher\BugCatcher\bin\Debug\Images\background.jpg";

        public static string MusicFile = "music.mp3";

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

        public static void PlayMultipleSound(ref MediaPlayer mp, string filename)
        {
            mp.Open(new Uri(filename, UriKind.Relative));
        }

        public static void PlaySingleSound(string filename)
        {
            sp.SoundLocation = "";
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
