using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Weapon : Item
    {
        public double DamageBoost;
        public double DamageBoostLvl;

        public Weapon(string _Name, double _DamageBoost, int _Price, bool _Bought)
        {
            Name = _Name;
            DamageBoost = _DamageBoost;
            Price = _Price;
            DamageBoostLvl = 1;
            Bought = _Bought;
        }
    }
}
