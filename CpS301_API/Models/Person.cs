using System;
using System.Collections.Generic;

namespace CpS301_API.Models
{
    public partial class Person
    {
        public Person()
        {
            Ensembleperson = new HashSet<Ensembleperson>();
            Personunavailable = new HashSet<Personunavailable>();
            ServiceOrganist = new HashSet<Service>();
            ServicePianist = new HashSet<Service>();
            ServiceSongleader = new HashSet<Service>();
            Serviceevent = new HashSet<Serviceevent>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Ensembleperson> Ensembleperson { get; set; }
        public ICollection<Personunavailable> Personunavailable { get; set; }
        public ICollection<Service> ServiceOrganist { get; set; }
        public ICollection<Service> ServicePianist { get; set; }
        public ICollection<Service> ServiceSongleader { get; set; }
        public ICollection<Serviceevent> Serviceevent { get; set; }
    }
}
