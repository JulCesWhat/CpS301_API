using System;
using System.Collections.Generic;

namespace CpS301_API.Models
{
    public partial class Eventtype
    {
        public Eventtype()
        {
            Serviceevent = new HashSet<Serviceevent>();
        }

        public int EventTypeId { get; set; }
        public string Description { get; set; }

        public ICollection<Serviceevent> Serviceevent { get; set; }
    }
}
