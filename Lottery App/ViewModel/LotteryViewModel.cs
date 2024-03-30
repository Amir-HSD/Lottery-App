using Lottery_App.Model;
using System.Collections.ObjectModel;

namespace Lottery_App.ViewModel
{
    internal class LotteryViewModel : ViewBase
    {
        public ObservableCollection<Item> Items { get; set; }

        public LotteryViewModel()
        {
            Items = new ObservableCollection<Item>();
        }

        public Item selectedItem { get; set; }
        public Item SelectedItem
        {
			get { return selectedItem; }
			set { 
                selectedItem = value;
                OnPropertyChanged();
            }
		}


	}
}
