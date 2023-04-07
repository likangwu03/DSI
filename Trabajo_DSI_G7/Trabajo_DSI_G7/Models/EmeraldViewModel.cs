using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Trabajo_DSI_G7.Models
{
    public class EmeraldVM:Emerald
    {
        public Image Img;

        public EmeraldVM(Emerald e)
        {
            Id = e.Id;
            Name = e.Name;
            ImageFile = e.ImageFile;
            Description = e.Description;
            Amount = e.Amount;
            Price = e.Price;

            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + e.ImageFile;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 50;
            Img.Height = 50;
        }
    }
}
