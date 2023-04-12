using Microsoft.Toolkit.Uwp.UI;
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
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class SkillTree : Page
    {
        Game.GameManager gm;
        public ObservableCollection<AbilityVM> AbilityList;
      
        public AbilityVM actAbility;

        public double w;
        public double h;
        public SkillTree()
        {
            this.InitializeComponent();

            //AddAbiityToGrid();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // If e.Parameter is a string, set the TextBlock's text with it.
            if (e?.Parameter is Game.GameManager gameManager)
            {
                gm = gameManager;
                AbilityList = gameManager.AbilityList;
                actAbility = AbilityList.First();
            }
            base.OnNavigatedTo(e);
        }
        
        public bool lineActive(int i,int id)
        {
            return AbilityList[id].Active() && AbilityList[id].lines[i].c_exist && AbilityList[AbilityList[id].lines[i].id].Active();
        }

        //public void AddAbiityToGrid()
        //{
        //    foreach (var ability in AbilityList)
        //    {
        //        //AbilityVM_1 abilityVM = new AbilityVM_1(ability);
        //        Grid a = new Grid();
        //        TextBlock t = new TextBlock()
        //        {
        //            Text = ability.Name,
        //        };
        //        a.Children.Add(t,1,1);
               
        //        AbilityGrid.Children.Add(t);
        //    }

        //    Grid grid = new Grid();
        //    grid.HorizontalAlignment = HorizontalAlignment.Center;
        //    grid.RowDefinitions.Add(new RowDefinition());
        //}
    }
}
