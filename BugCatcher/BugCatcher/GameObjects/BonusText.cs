﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BugCatcher.GameObjects
{
    public class BonusText : BaseClasses.GameText
    {
        public BonusText() : base()
        {
            textBlock.FontFamily = new FontFamily("Arial Black");
            textBlock.Height = 100.0;
            textBlock.Width = 1000.0;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = 50;

            GridSize = 40;
            GridPositionX = 5;
            GridPositionY = 3; 

            Scale = 1;

            textBlock.Foreground = Global.TextColor;
            AddToGame();
        }

        public override void Update()
        {
            textBlock.Text = "Bonus Multiplier: " + GameEngine.Instance.BonusMultiplier.ToString();
        }
    }
}
