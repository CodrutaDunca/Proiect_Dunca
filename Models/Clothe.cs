using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Proiect_Dunca.Models
{
    public class Clothe
    {
        public int ID { get; set; }
        [Display(Name = "Clothe Title")]
        public string Brand { get; set; }
        public string Type { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int DesignerID { get; set; }
        public Designer Designer { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
