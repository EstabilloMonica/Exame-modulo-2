using Module.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Core.Entities.Abstracts
{
    public abstract class MonitorableEntityBase : IEntity, IMonitorableEntity
    {
        /// <summary>
        /// id primario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Modello del veicolo
        /// </summary>
        public string Modello { get; set; }

        /// <summary>
        /// Marca del veicolo
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
