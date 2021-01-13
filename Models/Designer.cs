using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Dunca.Models
{
    public class Designer
    {
        public int ID { get; set; }
        public string DesignerName { get; set; }
        public ICollection<Clothe> Clothes { get; set; }

    }
}
