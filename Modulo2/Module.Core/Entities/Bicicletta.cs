using Module.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Core.Entities
{
    public class Bicicletta: MonitorableEntityBase
    {
        public int NumeroTelaio { get; set; }

        public bool isElettrica { get; set; }
    }
}
