using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Skeleton : Opponent
    {
        public int Arrows;

        public Skeleton(string _name, int _lvl)
        {
            Name = _name;
            Lvl = _lvl;
            if(Lvl <11) { Arrows = 2; }
            else if(Lvl < 41) { Arrows = 3; }
            else { Arrows = 4; }
            Hp = 5 + _lvl * 5;
            damage = 2 + _lvl * 10;
        }

    }
}
