using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Armor : Item
    {
        public double HpBoost;
        public double HpBoostLvl;

        public Armor(string _Name, double _HpBoost, int _Price, bool _Bought)
        {
            Name = _Name;
            HpBoost = _HpBoost;
            Price = _Price;
            HpBoostLvl = 1;
            Bought = _Bought;
        }
    }
}
