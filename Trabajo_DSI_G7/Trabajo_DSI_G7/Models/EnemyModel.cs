using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_DSI_G7.Models
{
    public class Enemy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public int MaxLife { get; set; }
        public List<int> AbilityId { get; set; } //para buscar habilidad
        //public List<AbilityVM> Abilities { get; set; } //para buscar habilidad

        public Enemy() { }
    }
    public class EnemyModel
    {
        public static List<Enemy> Enemies = new List<Enemy>()
        {
            new Enemy()
            {
                Id = 0,
                Name = "Enemy1",
                ImageFile = "Assets\\enemigos\\pipo-enemy032b.png",
                MaxLife=200,
                AbilityId=new List<int>(){0,1,2}
                
             },
            new Enemy()
            {
                Id = 1,
                Name = "Enemy2",
                ImageFile = "Assets\\enemigos\\pipo-pipo-enemy040a.png",
                MaxLife=100,
                AbilityId=new List<int>(){0,1}
             },
            new Enemy()
            {
                Id = 2,
                Name = "Enemy3",
                ImageFile = "Assets\\enemigos\\pipo-pipo-enemy045b.png",
                MaxLife=300,
                AbilityId=new List<int>(){2}
             }
          };


        public static IList<Enemy> GetAllDrones()
        {
            return Enemies;
        }

        public static Enemy GetEnemyById(int id)
        {
            return Enemies[id];
        }

        public static void InitData()
        {
           // for (int i = 0; i < Enemies.Count; i++)
              //  for (int j = 0; j < Enemies[i].AbilityId.Count(); j++)
                  //  Enemies[i].Abilities.Add(Ability[Enemies[i].AbilityId[j]]);
        }
    }

}
