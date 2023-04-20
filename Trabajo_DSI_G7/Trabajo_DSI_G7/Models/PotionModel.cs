using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_DSI_G7.Models
{
    public class Potion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int Attack { get; set; }
        public Potion() { }
    }
    public class PotionModel
    {
        public static List<Potion> Potions = new List<Potion>()
        {
            new Potion() {
                Id=0,
                Name="Potion_0",
                ImageFile="Assets\\icons\\potion_03g.png",
                Description="..........",
                Amount=1,
                Attack=20,
                Price=100,
            },
            new Potion() {
                Id=1,
                Name="Potion_1",
                ImageFile="Assets\\icons\\potion_02c.png",
                Description="..........",
                Amount=3,
                Attack=200,
                Price=100,
            },
            new Potion() {
                Id=2,
                Name="Potion_2",
                ImageFile="Assets\\icons\\potion_01c.png",
                Description="..........",
                Amount=3,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=3,
                Name="Potion_3",
                ImageFile="Assets\\icons\\potion_02e.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=4,
                Name="Potion_4",
                ImageFile="Assets\\icons\\potion_01b.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=5,
                Name="Potion_5",
                ImageFile="Assets\\icons\\potion_03b.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=6,
                Name="Potion_6",
                ImageFile="Assets\\icons\\potion_03d.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=7,
                Name="Potion_7",
                ImageFile="Assets\\icons\\potion_03a.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=8,
                Name="???",
                ImageFile="Assets\\icons\\potion_03a.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=9,
                Name="???",
                ImageFile="Assets\\icons\\potion_03a.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=10,
                Name="???",
                ImageFile="Assets\\icons\\potion_03a.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=11,
                Name="???",
                ImageFile="Assets\\icons\\potion_03a.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=12,
                Name="???",
                ImageFile="Assets\\icons\\potion_03a.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=13,
                Name="???",
                ImageFile="Assets\\icons\\potion_03a.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            },
            new Potion() {
                Id=14,
                Name="???",
                ImageFile="Assets\\icons\\potion_03a.png",
                Description="..........",
                Amount=0,
                Attack=100,
                Price=100,
            }
        };
        
        public static IList<Potion> GetAllPotions()
        {
            return Potions;
        }

        public static Potion GetPotionById(int id)
        {
            return Potions[id];
        }

    }
}
