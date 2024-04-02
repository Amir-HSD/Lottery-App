using Lottery_App.Base;
using Lottery_App.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lottery_App.ViewModel
{
    internal class LotteryViewModel : ViewBase
    {

        public LotteryViewModel()
        {
            Items = new ObservableCollection<Item>();
        }

        public ObservableCollection<Item> Items { get; set; }

        public Item selectedItem { get; set; }
        public Item SelectedItem
        {
			get { return selectedItem; }
			set { 
                selectedItem = value;
                OnPropertyChanged();
            }
		}

        private string username = string.Empty;

        public string UserName
        {
            get { return username; }
            set { 
                username = value; 
                OnPropertyChanged();
            }
        }


        public RelayCommand AddToListCommand => new RelayCommand(onExecute => { AddToList(); }, onExecuteChanged => { return true; });

        public RelayCommand RemoveFromListCommand => new RelayCommand(onExecute => { RemoveFromList(); }, onExecuteChanged => { return true; });

        public void AddToList()
        {
            if (UserName != string.Empty)
            {
                Items.Add(new Item { Name = UserName });
                UserName = string.Empty;
            }
        }

        public void RemoveFromList()
        {
            if (SelectedItem != null)
            {
                Items.Remove(SelectedItem);
                SelectedItem = null;
            }
        }


	}
}
