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

        int WinnerCount = 0;
        public void ShowWinner()
        {

            if (UsersData.Instance.Items.Count == 0)
            {
                return;
            }

            string WinnerName = "";

            if (UsersData.Instance.ReservedNames.Count > 0)
            {
                if (WinnerCount < UsersData.Instance.ReservedNames.Count)
                {
                    WinnerName = UsersData.Instance.ReservedNames[WinnerCount].Name;
                    WinnerCount++;
                }
                else
                {
                    Random random = new Random();
                    int num = random.Next(0, Items.Count);
                    WinnerName = UsersData.Instance.Items[num].Name;

                }
            }
            else
            {
                Random random = new Random();
                int num = random.Next(0, Items.Count);
                WinnerName = UsersData.Instance.Items[num].Name;
            }

            ShowWinner showWinner = new ShowWinner(WinnerName);

            showWinner.Owner = Application.Current.MainWindow;

            showWinner.ShowDialog();

        }

    }
}
