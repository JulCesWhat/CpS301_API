using System;
using System.Collections.Generic;

namespace CpS301_API.Models
{
    public partial class Ensemble
    {
        public Ensemble()
        {
            Ensembleperson = new HashSet<Ensembleperson>();
            Serviceevent = new HashSet<Serviceevent>();
        }

        public int EnsembleId { get; set; }
        public string Name { get; set; }

        public ICollection<Ensembleperson> Ensembleperson { get; set; }
        public ICollection<Serviceevent> Serviceevent { get; set; }
    }
}
