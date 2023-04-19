using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_DSI_G7.Models
{
    public class Ability_conx
    {
        public bool c_exist { get; set; }
        public bool Root { get; set; }
        public int id { get; set; }

        public bool active { get; set; }



        public Ability_conx() { }
    }
    public class emerald_inf
    {
        public int type;
        public int cost;
    }
    public class Ability
    {
        public bool rootActive { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string Description { get; set; }
        public int level { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public List<emerald_inf> Emerald_list { get; set; }

        public List<Ability_conx> lines { get; set; } //4 dir , up, down, left, right

        public Ability() { }
    }

    public class AbilityModel
    {
        public static List<Ability> Ability_ = new List<Ability>()
        {
            new Ability()
            {
                rootActive = true,
                level=3,
                Id = 0,
                Name = "Ability_0",
                ImageFile = "Assets\\habilidades\\Icon1.png",
                Description="hola",
                Row=2, Col=6,
                Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=true,Root=true,id=1},
                    new Ability_conx(){c_exist=true,Root=true,id=2,active=true},
                    new Ability_conx(){c_exist=true,Root=true,id=3,active=true},
                    new Ability_conx(){c_exist=true,Root=true,id=4,active=true},
                },

             },
             new Ability()
            {
                rootActive=true,
                Id = 1,
                Name = "Ability_1",
                ImageFile = "Assets\\habilidades\\Icon2.png",
                Description="hola",
                Row=1, Col=6,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=1 },
                    new emerald_inf() { type=3,cost=1 },
                },
                   lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=0},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                },
             },
            new Ability()
            {
                level=2,
                rootActive=true,
                Id = 2,
                Name = "Ability_2",
                ImageFile = "Assets\\habilidades\\Icon3.png",
                Description="hola",
                Row=3, Col=6,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                    new emerald_inf() { type=2,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=true,Root=false,id=0,active=true},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=true,id=5},
                    new Ability_conx(){c_exist=true,Root=true,id=6},
                },
             },
            new Ability()
            {
                level=1,
                rootActive=true,
                Id = 3,
                Name = "Ability_3",
                ImageFile = "Assets\\habilidades\\Icon4.png",
                Description="hola",
                Row=2, Col=4,
                Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=true,Root=true,id=13},
                    new Ability_conx(){c_exist=true,Root=true,id=14},
                    new Ability_conx(){c_exist=true,Root=true,id=16},
                    new Ability_conx(){c_exist=true,Root=false,id=0, active = true},
                },
             },
            new Ability()
            {
                level = 1,
                rootActive=true,
                Id = 4,
                Name = "Ability_4",
                ImageFile = "Assets\\habilidades\\Icon5.png",
                Description="hola",
                Row=2, Col=8,
                Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=true,Root=true,id=9},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=0, active = true},
                    new Ability_conx(){c_exist=false},
                },
             },
            new Ability()
            {
                 rootActive=true,
                Id = 5,
                Name = "Ability_5",
                ImageFile = "Assets\\habilidades\\Icon6.png",
                Description="hola",
                Row=3, Col=5,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=2},
                },
             },
            new Ability()
            {
                 rootActive=true,
                Id = 6,
                Name = "Ability_6",
                ImageFile = "Assets\\habilidades\\Icon7.png",
                Description="hola",
                Row=3, Col=8,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=2},
                    new Ability_conx(){c_exist=true,Root=true,id=7},
                },
             },
            new Ability()
            {
                Id = 7,
                Name = "Ability_7",
                ImageFile = "Assets\\habilidades\\Icon8.png",
                Description="hola",
                Row=3, Col=10,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=6},
                    new Ability_conx(){c_exist=true,Root=true,id=8},
                },
             },
             new Ability()
            {
                Id = 8,
                Name = "Ability_8",
                ImageFile = "Assets\\habilidades\\Icon9.png",
                Description="hola",
                Row=3, Col=12,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=7},
                    new Ability_conx(){c_exist=false},
                },
             },
              new Ability()
            {
                Id = 9,
               rootActive=true,
                Name = "Ability_9",
                ImageFile = "Assets\\habilidades\\Icon10.png",
                Description="hola",
                Row=0, Col=8,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=4},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=true,id=10},
                },
             },
               new Ability()
            {
                Id = 10,
                Name = "Ability_10",
                ImageFile = "Assets\\habilidades\\Icon11.png",
                Description="hola",
                Row=0, Col=10,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=true,id=12},
                    new Ability_conx(){c_exist=true,Root=false,id=9},
                    new Ability_conx(){c_exist=true,Root=true,id=11},
                },
             },
               new Ability()
            {
                Id = 11,
                Name = "Ability_11",
                ImageFile = "Assets\\habilidades\\Icon12.png",
                Description="hola",
                Row=0, Col=12,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=10},
                    new Ability_conx(){c_exist=false},

                },
             },
               new Ability()
            {
                Id = 12,
                Name = "Ability_12",
                ImageFile = "Assets\\habilidades\\Icon13.png",
                Description="hola",
                Row=1, Col=10,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=true,Root=false,id=10},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                },
             },
               new Ability()
            {
                   rootActive=true,
                Id = 13,
                Name = "Ability_13",
                ImageFile = "Assets\\habilidades\\Icon14.png",
                Description="hola",
                Row=1, Col=4,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=3},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                },
             },
                new Ability()
            {
                rootActive=true,
                Id = 14,
                Name = "Ability_14",
                ImageFile = "Assets\\habilidades\\Icon15.png",
                Description="hola",
                Row=4, Col=4,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=true,Root=false,id=3},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=true,id=15},
                    new Ability_conx(){c_exist=false},
                },
             },
                 new Ability()
            {
                Id = 15,
                Name = "Ability_15",
                ImageFile = "Assets\\habilidades\\Icon16.png",
                Description="hola",
                Row=4, Col=2,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=14},
                },
             },
                  new Ability()
            {
                rootActive=true,
                Id = 16,
                Name = "Ability_16",
                ImageFile = "Assets\\habilidades\\Icon17.png",
                Description="hola",
                Row=2, Col=2,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=true,Root=true,id=17},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=true,id=18},
                    new Ability_conx(){c_exist=true,Root=false,id=3},
                },
             },
                  new Ability()
            {
                Id = 17,
                Name = "Ability_17",
                ImageFile = "Assets\\habilidades\\Icon18.png",
                Description="hola",
                Row=0, Col=2,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=16},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                },
             },
                  new Ability()
            {
                Id = 18,
                Name = "Ability_18",
                ImageFile = "Assets\\habilidades\\Icon19.png",
                Description="hola",
                Row=2, Col=0,
                 Emerald_list=new List<emerald_inf>()
                {
                    new emerald_inf() { type=0,cost=1 },
                    new emerald_inf() { type=1,cost=2 },
                },
                lines=new List<Ability_conx>()
                {
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=false},
                    new Ability_conx(){c_exist=true,Root=false,id=16},
                },
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
