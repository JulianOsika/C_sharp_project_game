using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Zombie : Opponent
    {
        public Zombie(string _name, int _lvl)
        {
            Name = _name;
            Lvl = _lvl;
            Hp = 10 + Lvl * 10;
            damage = 1 + Lvl * 5;
        }

    }
}
