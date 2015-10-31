using BugCatcher.GameObjects;
using BugCatcher.Interfaces;
using System;
using System.Collections.Generic;
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

        private bool isGameOver = false;
        private int FPS = 60;
        private int level = 0;
        private int misses = 0;
        private int perfectCatches = 0;

        public static BonusText bonusText;
        public static HiScoreText hiScoreText;
        public static ScoreText scoreText;
        public static Catcher player;

        public int BonusMultiplier = 1;
        public int HighScore = 0; 
        public int Score { get; private set; }

        /// <summary>
        /// Sets the initial settings for the game engine.
        /// </summary>
        public void InitializeEngine()
        {
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
            level = 0;
            Score = 0;
            misses = 0;
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
            level++;

            isGameOver = false;
            bonusText = new BonusText();
            hiScoreText = new HiScoreText();
            scoreText = new ScoreText();


            for (int i = 0; i < 10; i++)
            {
                new SmallBug();
            }


            for (int i = 0; i < 2; i++)
            {
                new MediumBug();
            }
            new FlyingBug();

            player = new Catcher();
        }

        /// <summary>
        /// Increases the score based on the current bonus.
        /// </summary>
        /// <param name="amount"></param>
        public void IncreaseScore(int amount = 1)
        {
            Score += amount * BonusMultiplier;
        }

        public void IncreaseBonus(int amount = 1)
        {
            if (BonusMultiplier == 1)
                BonusMultiplier++;
            else
                BonusMultiplier = (int)Math.Pow(BonusMultiplier, 2);
        }

        public void ClearBonus()
        {
            BonusMultiplier = 1;
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