using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargersSearch
{

    public enum PhaseType
    {
        Single,
        Three,
        Unknown
    }

    public class Charger {

        public string name;
        public int type;
        public PhaseType phase;
        public bool tethered;
        
        // public Charger(string name)
        // {
        //     this.name = name;
        // }
    }

}