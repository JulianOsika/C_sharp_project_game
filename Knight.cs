using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Knight : Opponent
    {
        public double Armor;

        public Knight(string _name, int _lvl)
        {
            Name = _name;
            Lvl = _lvl;
            Armor = 0 + _lvl * 15;
            Hp = 10 + _lvl + Armor;
            damage = 1 + _lvl * 4;
        }
    }
}
