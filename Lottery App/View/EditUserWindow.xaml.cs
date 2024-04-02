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
using System.Windows.Shapes;

namespace Lottery_App.View
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public bool Succsess { get; set; }

        public EditUserWindow(string Name)
        {
            InitializeComponent();
            DataContext = this;
            UserName = Name;
            Succsess = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Succsess = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Succsess = false;
            this.Close();
        }
    }
}
