using BugCatcher.GameObjects;
using BugCatcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        MediaPlayer music = new MediaPlayer();

        private bool isGameOver = false;
        private int FPS = 60;
        private int level = 0;
        private int misses = 0;
        private int perfectCatches = 0;

        public BonusText bonusText;
        public HiScoreText hiScoreText;
        public ScoreText scoreText;
        public LevelText levelText;
        public Catcher player
        {
            get; set;
        }

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
            PlayMusic();
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

            new Background();

            isGameOver = false;
            bonusText = new BonusText();
            hiScoreText = new HiScoreText();
            scoreText = new ScoreText();
            levelText = new LevelText();


            for (int i = 0; i < 10; i++)
            {
                new SmallBug();
            }


            for (int i = 0; i < 3; i++)
            {
                new MediumBug();
            }
            new FlyingBug();
            new Firetruck();

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

        public void IncreaseBonus()
        {
            if (BonusMultiplier == 1)
                BonusMultiplier++;
            else if (BonusMultiplier <= 512)
                BonusMultiplier = BonusMultiplier * 2;
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

        private void PlayMusic()
        {
            string fullFileName = System.IO.Directory.GetCurrentDirectory() + "\\" + Global.MusicFile;
            Uri uriFile = new Uri(fullFileName);
            music.Open(uriFile);
            music.Volume = 0.2f;
            music.MediaEnded += new EventHandler(Media_Ended);
            music.Play();
        }

        /// <summary>
        /// Restart background music
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Media_Ended(object sender, EventArgs e)
        {
            music.Position = TimeSpan.Zero;
            music.Play();
        }
    }
} 