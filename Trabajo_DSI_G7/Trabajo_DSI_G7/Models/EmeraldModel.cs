using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_DSI_G7.Models
{
    public class Emerald
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public Emerald() { }
    }

    public class EmeraldModel
    {
        public static List<Emerald> Emeralds = new List<Emerald>()
        {
            new Emerald() {
                Id=0,
                Name="Emerald_0",
                ImageFile="Assets\\esmeraldas\\bg_13.png",
                Description="..........",
                Amount=10,
                Price=100,
            },
            new Emerald() {
                Id=1,
                Name="Emerald_1",
                ImageFile="Assets\\esmeraldas\\gg_22.png",
                Description="..........",
                Amount=10,
                Price=100,
            },
            new Emerald() {
                Id=2,
                Name="Emerald_2",
                ImageFile="Assets\\esmeraldas\\rg_08.png",
                Description="..........",
                Amount=10,
                Price=100,
            },
            new Emerald() {
                Id=3,
                Name="Emerald_3",
                ImageFile="Assets\\esmeraldas\\sg_05.png",
                Description="..........",
                Amount=10,
                Price=100,
            }
        };


        public static IList<Emerald> GetAllEmeralds()
        {
            return Emeralds;
        }
    } 
}
