using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugCatcher.Interfaces;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace BugCatcher.GameObjects
{
    public abstract class GameObject : FrameworkElement, IGameObject
    {
        //public static List<IGameObject> ObjectList { get; }

        public GameObject()
        {
            InitializeTransformGroup();
            this.RenderTransform = transformGroup;
        }

        private void InitializeTransformGroup()
        {
            rotateTransform = new RotateTransform();
            rotateTransform.CenterX = Width / 2.0;
            rotateTransform.CenterY = Height / 2.0;

            scaleTransform = new ScaleTransform();
            scaleTransform.CenterX = Width / 2.0;
            scaleTransform.CenterY = Height / 2.0;

            translateTransform = new TranslateTransform();

            rotateTransform = new RotateTransform();

            transformGroup = new TransformGroup();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(translateTransform);
            transformGroup.Children.Add(rotateTransform);
        }

        private RotateTransform rotateTransoform { get; set; }
        private ScaleTransform scaleTransform { get; set; }
        private RotateTransform rotateTransform { get; set; }
        private TranslateTransform translateTransform { get; set; }
        private TransformGroup transformGroup { get; set; }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void AddToGame()
        {
            GameEngine.Instance.canvas.Children.Add(this);
            GameEngine.Instance.AddToDisplayList(this);
        }
    }
}
