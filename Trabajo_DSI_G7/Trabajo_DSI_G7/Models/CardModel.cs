using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_DSI_G7.Models
{
    public enum CostType { Energy,Magic}
    public enum CardType { Veneno,Ataque,Defensa,Poder,Cura}
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string Description { get; set; }
        public CostType Type { get; set; }
        public CardType CardType { get; set; }
        public int Cost { get; set; }

        public Card() { }
    }
    public class CardModel
    {
        public static List<Card> Cards = new List<Card>()
        {
            new Card()
            {
                Id = 0,
                Name = "Cura",
                ImageFile = "Assets\\cartas\\cura.png",
                Description="hola",
                Type=CostType.Magic,
                CardType=CardType.Cura,
                Cost=1,

             },
            new Card()
            {
                Id = 1,
                Name = "Defensa",
                ImageFile = "Assets\\cartas\\defensa.png",
                Description="hola",
                Type=CostType.Energy,
                CardType=CardType.Defensa,
                Cost=3,
             },
            new Card()
            {
                Id = 2,
                Name = "Fuerza",
                ImageFile = "Assets\\cartas\\fuerza.png",
                Description="hola",
                Type=CostType.Energy,
                CardType=CardType.Ataque,
                Cost=2,
             },
             new Card()
            {
                Id = 3,
                Name = "Veneno",
                ImageFile = "Assets\\cartas\\veneno.png",
                Description="hola",
                Type=CostType.Magic,
                CardType=CardType.Veneno,
                Cost=6,
             },
              new Card()
            {
                Id = 4,
                Name = "Poder",
                ImageFile = "Assets\\cartas\\poder.png",
                Description="hola",
                Type=CostType.Magic,
                CardType=CardType.Poder,
                Cost=5,
             },
               new Card()
            {
                Id = 5,
                Name = "Aux1",
                ImageFile = "Assets\\cartas\\aux1.png",
                Description="hola",
                Type=CostType.Magic,
                CardType=CardType.Cura,
                Cost=1,

             },
            new Card()
            {
                Id = 6,
                Name = "Aux2",
                ImageFile = "Assets\\cartas\\aux2.png",
                Description="hola",
                Type=CostType.Energy,
                CardType=CardType.Defensa,
                Cost=3,
             },
            new Card()
            {
                Id = 7,
                Name = "Aux3",
                ImageFile = "Assets\\cartas\\aux3.png",
                Description="hola",
                Type=CostType.Energy,
                CardType=CardType.Ataque,
                Cost=2,
             },
             new Card()
            {
                Id = 8,
                Name = "Aux5",
                ImageFile = "Assets\\cartas\\aux5.png",
                Description="hola",
                Type=CostType.Magic,
                CardType=CardType.Poder,
                Cost=6,
             },
              new Card()
            {
                Id = 9,
                Name = "Aux4",
                ImageFile = "Assets\\cartas\\aux4.png",
                Description="hola",
                Type=CostType.Magic,
                CardType=CardType.Cura,
                Cost=5,
             }

          };


        public static IList<Card> GetAllDrones()
        {
            return Cards;
        }

        public static Card GetEnemyById(int id)
        {
            return Cards[id];
        }
    }
}

