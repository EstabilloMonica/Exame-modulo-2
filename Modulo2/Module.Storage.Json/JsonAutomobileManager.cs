using Module.Core.Entities;
using Module.Storage.Json.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Storage.Json
{
    public class JsonAutomobileManager : JsonManagerBase<Automobile>
    {
        protected override void RemapNuoviValoriSuEntityInLista(Automobile entitySorgente, Automobile entityDestinazione)
        {
            entityDestinazione.NumeroCavalli = entitySorgente.NumeroCavalli;
            entityDestinazione.isDiesel = entitySorgente.isDiesel;
            entityDestinazione.DataImmatricolazione = entityDestinazione.DataImmatricolazione;
        }
    }
}
