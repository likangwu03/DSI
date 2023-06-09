﻿using System;
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
                
                RaisePropertyChanged(nameof(ListaEmeralds));
                RaisePropertyChanged(nameof(EmeraldList));
                RaisePropertyChanged(nameof(lineActive));
                RaisePropertyChanged(nameof(abilityVM));
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
            if (i == 0) return 1;
            if (i == 1) return 0;
            if (i == 2) return 3;
            return 2;
        }

        public AbilityVM abilityVM(int i)
        {
            return AbilityList[i];
        }


        public void Mejorar_Button_Click(object sender, RoutedEventArgs e)
        {
            AbilityVM aux = ActAbility;
            AbilityVM aux2;       
            ActAbility= AbilityList[0];
            aux.level++;
            foreach (AbilityEmerald a in aux.list)
            {
                a.emeraldVM.Amount -= a.cost;
                EmeraldList[a.type] = a.emeraldVM;
            }

            for (int i = 0; i < aux.lines.Count; ++i)
            {
                if (aux.lines[i].c_exist)
                {
                    if (!aux.lines[i].Root)
                    {
                        aux.lines[i].active = true;
                        aux2 = AbilityList[aux.lines[i].id];
                        aux2.lines[getOther(i)].active = true;
                        AbilityList[aux.lines[i].id] = null;
                        AbilityList[aux.lines[i].id] = aux2;
                    }
                    else
                    {
                        aux2 = AbilityList[aux.lines[i].id];
                        AbilityList[aux.lines[i].id] = null;
                        aux2.rootActive = true;
                        AbilityList[aux.lines[i].id] = aux2;
                    }
                }
            }
            ActAbility = aux;
        }
    }
}
