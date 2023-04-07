using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trabajo_DSI_G7.Models;
using Windows.UI.Xaml.Media;

namespace Trabajo_DSI_G7.Game
{
    public class GameManager
    {
        public ObservableCollection<PotionVM> PotionList { get; } = new ObservableCollection<PotionVM>(); //de la lista
        public ObservableCollection<EnemyVM> EnemyList { get; } = new ObservableCollection<EnemyVM>(); //de la lista
        public ObservableCollection<CardVM> CardList { get; } = new ObservableCollection<CardVM>(); //de la lista
        public int money { get; set; }
        public int actLife { get; set; }
        public int maxLife { get; set; }
        public int actMagic { get; set; }
        public int maxMagic { get; set; }
        public int actEnergy { get; set; }
        public int maxEnergy { get; set; }
        public string name { get; set; }
        public string level { get; set; }

        public GameManager()
        {
            inicializePotion();
            inicializeEnemy();
            inicializeCard();

            this.money = 3210;
            this.maxLife = 200;
            this.maxMagic = 20;
            this.maxEnergy = 5;
            this.name = "Name";
            this.level = "Nivel 3";
            this.actLife = maxLife;
            this.actMagic = maxMagic;
            this.actLife = maxLife;
        }
        public ImageSource getPotion(int i)
        {
            return PotionList.ElementAt(i).Img.Source;
        }
        public EnemyVM getEnemy(int i)
        {
            return EnemyList.ElementAt(i);
        }
        public void inicializeCard()
        {
            if (CardList != null)
                foreach (Card dron in CardModel.GetAllDrones())
                {
                    CardVM VMitem = new CardVM(dron);
                    CardList.Add(VMitem);
                }
        }
        public void copyCards( ObservableCollection<CardVM> list)
        {
            if (CardList != null)
                foreach (Card dron in CardList)
                {
                    CardVM VMitem = new CardVM(dron);
                    list.Add(VMitem);
                }
        }
            public void inicializeEnemy()
        {
            if (EnemyList != null)
                foreach (Enemy dron in EnemyModel.GetAllDrones())
                {
                    EnemyVM VMitem = new EnemyVM(dron);
                    EnemyList.Add(VMitem);
                }
        }
        public void inicializePotion()
        {
            // Cosntruye las listas de ModelView a partir de la lista Modelo 
            if (PotionList != null)
                foreach (Potion dron in PotionModel.GetAllPotions())
                {
                    PotionVM VMitem = new PotionVM(dron);
                    PotionList.Add(VMitem);
                }

        }
    }
}
