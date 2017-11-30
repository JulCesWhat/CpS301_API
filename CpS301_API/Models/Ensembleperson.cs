using System;
using System.Collections.Generic;

namespace CpS301_API.Models
{
    public partial class Ensembleperson
    {
        public int EnsembleId { get; set; }
        public int PersonId { get; set; }

        public Ensemble Ensemble { get; set; }
        public Person Person { get; set; }
    }
}
