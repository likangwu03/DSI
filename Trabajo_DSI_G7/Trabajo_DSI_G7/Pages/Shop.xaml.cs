using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Trabajo_DSI_G7.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Trabajo_DSI_G7.Pages
{

    public class AspectContentControl : ContentControl
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            return new Size(availableSize.Width/5.5, availableSize.Width / 3.5);
        }
    }
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Shop : Page
    {
        Game.GameManager gm;
        public ObservableCollection<PotionVM> PotionList;
        public PotionVM actPotion;
        public int money { get; set; }
        public int actLife { get; set; }
        public Shop()
        {
            this.InitializeComponent();
            
        }

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // If e.Parameter is a string, set the TextBlock's text with it.
            if (e?.Parameter is Game.GameManager gameManager)
            {
                gm = gameManager;
                this.money = gameManager.money;
                this.actLife=gameManager.actLife;
                PotionList=gameManager.PotionList;
                actPotion= PotionList.First();
            }
            base.OnNavigatedTo(e);
        }

    }
}
