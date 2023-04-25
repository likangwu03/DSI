using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_DSI_G7.Models;
using Windows.UI.Xaml;
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
                gm.money = money;
            }
        }
        public int actLife
        {
            get { return actLife_; }
            set
            {
                Set(ref actLife_, value);
            }
        }



        private int num = 0;
        public int Num
        {
            get { return num; }
            set
            {
                Set(ref num, value);
            }
        }

        private int total = 0;
        public int Total
        {
            get { return total; }
            set
            {
                Set(ref total, value);
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
                RaisePropertyChanged(nameof(PotionList));
            }
        }

        public ShopLogic(GameManager gm)
        {
            this.gm = gm;
            this.money = gm.money;
            this.actLife = gm.maxLife;
            PotionList = gm.PotionList;
            ActPotion = PotionList[0];
        }


        public void Posion_ItemClick(object sender, ItemClickEventArgs e)
        {
            Total = 0;
            Num = 0;
            RaisePropertyChanged(nameof(CanBuy));
            ContentControl O = FocusManager.GetFocusedElement() as ContentControl;
            ActPotion = O.Content as PotionVM;
        }

        public bool CanBuy()
        {
            return Total < money;
        }

        public void Buy_Posion()
        {
            money -= Total;
            PotionList[ActPotion.Id] = null;
            ActPotion.Amount += Num;
            PotionList[ActPotion.Id] = ActPotion;
            RaisePropertyChanged(nameof(CanBuy));
        }


        public void sub_ItemClick(object sender, RoutedEventArgs e)
        {
            if (Num > 1) Num--;
            Total = Num * ActPotion.Price;
            RaisePropertyChanged(nameof(CanBuy));
        }

        public void add_ItemClick(object sender, RoutedEventArgs e)
        {
            Num++;
            Total = Num * ActPotion.Price;
            RaisePropertyChanged(nameof(CanBuy));
        }



    }
}
