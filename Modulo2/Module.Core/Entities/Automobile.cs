using Module.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Core.Entities
{
    public class Automobile : MonitorableEntityBase
    {
        public int NumeroCavalli { get; set; }

        public bool isDiesel { get; set; }

        public DateTime DataImmatricolazione {get; set;}

       
    }
}
