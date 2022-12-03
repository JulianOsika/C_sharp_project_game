using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Player : Character, Hit
    {
        public Player(string _name)
        {
            Exp = 0;
            Money = 0;
            SurvivedWaves = 0;
            Deaths = 0;
            ChosenAlly = null;
            Weapon = new Weapon("Dłoń", 0, 0, true);
            Armor = new Armor("Brak", 0, 0, true);
            Name = _name;
            AddExp(0);
        }

        public int Exp;
        public double Money;
        public Weapon Weapon;
        public Armor Armor;
        public int SurvivedWaves;
        public int Deaths;

        public void GetHit(Character attacker) { Hp = Hp - attacker.damage; }

        public void Attack(Character target) 
        {
            if (ChosenAlly == null) { }
            else if (ShowAlly() == "Diabeł") { Money++; }
            else if (ShowAlly() == "Anioł") { Exp++; }
            target.Hp -= damage - Weapon.DamageBoost;
        }

        public void ChangeAlly(int i)
        {
            if(i == 1) { ChosenAlly = new Angel(); }
            else if(i == 0) { ChosenAlly = new Devil(); }
            else { }
        }

        public string ShowAlly() { return ChosenAlly.Name; }

        public void AddExp(int _amount)
        {
            Exp += _amount;
            if (Exp >= 0 && Exp < 10)
            {
                Lvl = 0;
                Hp = 100;
                damage = 10;
            }
            if (Exp >= 10 && Exp < 30)
            {
                Lvl = 1;
                Hp = 150;
                damage = 15;
            }
            if (Exp >= 30 && Exp < 50)
            {
                Lvl = 2;
                Hp = 200;
                damage = 20;
            }
            if (Exp >= 50 && Exp < 80)
            {
                Lvl = 3;
                Hp = 250;
                damage = 25;
            }
            if (Exp >= 80 && Exp < 110)
            {
                Lvl = 4;
                Hp = 300;
                damage = 30;
            }
            if (Exp >= 110 && Exp < 140)
            {
                Lvl = 5;
                Hp = 350;
                damage = 35;
            }
            if (Exp >= 140 && Exp < 170)
            {
                Lvl = 6;
                Hp = 400;
                damage = 40;
            }
            if (Exp >= 170 && Exp < 200)
            {
                Lvl = 7;
                Hp = 450;
                damage = 45;
            }
            if (Exp >= 200 && Exp < 250)
            {
                Lvl = 8;
                Hp = 500;
                damage = 50;
            }
            if (Exp >= 250 && Exp < 300)
            {
                Lvl = 9;
                Hp = 550;
                damage = 55;
            }
            if (Exp >= 300 && Exp >= 300)
            {
                Lvl = 10;
                Hp = 600;
                damage = 60;
            }
            else { }

        }

        public void ShowStats()
        {
            AddExp(0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{} STATYSTYKI {}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Imię: " + Name);
            Console.WriteLine("Lvl: " + Lvl.ToString() + "    Exp: " + Exp.ToString());
            Console.WriteLine("Hp: " + Hp.ToString() + "    Dmg: " + damage.ToString());
            Console.WriteLine("Pieniądze: " + Money.ToString() + "$");
            Console.WriteLine("Wygrane fale: " + SurvivedWaves.ToString());
            Console.WriteLine("Przegrane: " + Deaths.ToString());

            if (Weapon != null)
            {
                Console.WriteLine("Broń: " + Weapon.Name);
                Console.WriteLine("Dodatkowe obrażenia: " + Weapon.DamageBoost.ToString());
            }
            else { Console.WriteLine("błąd"); }

            if (Armor != null)
            {
                Console.WriteLine("Pancerz: " + Armor.Name);
                Console.WriteLine("Dodatkowe życie: " + Armor.HpBoost.ToString());
            }
            else { Console.WriteLine("błąd"); }

            if (Lvl > 2) { Console.WriteLine("Sojusznik: " + ShowAlly()); }
            else { Console.WriteLine("[Osiągnij 3 poziom]"); }

            Console.WriteLine();
        }
    }
}
