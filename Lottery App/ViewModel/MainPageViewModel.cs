using Lottery_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
