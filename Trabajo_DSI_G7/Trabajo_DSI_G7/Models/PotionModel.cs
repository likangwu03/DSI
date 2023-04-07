using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_DSI_G7.Models
{
    public class Potion { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; }
        //public Image Img;
        public string Explication { get; set; }

        public Potion() { }
    }
    public class PotionModel
    {
        public static List<Potion> Potion = new List<Potion>()
        {
            new Potion()
            {
                Id = 0,
                Name = "Potion1",
                ImageFile = "Assets\\icons\\potion_01a.png",
                Explication="poción",
             },
            new Potion()
            {
                Id = 1,
                Name = "Potion2",
                ImageFile = "Assets\\icons\\potion_02b.png",
               Explication="poción",
             },
            new Potion()
            {
                Id = 2,
                Name = "Potion3",
                ImageFile = "Assets\\icons\\potion_03f.png",
                Explication="poción",
             }
          };


        public static IList<Potion> GetAllPotions()
        {
            return Potion;
        }

        public static Potion GetPotionById(int id)
        {
            return Potion[id];
        }

    }
}
