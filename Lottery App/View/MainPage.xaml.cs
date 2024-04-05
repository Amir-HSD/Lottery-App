using Lottery_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lottery_App.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
            Items = new ObservableCollection<Item>(UsersData.Instance.Items);
        }

        public ObservableCollection<Item> Items
        {
            get { return UsersData.Instance.Items; }
            set { UsersData.Instance.Items = value; }
        }

        

    }
}
