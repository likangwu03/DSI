using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_DSI_G7.Models
{
    public  class Ability
    {
        public string name { get; set; }
        public string description { get; set; }
        public string imagen { get; set; }

        List<EmeraldModel> models { get; set; }
    }
}
