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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Lottery_App.View
{
    /// <summary>
    /// Interaction logic for ShowWinner.xaml
    /// </summary>
    public partial class ShowWinner : Window
    {
        public ShowWinner()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation SpinnerAnimation = new DoubleAnimation();

            SpinnerAnimation.From = 0;

            SpinnerAnimation.To = 360;

            SpinnerAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));

            SpinnerAnimation.RepeatBehavior = RepeatBehavior.Forever;

            Storyboard.SetTarget(SpinnerAnimation, SpinnerTransform);

            Storyboard.SetTargetProperty(SpinnerAnimation, new PropertyPath("Angle"));

            storyboard.Children.Add(SpinnerAnimation);

            storyboard.Begin();
        }
    }
}
