﻿using Lottery_App.Base;
using Lottery_App.Model;
using Lottery_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace Lottery_App.ViewModel
{
    internal class LotteryViewModel : ViewBase
    {

        public LotteryViewModel()
        {
            Items = new ObservableCollection<Item>();
        }

        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public Item selectedItem { get; set; }
        public Item SelectedItem
        {
			get { return selectedItem; }
			set { 
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
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

        public RelayCommand ClearListCommand => new RelayCommand(onExecute => { ClearList(); }, onExecuteChanged => { return true; });

        public RelayCommand EditUserNameCommand => new RelayCommand(onExecute => { EditUserName(); }, onExecuteChanged => { return true; });
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

        public event EventHandler<MsgBoxProp> ShowMessageRequested;

        private bool result;

        public bool Result
        {
            get { return result; }
            set { 
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }


        public void ClearList()
        {
            if (Items.Count != 0)
            {

                MsgBoxProp msgBoxProp = new MsgBoxProp();

                msgBoxProp.Title = "Clear List";
                msgBoxProp.Content = "Are you sure?";
                msgBoxProp.ButtonText = "OK";

                ShowMessageRequested?.Invoke(this, msgBoxProp);

                if (Result == true)
                {
                    Items.Clear();
                }

                
            }
        }

        public void OnEnterPressed()
        {
            AddToList();
        }

        public event EventHandler<bool> RefreshItems;
        public void EditUserName()
        {
            if (SelectedItem != null)
            {
                EditUserWindow ESW = new EditUserWindow(SelectedItem.Name);
                ESW.Owner = Application.Current.MainWindow;
                ESW.ShowDialog();
                if (ESW.Succsess == true)
                {
                    var iii = Items.FirstOrDefault(x => x.Name == SelectedItem.Name);

                    iii.Name = ESW.UserName;
                    RefreshItems?.Invoke(this, true);

                }
            }
        }

        

	}

}
