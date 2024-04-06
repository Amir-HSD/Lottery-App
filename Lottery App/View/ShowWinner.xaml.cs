
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

        private string winnerName;

        public string WinnerName
        {
            get { return winnerName; }
            set { winnerName = value; OnPropertyChanged(); }
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
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            WinnerName = "...";
            timer.Start();
        }

        int index = UsersData.Instance.Items.Count-1;
        private void Timer_Tick(object sender, EventArgs e)
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
            if (timer.Interval.Ticks > 30)
            {
                timer.Stop();
            }
        }
    }
}
