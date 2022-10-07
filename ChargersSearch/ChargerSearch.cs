using System.Runtime.Serialization.Json;
using System.Data;
using System;
using System.Globalization;
using System.Security.AccessControl;
namespace ChargersSearch;

using System.Collections.Generic;




public class ChargerSearch
{

    IEnumerable<Charger> dataStore;

    public ChargerSearch(List<Charger> dataStore)
    {
        //todo - be replaced with Azure object store with dependancy injection
        this.dataStore = dataStore;
    }

    public IEnumerable<Charger> Search(int type, PhaseType phase, bool tethered)
    {

        if(phase == PhaseType.Unknown)
            return dataStore.Where(c => c.type == type && c.tethered == tethered);   

        return dataStore.Where(c => c.type == type && c.tethered == tethered && c.phase == phase);
    }
};

