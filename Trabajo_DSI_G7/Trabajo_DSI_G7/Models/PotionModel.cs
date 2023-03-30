using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_DSI_G7.Models
{
    public class PotionModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        //public Image Img;
        public string Explicacion { get; set; }
        //public estados Estado { get; set; }
        public int Energia { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int RX { get; set; }
        public int RY { get; set; }
    }
}
