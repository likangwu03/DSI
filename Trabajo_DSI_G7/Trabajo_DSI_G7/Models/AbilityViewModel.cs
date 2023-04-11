using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + p.ImageFile;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 50;
            Img.Height = 50;

            CCImg = new ContentControl();
            CCImg.Content = Img;

            CCImg.UseSystemFocusVisuals = true;
        }

    }

    public class AbilityVM_1 : Ability
    {
        public Image Img;
        public ContentControl CCImg;
        public AbilityVM_1(Ability p)
        {
            Id = p.Id;
            Name = p.Name;
            ImageFile = p.ImageFile;
            Description = p.Description;
            Row = p.Row;
            Col = p.Col;
            level = p.level;

            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + p.ImageFile;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
        
            CCImg = new ContentControl();
            CCImg.Content = Img;

            CCImg.UseSystemFocusVisuals = true;
        }

    }
}
