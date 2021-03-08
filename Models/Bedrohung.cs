using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class Bedrohung
    {
        public int BedrohungId { get; set; }
        public int HeldId { get; set; }
        public int AgressorId { get; set; }
        public string Bedrohungsbezeichnung { get; set; }

        public virtual Agressor Agressor { get; set; }
        public virtual Held Held { get; set; }
    }
}
