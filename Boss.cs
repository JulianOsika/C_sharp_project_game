using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Boss : Opponent
    {
        public Boss(string _name, int _lvl)
        {
            Name = _name;
            Lvl = _lvl;
            Hp = 50 + Lvl * 0.5;
            damage = 10 + Lvl * 0.5;
        }
    }
}
