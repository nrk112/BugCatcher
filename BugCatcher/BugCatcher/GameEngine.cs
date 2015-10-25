using BugCatcher.GameObjects;
using BugCatcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace BugCatcher
{
    public sealed class GameEngine
    {
        #region Singleton GameEngine
        private static volatile GameEngine instance;
        private static object syncRoot = new Object();

        private GameEngine()
        {
        }

        public static GameEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GameEngine();
                    }
                    instance.InitializeEngine();
                }
                return instance;
            }
        }
        #endregion

        DispatcherTimer framerateTimer = new DispatcherTimer();
        List<IGameObject> gameObjects = new List<IGameObject>();

        public Canvas canvas { get; set; }

        private bool isGameOver = false;
        private int FPS = 30;
        private int round = 0;
        private int score = 0;

        public static BonusText bonusText;
        public int BonusMultiplier { get; set; }

        /// <summary>
        /// Sets the initial settings for the game engine.
        /// </summary>
        public void InitializeEngine()
        {
            canvas = Global.canvas;
            framerateTimer.Interval = new TimeSpan(0, 0, 0, 0, GetMSFromFPS());
            framerateTimer.Start();
            framerateTimer.Tick += timer_Tick;
            InitializeGame();
        }

        /// <summary>
        /// Convert the frames per second to approximate miliseconds.
        /// </summary>
        /// <returns></returns>
        private int GetMSFromFPS()
        {
            return 1000 / FPS;
        }

        /// <summary>
        /// Sets or resets the initial settings for the current game setup.
        /// </summary>
        private void InitializeGame()
        {
            round = 0;
            score = 0;
            BonusMultiplier = 1;
            SetUpAllGameObjects();
        }

        /// <summary>
        /// Adds the objects to the list of objects that will be displayed.
        /// </summary>
        /// <param name="obj"></param>
        public void AddToDisplayList(IGameObject obj)
        {
            gameObjects.Add(obj);
        }

        /// <summary>
        /// Setup any game objects in here.
        /// </summary>
        /// <param name="isFirstTime"></param>
        public void SetUpAllGameObjects(bool isFirstTime = false)
        {
            round++;
            isGameOver = false;
            bonusText = new BonusText();
        }

        /// <summary>
        /// Update all the objects in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            foreach (IGameObject obj in gameObjects)
            {
                obj.Update();
            }
        }
    }
}
