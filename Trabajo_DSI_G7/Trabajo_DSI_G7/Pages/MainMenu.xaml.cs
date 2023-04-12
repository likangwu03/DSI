using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Trabajo_DSI_G7.Game;
using Trabajo_DSI_G7.Models;
using Trabajo_DSI_G7;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        GameManager GM=null;
        public MainMenu()
        {
            
            this.InitializeComponent();
           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
  
            if (e?.Parameter is GameManager gm)
                this.GM = gm;

            base.OnNavigatedTo(e);
           
        }

        private void onButtonHolding(object sender, PointerRoutedEventArgs e)
        {
            Image img = (sender as Button).Content as Image;

            ((sender as Button).Content as Image).Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\Assets\\ui\\button_hover\\" + img.Name + "_hover.png"));

        }

        private void onButtonExit(object sender, PointerRoutedEventArgs e)
        {
            Image img = (sender as Button).Content as Image;

            ((sender as Button).Content as Image).Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\Assets\\ui\\button_yellow/" + img.Name + ".png"));
        }

        private async void ShowDialog_Click(object sender, RoutedEventArgs e)
        {
          
         
            ConfirmMenu.XamlRoot = this.Content.XamlRoot;
            await ConfirmMenu.ShowAsync();
        }

        private async void onSettingClick(object sender, RoutedEventArgs e)
        {
            MainMenuOptions.XamlRoot = this.Content.XamlRoot;
            await MainMenuOptions.ShowAsync();
        }

        private void OnCloseMenuOptionsClick(object sender, RoutedEventArgs e)
        {
            MainMenuOptions.Hide();
        }

        private void OnStartNewGameClick(object sender, RoutedEventArgs e)
        {
            ConfirmMenu.Hide();
            Frame.Navigate(typeof(InGame), GM);
        }

        private void OnCloseConfirmClick(object sender, RoutedEventArgs e)
        {
            ConfirmMenu.Hide();
        }

        private void OnSkillTreeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SkillTree), GM);

        }

        private void OnShopClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Shop), GM);

        }
    }
}
