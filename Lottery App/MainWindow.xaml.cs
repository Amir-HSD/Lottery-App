using Lottery_App.View;
using Lottery_App.ViewModel;
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

namespace Lottery_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MainWindowViewModel MWVM = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            
            //this.DataContext = MWVM;
        }

        private void DragMousePanel_EventHandler(object sender, MouseButtonEventArgs e)
        {
            if (MouseButton.Left == e.ChangedButton)
            {
                DragMove();
            }
        }

        private void RootNavigation_Loaded(object sender, RoutedEventArgs e)
        {
            RootNavigation.Navigate("Dashboard");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MaximizeButton(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        private void MinimizeButton(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
