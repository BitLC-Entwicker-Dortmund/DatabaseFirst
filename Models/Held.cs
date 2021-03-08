using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class Held
    {
        public Held()
        {
            Bedrohungs = new HashSet<Bedrohung>();
        }

        public int HeldId { get; set; }
        public string HeldName { get; set; }
        public string HeldEigenschaft { get; set; }

        public virtual ICollection<Bedrohung> Bedrohungs { get; set; }
    }
}
