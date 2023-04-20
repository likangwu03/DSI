using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_DSI_G7.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Trabajo_DSI_G7.Game
{
    public class ShopLogic : ObservableObject
    {
        Game.GameManager gm;
        private int money_;
        private int actLife_;
        public int money
        {
            get { return money_; }
            set
            {
                Set(ref money_, value);
                RaisePropertyChanged(nameof(money));
            }
        }
        public int actLife
        {
            get { return actLife_; }
            set
            {
                Set(ref actLife_, value);
                RaisePropertyChanged(nameof(actLife));
            }
        }



        private ObservableCollection<PotionVM> PotionList_;
        public ObservableCollection<PotionVM> PotionList
        {
            get { return PotionList_; }
            set
            {
                Set(ref PotionList_, value);
                RaisePropertyChanged(nameof(PotionList));
            }

        }
        private PotionVM ActPotion_;
        public PotionVM ActPotion
        {
            get { return ActPotion_; }
            set
            {
                Set(ref ActPotion_, value);
                RaisePropertyChanged(nameof(ActPotion));
            }
        }

        private async void Posion_ItemClick(object sender, ItemClickEventArgs e)
        {
            ContentControl O = FocusManager.GetFocusedElement() as ContentControl;
            ActPotion = O.DataContext as PotionVM;
            RaisePropertyChanged(nameof(ActPotion));
        }
    }
}
