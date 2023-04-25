using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Trabajo_DSI_G7.Models
{
    public class PotionVM : Potion
    {
        public Image Img;
        public ContentControl CCImg;
        public int Zoom;
        public PotionVM(Potion p)
        {
            Id = p.Id;
            Name = p.Name;
            ImageFile = p.ImageFile;
            Description = p.Description;
            Amount = p.Amount;
            Attack = p.Attack;
            Price = p.Price;

            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + p.ImageFile;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 50;
            Img.Height = 50;

            CCImg = new ContentControl();
            CCImg.Content = Img;
            CCImg.UseSystemFocusVisuals = true;
        }

        public Visibility ActivBLock()
        {
            if (Id < 8)
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;

        }
        public Visibility ActiveDescripcion()
        {
            if (Id < 8)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public bool Active_()
        {
            return Id < 8;
        }

        public double Opacity_Img()
        {
            if (Active_()) return 1;

            return 0.4;
        }

        public string P_Amount()
        {
            return Amount.ToString();
        }
    }
}
