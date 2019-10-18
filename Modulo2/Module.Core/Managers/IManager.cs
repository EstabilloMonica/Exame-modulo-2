﻿using Module.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Core.Managers
{
    public interface IManager<TEntity> where TEntity: class, IEntity
    {
        /// <summary>
        /// Crea l'entità passata sullo storage
        /// </summary>
        /// <param name="entityDaCreare">Entità da creare</param>
        void Crea(TEntity entityDaCreare);

        /// <summary>
        /// Carica tutte le entità nello storage
        /// </summary>
        /// <returns>Ritorna la lista di entità presenti</returns>
        IList<TEntity> Carica();
    }
}
