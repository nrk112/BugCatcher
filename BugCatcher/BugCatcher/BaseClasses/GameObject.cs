using System;
using BugCatcher.Interfaces;
using System.Windows;
using System.Windows.Media;

namespace BugCatcher.BaseClasses
{
    public abstract class GameObject : IGameObject
    {
        public GameObject()
        {
        }

        private FrameworkElement _element;

        public FrameworkElement Element
        {
            get { return _element; }
            set
            {
                _element = value;
                InitializeTransformGroup();
                _element.RenderTransform = transformGroup;
                GameEngine.Instance.canvas.Children.Add(_element);
            }
        }

        private void InitializeTransformGroup()
        {
            rotateTransform = new RotateTransform();
            rotateTransform.CenterX = _element.Width / 2.0;
            rotateTransform.CenterY = _element.Height / 2.0;

            scaleTransform = new ScaleTransform();
            scaleTransform.CenterX = _element.Width / 2.0;
            scaleTransform.CenterY = _element.Height / 2.0;

            translateTransform = new TranslateTransform();

            rotateTransform = new RotateTransform();

            transformGroup = new TransformGroup();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(translateTransform);
            transformGroup.Children.Add(rotateTransform);
        }

        protected RotateTransform rotateTransform { get; set; }
        protected ScaleTransform scaleTransform { get; set; }
        protected TranslateTransform translateTransform { get; set; }
        protected TransformGroup transformGroup { get; set; }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }

        protected void AddToGame()
        {
            //GameEngine.Instance.canvas.Children.Add(_element);
            GameEngine.Instance.AddToDisplayList(this);
        }














        private double _Scale;

        public double Scale
        {
            get
            {
                return _Scale;
            }
            set
            {
                _Scale = value;
                scaleTransform.ScaleX = value;
                scaleTransform.ScaleY = value;
            }
        }
        public double Angle
        {
            get
            {
                return rotateTransform.Angle;
            }
            set
            {
                rotateTransform.Angle = value;
            }
        }


        public double Height
        {
            get
            {
                return Element.Height;
            }
            set
            {
                Element.Height = value;
                rotateTransform.CenterX = _element.Width / 2.0;
                rotateTransform.CenterY = _element.Height / 2.0;
                scaleTransform.CenterX = _element.Width / 2.0;
                scaleTransform.CenterY = _element.Height / 2.0;
            }
        }

        public double Width
        {
            get
            {
                return Element.Width;
            }
            set
            {
                Element.Width = value;
                rotateTransform.CenterX = _element.Width / 2.0;
                rotateTransform.CenterY = _element.Height / 2.0;
                scaleTransform.CenterX = _element.Width / 2.0;
                scaleTransform.CenterY = _element.Height / 2.0;
            }
        }

        public double ScaledHeight
        {
            get
            {
                return Element.Height * scaleTransform.ScaleY;
            }
        }

        public double ScaledWidth
        {
            get
            {
                return Element.Width * scaleTransform.ScaleX;
            }
        }

        public double X
        {
            get
            {
                return translateTransform.X + Width / 2.0;
            }
            set
            {
                translateTransform.X = value - Width / 2.0;
            }
        }

        public double Y
        {
            get
            {
                return translateTransform.Y + Height / 2.0;
            }
            set
            {
                translateTransform.Y = value - Height / 2.0;
            }
        }

        public double _dX;
        public double _dY;
        public double dX
        {
            get
            {
                return _dX;
            }
            set
            {
                _dX = value;
            }
        }

        public double dY
        {
            get
            {
                return _dY;
            }
            set
            {
                _dY = value;
            }
        }
    }
}
