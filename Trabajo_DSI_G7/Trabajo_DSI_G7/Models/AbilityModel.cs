using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_DSI_G7.Models
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string Description { get; set; }
        
        public int level { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        List<EmeraldModel> models { get; set; }

        public Ability() { }
    }

    public class AbilityModel
    {
        public static List<Ability> Ability_ = new List<Ability>()
        {
            new Ability()
            {
                level=1,
                Id = 0,
                Name = "Ability_0",
                ImageFile = "Assets\\habilidades\\Icon2.png",
                Description="hola",
                Row=2, Col=6,
             },
             new Ability()
            {
                Id = 1,
                Name = "Ability_1",
                ImageFile = "Assets\\habilidades\\Icon1.png",
                Description="hola",
                Row=1, Col=6,
             }, 
            new Ability()
            {
                Id = 0,
                Name = "Ability_1",
                ImageFile = "Assets\\habilidades\\Icon3.png",
                Description="hola",
                Row=3, Col=6,
             },
            new Ability()
            {
                Id = 0,
                Name = "Ability_1",
                ImageFile = "Assets\\habilidades\\Icon4.png",
                Description="hola",
                Row=3, Col=8,
             },
            new Ability()
            {
                Id = 0,
                Name = "Ability_1",
                ImageFile = "Assets\\habilidades\\Icon1.png",
                Description="hola",
                Row=2, Col=5,
             },
            new Ability()
            {
                Id = 0,
                Name = "Ability_1",
                ImageFile = "Assets\\habilidades\\Icon1.png",
                Description="hola",
                Row=2, Col=10,
             },
            new Ability()
            {
                Id = 0,
                Name = "Ability_1",
                ImageFile = "Assets\\habilidades\\Icon1.png",
                Description="hola",
                Row=1, Col=5,
             },
            new Ability()
            {
                Id = 0,
                Name = "Ability_1",
                ImageFile = "Assets\\habilidades\\Icon1.png",
                Description="hola",
                Row=4, Col=5,
             },
        };

        public static IList<Ability> GetAllAbilitys()
        {
            return Ability_;
        }

        public static Ability GetPotionById(int id)
        {
            return Ability_[id];
        }
    }
}
