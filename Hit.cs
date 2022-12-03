using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    interface Hit
    {
        public void GetHit(Character _attacker);

        public void Attack(Character _target);
    }
}
