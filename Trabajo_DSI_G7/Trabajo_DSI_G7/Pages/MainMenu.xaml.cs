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
using Windows.System;
using Trabajo_DSI_G7.Input;
using Windows.UI.Core;



// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Trabajo_DSI_G7.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        GameManager GM = null;
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

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
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
            GM.playClickedSound();
            ConfirmMenu.XamlRoot = this.Content.XamlRoot;
            await ConfirmMenu.ShowAsync();
        }

        private async void openOptionMenu()
        {
            MainMenuOptions.XamlRoot = this.Content.XamlRoot;
            await MainMenuOptions.ShowAsync();
        }
        private void onSettingClick(object sender, RoutedEventArgs e)
        {
            openOptionMenu();
            GM.playClickedSound();
        }
        private void OptionsKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.OriginalKey == VirtualKey.GamepadMenu)
                openOptionMenu();
        }

        private void OnCloseMenuOptionsClick(object sender, RoutedEventArgs e)
        {
            MainMenuOptions.Hide();
            GM.playClickedSound();
        }

        private void OnStartNewGameClick(object sender, RoutedEventArgs e)
        {
            ConfirmMenu.Hide();
            Frame.Navigate(typeof(InGame), GM);
            GM.playClickedSound();
        }

        private void OnCloseConfirmClick(object sender, RoutedEventArgs e)
        {
            ConfirmMenu.Hide();
            GM.playClickedSound();
        }

        private void OnSkillTreeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SkillTree), GM);
            GM.playClickedSound();

        }

        private void OnShopClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Shop), GM);
            GM.playClickedSound();

        }

        private void Page_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.GamepadLeftShoulder)
            {
                // Mimic Shift+Tab when user hits up arrow key.
                FocusManager.TryMoveFocus(FocusNavigationDirection.Previous);
            }
            else if (e.Key == VirtualKey.GamepadRightShoulder)
            {
                // Mimic Tab when user hits down arrow key.
                FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
            }
        }

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {

        }

        
    }
}
