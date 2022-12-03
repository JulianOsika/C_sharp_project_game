using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Shop
    {
        public List<Armor> ArmorOffer;
        public List<Weapon> WeaponOffer;

        public Shop()
        {
            ArmorOffer = new List<Armor>();
            WeaponOffer = new List<Weapon>();
        }   
    }
}
