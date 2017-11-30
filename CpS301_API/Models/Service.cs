using System;
using System.Collections.Generic;

namespace CpS301_API.Models
{
    public partial class Service
    {
        public Service()
        {
            Personunavailable = new HashSet<Personunavailable>();
            Serviceevent = new HashSet<Serviceevent>();
        }

        public int ServiceId { get; set; }
        public DateTime SvcDateTime { get; set; }
        public string Theme { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public string OrganistConf { get; set; }
        public string SongleaderConf { get; set; }
        public string PianistConf { get; set; }
        public int? OrganistId { get; set; }
        public int? SongleaderId { get; set; }
        public int? PianistId { get; set; }

        public Person Organist { get; set; }
        public Person Pianist { get; set; }
        public Person Songleader { get; set; }
        public ICollection<Personunavailable> Personunavailable { get; set; }
        public ICollection<Serviceevent> Serviceevent { get; set; }
    }
}
