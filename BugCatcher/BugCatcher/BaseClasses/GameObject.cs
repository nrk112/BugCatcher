using System;
using BugCatcher.Interfaces;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

            transformGroup = new TransformGroup();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(translateTransform);
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
            MainWindow.canvas.Children.Add(_element);
            GameEngine.Instance.AddToDisplayList(this);
        }

        protected int GridSize { get; set; }

        protected int GridPositionX
        {
            set
            {
                X = (MainWindow.canvas.Width / GridSize) * value;
            }
        }

        protected int GridPositionY
        {
            set
            {
                Y = (MainWindow.canvas.Width / GridSize) * value;
            }
        }

        public void UseImage(string imageFileName, BitmapImage b)
        {
            if (b == null)
            {
                b = new BitmapImage();
                //G.CheckForAlternateContentDir(imageFileName);

                b.BeginInit();
                b.UriSource = new Uri("images/" + imageFileName, UriKind.Relative);
                b.EndInit();
            }

            //TODO: make images scale based on screen size.
            Image baseElement = new Image();
            baseElement.Source = b;
            baseElement.Stretch = Stretch.Fill;
            baseElement.Height = b.Height;
            baseElement.Width = b.Width;
            Element = baseElement;
        }

        public double dX { get; set; }
        public double dY { get; set; }









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
    }
}
