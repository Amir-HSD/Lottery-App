using Lottery_App.Base;
using Lottery_App.Model;
using Lottery_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lottery_App.ViewModel
{
    internal class MainPageViewModel : ViewBase
    {
        public MainPageViewModel()
        {
            Items = new ObservableCollection<Item>(UsersData.Instance.Items);
        }
        public ObservableCollection<Item> Items
        {
            get { return UsersData.Instance.Items; }
            set { UsersData.Instance.Items = value; }
        }

        public RelayCommand ShowWinnerCommand => new RelayCommand(onExecute => { ShowWinner(); }, onExecuteChanged=> { return true; });

        public void ShowWinner()
        {
            Random random = new Random();
            random.Next(0, Items.Count);

            ShowWinner showWinner = new ShowWinner("");

            showWinner.Owner = Application.Current.MainWindow;

            showWinner.ShowDialog();

        }

    }
}
