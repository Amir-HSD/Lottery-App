
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lottery_App.Model;
using System.Reflection;
using System.Windows.Input;

namespace Lottery_App.View
{
    /// <summary>
    /// Interaction logic for ShowWinner.xaml
    /// </summary>
    public partial class ShowWinner : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        DispatcherTimer timer;
        DispatcherTimer timer2;
        private string winnerName;

        public string WinnerName
        {
            get { return winnerName; }
            set { winnerName = value; OnPropertyChanged(); }
        }

        private string titleText = "Who Will Win?";

        public string TitleText
        {
            get { return titleText; }
            set { titleText = value; OnPropertyChanged(); }
        }


        private string OrginalWinnerName = "";
        public ShowWinner(string orginalWinnerName)
        {
            InitializeComponent();
            DataContext = this;
            Loaded += Window_Loaded;
            OrginalWinnerName = orginalWinnerName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += Timer_Tick;
            WinnerName = "...";
            timer.Start();

            timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromMilliseconds(100);
            timer2.Tick += Timer_Tick2;
            timer2.Start();
        }

        int index = UsersData.Instance.Items.Count-1;

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer2.Stop();
            Spinner.Visibility = Visibility.Hidden;
            SpinnerIcon.Visibility = Visibility.Hidden;
            CloseTxt.Visibility = Visibility.Visible;
            TitleText = "The Winner is";
            FooterTxt.FontSize = 50;
            WinnerName = OrginalWinnerName;
        }

        private void Timer_Tick2(object sender, EventArgs e)
        {
            if (timer.IsEnabled)
            {
                if (index >= 0)
                {
                    WinnerName = UsersData.Instance.Items[index].Name;
                }
                else
                {
                    index = UsersData.Instance.Items.Count - 1;
                }
                index--;
            }
        }

        private void CloseTxt_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.Close();
            }
        }
    }
}
