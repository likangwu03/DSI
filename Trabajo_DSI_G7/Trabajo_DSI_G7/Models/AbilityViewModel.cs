﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Trabajo_DSI_G7.Models
{

    //no seria crea desde pagina que necesitamos los VM?
    public class AbilityVM : Ability
    {
        public Image Img;
        public ContentControl CCImg;
        
        public AbilityVM(Ability p)
        {
            Id = p.Id;
            Name = p.Name;
            ImageFile = p.ImageFile;
            Description = p.Description;
            Row=p.Row;
            Col=p.Col;
            level=p.level;
            lines=p.lines;
            Emerald_list=p.Emerald_list;

            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + p.ImageFile;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 50;
            Img.Height = 50;

            CCImg = new ContentControl();
            CCImg.Content = Img;

            CCImg.UseSystemFocusVisuals = true;
        }

        public bool Active()
        {
            return level > 0;
        }

        public double Opacity_Img()
        {
            if (Active()) return 1;
            else return 0.5;
        }

        public Visibility Visibility_()
        {
            if (Active()) return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public double LineExist(int i)
        {
            if (lines[i].c_exist) return 1;
            return 0;
        }

      
    }
}