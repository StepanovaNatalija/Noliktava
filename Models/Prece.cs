using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Noliktava.Models
{
    public class Prece
    {
        public int Id { get; set; }
        public int PrecKods { get; set; }
        public string Nosaukums { get; set; }
        public int PiegKods { get; set; }
        public int Daudzums { get; set; }
        [DataType(DataType.Currency)]
        public decimal Cena { get; set; }
        public Prece()
        {

        }
    }
}
