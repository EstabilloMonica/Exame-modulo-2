using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Core.Entities.Interfaces
{
    /// <summary>
    /// Interfaccia per entità che hanno il 
    /// modello e la marca
    /// </summary>
    public interface IMonitorableEntity
    {
        /// <summary>
        /// Modello del veicolo
        /// </summary>
        String Modello { get; set; }

        /// <summary>
        /// Marca del veicolo
        /// </summary>
        string Marca { get; set; }

        /// <summary>
        /// Data di creazione dell'entità
        /// </summary>
        DateTime Timestamp { get; set; }
    }
}
