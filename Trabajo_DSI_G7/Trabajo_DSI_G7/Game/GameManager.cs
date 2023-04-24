using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trabajo_DSI_G7.Models;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Trabajo_DSI_G7.Game
{
    public class GameManager : ObservableObject
    {
        public ObservableCollection<PotionVM> PotionList { get; } = new ObservableCollection<PotionVM>(); //de la lista
        public ObservableCollection<AbilityVM> AbilityList { get; } = new ObservableCollection<AbilityVM>(); //de la lista
        public ObservableCollection<EnemyVM> EnemyList { get; } = new ObservableCollection<EnemyVM>(); //de la lista
        public ObservableCollection<CardVM> CardList { get; } = new ObservableCollection<CardVM>(); //de la lista
        public ObservableCollection<EmeraldVM> EmeraldList { get; } = new ObservableCollection<EmeraldVM>(); //de la lista

        private MediaPlayer music { get; set; }
        public MediaPlayer buttonHoverSound { get; set; }
        public MediaPlayer buttonClickedSound { get; set; }

        public double musicVolume
        {
            get { return music.Volume * 100; }
            set
            {
                music.Volume = value / 100;
                RaisePropertyChanged(nameof(musicVolume));
            }
        }
        public double soundVolume
        {
            get { return buttonHoverSound.Volume * 100; }
            set
            {
                buttonHoverSound.Volume = value / 100;
                buttonClickedSound.Volume = value / 100;
                RaisePropertyChanged(nameof(soundVolume));
            }
        }
        public int money { get; set; }
        public int maxLife { get; set; }
        public int maxMagic { get; set; }
        public int maxEnergy { get; set; }
        public string name { get; set; }
        public string level { get; set; }

        public GameManager()
        {
            inicializeSounds();
            inicializePotion();
            inicializeEnemy();
            inicializeCard();
            inicializeAbility();
            inicializeEmerald();

            //predeterminado
            this.money = 3210;
            this.maxLife = 200;
            this.maxMagic = 20;
            this.maxEnergy = 5;
            this.name = "Name";
            this.level = "Nivel 3";


        }
        private void inicializeSounds()
        {

            music = new MediaPlayer();
            music.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/sonidos/rpg_village02_loop.mp3"));
            music.Play();
            music.IsLoopingEnabled = true;
            musicVolume = 50;

            buttonClickedSound = new MediaPlayer();
            buttonClickedSound.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/sonidos/02_chest_close_3.wav"));

            buttonHoverSound = new MediaPlayer();
            buttonHoverSound.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/sonidos/select.mp3"));

            soundVolume = 50;
        }

        public PotionVM getPotion(int i)
        {
            return PotionList.ElementAt(i);
        }
        public EnemyVM getEnemy(int i)
        {
            return EnemyList.ElementAt(i);
        }
        public void inicializeCard()
        {
            if (CardList != null)
                foreach (Card card in CardModel.GetAllDrones())
                {
                    CardVM VMitem = new CardVM(card);
                    CardList.Add(VMitem);
                }
        }
        //devuelve una copia de la lista de cartas
        public void copyCards(ObservableCollection<CardVM> list)
        {
            if (CardList != null)
                foreach (Card card in CardList)
                {
                    CardVM VMitem = new CardVM(card);
                    list.Add(VMitem);
                }
        }
        //devuelve una copia de la lista de enemigos
        public void copyEnemies(ObservableCollection<EnemyVM> list)
        {
            if (CardList != null)
                foreach (Enemy enemy in EnemyList)
                {
                    EnemyVM VMitem = new EnemyVM(enemy);
                    list.Add(VMitem);
                }
        }
        public void inicializeEnemy()
        {
            if (EnemyList != null)
                foreach (Enemy enemy in EnemyModel.GetAllEnemies())
                {
                    EnemyVM VMitem = new EnemyVM(enemy);
                    VMitem.Abilities = new List<AbilityVM>();
                    for (int i = 0; i < VMitem.AbilityId.Count; i++) //cargar habilidades
                        VMitem.Abilities.Add(new AbilityVM(AbilityModel.GetAllAbilitys()[VMitem.AbilityId[i]]));
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

        public void inicializeAbility()
        {
            // Cosntruye las listas de ModelView a partir de la lista Modelo 
            if (PotionList != null)
                foreach (Ability dron in AbilityModel.GetAllAbilitys())
                {

                    AbilityVM VMitem = new AbilityVM(dron);
                    AbilityList.Add(VMitem);
                }
        }

        public void inicializeEmerald()
        {
            if (EmeraldList != null)
            {
                foreach (Emerald emerald in EmeraldModel.GetAllEmeralds())
                {
                    EmeraldVM VMitem = new EmeraldVM(emerald);
                    EmeraldList.Add(VMitem);
                }
            }
        }

        public void playClickedSound()
        {
            buttonClickedSound.Play();
        }
        public void playHoverSound()
        {
            buttonHoverSound.Play();
        }

    }
}
