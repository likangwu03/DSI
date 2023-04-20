﻿using Microsoft.Toolkit.Uwp.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class SkillTree : Page
    {
        Game.SkillTreeLogic Logic;

        Game.GameManager gm;
       

        public SkillTree()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // If e.Parameter is a string, set the TextBlock's text with it.
            if (e?.Parameter is Game.GameManager gameManager)
            {
                Logic = new Game.SkillTreeLogic(gameManager);
                gm = gameManager;
            }
            base.OnNavigatedTo(e);
        }

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            AbilityWindow.Hide();
        }

        private async void Ability_Click(object sender, RoutedEventArgs e)
        {
            Logic.Ability_Click(sender, e);
            if (Logic.ActAbility.rootActive)
            {
                AbilityWindow.XamlRoot = this.Content.XamlRoot;
                await AbilityWindow.ShowAsync();
            }
        }

        private void OptionsBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Frame.CanGoBack) return;
            Frame.GoBack();
        }

        private void Mejorar_Button_Click(object sender, RoutedEventArgs e)
        {
            Logic.Mejorar_Button_Click(sender, e);
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
