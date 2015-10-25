using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BugCatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Canvas canvas { get; set; }
        public GameEngine gameEngine;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            canvas = new Canvas();
            this.WindowState = WindowState.Maximized;
            canvas.Background = Brushes.Aquamarine;

            mainGrid.Height = Height - 40;
            mainGrid.Width = Width;
            canvas.Height = mainGrid.Height;
            canvas.Width = mainGrid.Width;

            mainGrid.Children.Add(canvas);
            Global.canvas = canvas;
            gameEngine = GameEngine.Instance;
        }
    }
}
