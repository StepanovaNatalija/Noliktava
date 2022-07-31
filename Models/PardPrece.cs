using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Noliktava.Models
{
    public class PardPrece
    {
        public int Id { get; set; }
        public int PrecKods { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime Datums { get; set; }
        public int Skaits { get; set; }
        public PardPrece()
        {

        }

    }
}
