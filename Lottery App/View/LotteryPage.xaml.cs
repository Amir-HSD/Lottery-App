using Lottery_App.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for LotteryPage.xaml
    /// </summary>
    public partial class LotteryPage : Page
    {
        
        public LotteryPage()
        {
            InitializeComponent();
            LotteryViewModel MWVM = new LotteryViewModel();
            DataContext = MWVM;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
