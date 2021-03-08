using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class Agressor
    {
        public Agressor()
        {
            Bedrohungs = new HashSet<Bedrohung>();
        }

        public int AgressorId { get; set; }
        public string AgressorName { get; set; }
        public string AgressorEigenschaft { get; set; }

        public virtual ICollection<Bedrohung> Bedrohungs { get; set; }
    }
}
