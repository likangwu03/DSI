using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_DSI_G7.Models;
using Windows.UI.Xaml.Controls;

namespace Trabajo_DSI_G7.Game
{
    public class ShopLogic : ObservableObject
    {

        Game.GameManager gm;
        public ObservableCollection<PotionVM> PotionList;
        public PotionVM actPotion;
        public int money { get; set; }
        public int actLife { get; set; }

        private async void Posion_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
    }
}
