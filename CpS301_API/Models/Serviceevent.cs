using System;
using System.Collections.Generic;

namespace CpS301_API.Models
{
    public partial class Serviceevent
    {
        public int EventId { get; set; }
        public int ServiceId { get; set; }
        public int SeqNum { get; set; }
        public int? EventTypeId { get; set; }
        public string Notes { get; set; }
        public string Confirmed { get; set; }
        public int? PersonId { get; set; }
        public int? EnsembleId { get; set; }
        public int? SongId { get; set; }

        public Ensemble Ensemble { get; set; }
        public Eventtype EventType { get; set; }
        public Person Person { get; set; }
        public Service Service { get; set; }
        public Song Song { get; set; }
    }
}
