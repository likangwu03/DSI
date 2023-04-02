using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Trabajo_DSI_G7.Models
{
    public class CardVM : Card
    {
        public Image Img;
        public ContentControl CCImg;
        public int Zoom;
        public CardVM(Card card)
        {
            Id = card.Id;
            Name = card.Name;
            Description = card.Description;
            ImageFile = card.ImageFile;
            Type = card.Type;
            Cost = card.Cost;

            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + card.ImageFile;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 50;
            Img.Height = 50;
            CCImg = new ContentControl();
            CCImg.Content = Img;
            CCImg.UseSystemFocusVisuals = true;

        }
    }
}
