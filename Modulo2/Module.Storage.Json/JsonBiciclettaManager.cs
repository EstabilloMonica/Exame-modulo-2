using Module.Core.Entities;
using Module.Storage.Json.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Storage.Json
{
    public class JsonBiciclettaManager : JsonManagerBase<Bicicletta>
    {
        protected override void RemapNuoviValoriSuEntityInLista(Bicicletta entitySorgente, Bicicletta entityDestinazione)
        {
            entityDestinazione.NumeroTelaio = entitySorgente.NumeroTelaio;
            entityDestinazione.isElettrica = entitySorgente.isElettrica;
        }
    }
}
