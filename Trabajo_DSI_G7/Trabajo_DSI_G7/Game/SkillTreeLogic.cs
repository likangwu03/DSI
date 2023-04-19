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
using Trabajo_DSI_G7.Pages;

namespace Trabajo_DSI_G7.Game
{
    public class SkillTreeLogic : ObservableObject
    {
        GameManager gm;
        private ObservableCollection<AbilityVM> AbilityList_;

        public ObservableCollection<AbilityVM> AbilityList
        {
            get { return AbilityList_; }
            set
            {
                Set(ref AbilityList_, value);
                RaisePropertyChanged(nameof(AbilityList));
            }
        }


        private ObservableCollection<EmeraldVM> EmeraldList_;

        public ObservableCollection<EmeraldVM> EmeraldList
        {
            get { return EmeraldList_; }
            set
            {
                Set(ref EmeraldList_, value);
                RaisePropertyChanged(nameof(EmeraldList));
            }
        }


        private AbilityVM _actAbility;

        public AbilityVM ActAbility
        {
            get { return _actAbility; }
            set
            {
                Set(ref _actAbility, value);
                RaisePropertyChanged(nameof(ActAbility));
                RaisePropertyChanged(nameof(CanUp));
            }
        }

        public void Ability_Click(object sender, RoutedEventArgs e)
        {
            ContentControl O = FocusManager.GetFocusedElement() as ContentControl;
            ActAbility = O.DataContext as AbilityVM;
        }

        public Visibility lineActive(int i, int id)
        {
            if (AbilityList[id].Active() && AbilityList[id].lines[i].c_exist && AbilityList[AbilityList[id].lines[i].id].Active())
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
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

        public bool CanUp()
        {
            if (ActAbility.level >= 3)
            {
                return false;
            }
            int i = 0;
            while (i < ActAbility.list.Count && ActAbility.list[i].cost <= ActAbility.list[i].emeraldVM.Amount) i++;

            return i == ActAbility.list.Count;
        }

        public List<AbilityEmerald> ListaEmeralds()
        {
            return ActAbility.list;
        }

        private int getOther(int i)
        {
            if(i==0) return 1;
            if(i==1) return 0;
            if(i==2) return 3;
            return 2;
        }

        public AbilityVM abilityVM(int i)
        {
            return AbilityList[i];
        }


        public void Mejorar_Button_Click(object sender, RoutedEventArgs e)
        {
            ActAbility.level++;
            foreach (AbilityEmerald a in ActAbility.list)
            {
                a.emeraldVM.Amount -= a.cost;
                EmeraldList[a.type] = a.emeraldVM;
            }

            for (int i=0;i<ActAbility.lines.Count;++i)
            {
                if (ActAbility.lines[i].c_exist)
                {
                    if (!ActAbility.lines[i].Root)
                    {
                        ActAbility.lines[i].active = true;
                        AbilityList[ActAbility.lines[i].id].lines[getOther(i)].active = true;
                    }
                    else
                    {
                        AbilityList[ActAbility.lines[i].id].rootActive = true;
                    }
                }
            }
            //ActAbility.lines[0].active = true;
            //ActAbility.lines[1].active = true;
            //ActAbility.lines[2].active = true;
            //ActAbility.lines[3].active = true;

            RaisePropertyChanged(nameof(ActAbility));
            RaisePropertyChanged(nameof(CanUp));
            RaisePropertyChanged(nameof(ListaEmeralds));
            RaisePropertyChanged(nameof(EmeraldList));
            RaisePropertyChanged(nameof(lineActive));
            RaisePropertyChanged(nameof(abilityVM));
        }
    }
}
