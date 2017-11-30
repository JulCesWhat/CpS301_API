using System;
using System.Collections.Generic;

namespace CpS301_API.Models
{
    public partial class Personunavailable
    {
        public int PersonId { get; set; }
        public int ServiceId { get; set; }

        public Person Person { get; set; }
        public Service Service { get; set; }
    }
}
