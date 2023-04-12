using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Trabajo_DSI_G7.Models
{
    public class EnemyVM : Enemy
    {
        public Image Img;
        public ContentControl CCImg;
        public int Zoom;
        public EnemyVM(Enemy enemy)
        {
            Id = enemy.Id;
            Name = enemy.Name;
            MaxLife=enemy.MaxLife;
            ActLife=enemy.ActLife;
            ImageFile = enemy.ImageFile;
            AbilityId=enemy.AbilityId;
            Abilities=enemy.Abilities;
            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + enemy.ImageFile;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 50;
            Img.Height = 50;
            CCImg = new ContentControl();
            CCImg.Content = Img;
            CCImg.UseSystemFocusVisuals = true;

        }
    }
}
