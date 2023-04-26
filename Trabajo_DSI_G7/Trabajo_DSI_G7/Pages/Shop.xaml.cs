using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Trabajo_DSI_G7.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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

    public sealed partial class Shop : Page
    {
        Game.GameManager gm;
        Game.ShopLogic Logic;
        bool exit_;
        public Shop()
        {
            this.InitializeComponent();           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e?.Parameter is Game.GameManager gameManager)
            {
                gm = gameManager;
                Logic = new Game.ShopLogic(gm);
                exit_ = true;
            }
            base.OnNavigatedTo(e);
        }

        private void OnCloseBuyClick(object sender, RoutedEventArgs e)
        {
            exit_ = true;
            ShopWindow.Hide();
            gm.playClickedSound();
        }
        private async void Posion_ItemClick(object sender, ItemClickEventArgs e)
        {
            Logic.Posion_ItemClick(sender, e);
            if (Logic.ActPotion.Active_())
            {
                exit_ = false;
                ShopWindow.XamlRoot = this.Content.XamlRoot;
                await ShopWindow.ShowAsync();
            }
            gm.playClickedSound();
        }

        private void OptionsBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Frame.CanGoBack) return;
            Frame.GoBack();
            gm.playClickedSound();
        }

        private void Page_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.GamepadLeftShoulder)
            {            
                FocusManager.TryMoveFocus(FocusNavigationDirection.Previous);
            }
            else if (e.Key == VirtualKey.GamepadRightShoulder)
            {
                FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
            }
            else if (e.Key == VirtualKey.Escape )
            {
                if (exit_)
                {
                    if (!Frame.CanGoBack) return;
                    Frame.GoBack();
                }
                else
                {
                    exit_ = true;
                }
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Logic.Buy_Posion();
            gm.playClickedSound();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Logic.add_ItemClick(sender, e);
        }
        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            Logic.sub_ItemClick(sender, e);
        }
    }
}
