using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_DSI_G7.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;

namespace Trabajo_DSI_G7.Game
{
    public class SkillTreeLogic: ObservableObject
    {
        GameManager gm;
        public ObservableCollection<AbilityVM> AbilityList;
        public ObservableCollection<EmeraldVM> EmeraldList;


        private AbilityVM _actAbility;

        public AbilityVM ActAbility
        {
            get { return _actAbility; }
            set
            {
                Set(ref _actAbility, value);
                RaisePropertyChanged(nameof(ActAbility));
            }
        }

        public void Ability_Click(object sender, RoutedEventArgs e)
        {
            ContentControl O = FocusManager.GetFocusedElement() as ContentControl;
            ActAbility = O.DataContext as AbilityVM;
            //AbilityWindow.XamlRoot = this.Content.XamlRoot;
            //await AbilityWindow.ShowAsync();
        }

        public SkillTreeLogic(GameManager gm_)
        {
            gm = gm_;
            AbilityList = gm_.AbilityList;
            EmeraldList = gm_.EmeraldList;
            ActAbility = AbilityList.First();

            foreach (AbilityVM ability in AbilityList)
            {
                ability.iniEmerald(EmeraldList);
            }
        }
    }
}
