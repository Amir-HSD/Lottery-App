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
using Wpf.Ui.Controls;
using Wpf.Ui;
using System.Threading;
using Wpf.Ui.Extensions;
using Lottery_App.Model;

namespace Lottery_App.View
{
    /// <summary>
    /// Interaction logic for LotteryPage.xaml
    /// </summary>
    public partial class LotteryPage : Page
    {
        LotteryViewModel MWVM = new LotteryViewModel();
        public LotteryPage()
        {
            InitializeComponent();
            MWVM.ShowMessageRequested += ShowMessage;
            DataContext = MWVM;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private async void ShowMessage(object sender, MsgBoxProp msgBoxProp)
        {
            var MessageBox = new Wpf.Ui.Controls.MessageBox
            {
                Title = msgBoxProp.Title,
                Content = msgBoxProp.Content,
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = msgBoxProp.ButtonText,
            };
            var result = await MessageBox.ShowDialogAsync();
            MWVM.Result = result.ToString().Equals("Primary");
        }

    }
}
