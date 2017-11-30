using System;
using System.Collections.Generic;

namespace CpS301_API.Models
{
    public partial class Song
    {
        public Song()
        {
            Serviceevent = new HashSet<Serviceevent>();
        }

        public int SongId { get; set; }
        public string SongType { get; set; }
        public string Title { get; set; }
        public string HymnbookNum { get; set; }
        public string Arranger { get; set; }

        public ICollection<Serviceevent> Serviceevent { get; set; }
    }
}
