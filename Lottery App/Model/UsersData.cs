using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lottery_App.Model
{
    public class UsersData
    {
        private static UsersData instance;
        public static UsersData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsersData();
                }
                return instance;
            }
        }

        public ObservableCollection<Item> Items { get; set; }

        public UsersData()
        {
            Items = new ObservableCollection<Item>();
        }

    }
}
