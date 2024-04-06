using Lottery_App.Base;
using Lottery_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery_App.ViewModel
{
    internal class SettingsPageViewModel : ViewBase
    {
        public SettingsPageViewModel() {
            ReservedNames = new ObservableCollection<Item>(UsersData.Instance.ReservedNames);
        }

        public ObservableCollection<Item> ReservedNames
        {
            get { return UsersData.Instance.ReservedNames; }
            set
            {
                UsersData.Instance.ReservedNames = value;
                OnPropertyChanged();
            }
        }
        public Item selectedItem { get; set; }
        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private string username = string.Empty;

        public string UserName
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        public RelayCommand AddToListCommand => new RelayCommand(onExecute => { AddToList(); }, onExecuteChanged => { return true; });

        public RelayCommand RemoveFromListCommand => new RelayCommand(onExecute => { RemoveFromList(); }, onExecuteChanged => { return true; });

        public void AddToList()
        {
            if (UserName != string.Empty)
            {
                ReservedNames.Add(new Item { Name = UserName });
                UserName = string.Empty;
            }
        }

        public void RemoveFromList()
        {
            if (SelectedItem != null)
            {
                ReservedNames.Remove(SelectedItem);
                SelectedItem = null;
            }
        }

    }
}
