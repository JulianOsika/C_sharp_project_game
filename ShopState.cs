using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project
{
    class ShopState : InterfaceState
    {
        public ShopState(Interface gameInterface) : base(gameInterface) { ShowInfo(); }

        public override void EnterButton() { }
        public override void EscapeButton() { }
        public override void SpaceButton() { gameInterface.SetState(new ShelterState(gameInterface)); }
        public override void TabButton() { }

        public override void Button_1()
        {
            BuyArmor(0, 100, "Zbroja 1", 10);
            ShowInfo();
        }

        public override void Button_2()
        {
            BuyArmor(1, 500, "Zbroja 2", 20);
            ShowInfo();
        }

        public override void Button_3()
        {
            BuyArmor(2, 1000, "Zbroja 3", 50);
            ShowInfo();
        }

        public override void Button_4()
        {
            BuyWeapon(0, 100, "Sztylet", 5);
            ShowInfo();
        }

        public override void Button_5()
        {
            BuyWeapon(1, 500, "Miecz", 10);
            ShowInfo();
        }

        public override void Button_6()
        {
            BuyWeapon(2, 1000, "Topór", 20);
            ShowInfo();
        }

        public override void Button_7() { }
        public override void Button_8() { }
        public override void Button_9() { }

        private void BuyArmor(int _index, int _price, string _name, double _boost)
        {
            if (gameInterface.player.Money >= _price && gameInterface.shop.ArmorOffer[_index].Bought == false)
            {
                Console.Clear();
                Console.WriteLine("Na pewno chcesz kupić " + gameInterface.shop.ArmorOffer[_index].Name + "?");
                Console.WriteLine("[ENTER] - TAK         [ESCAPE] - NIE");
                ConsoleKeyInfo ask = Console.ReadKey();
                if(ask.Key == ConsoleKey.Enter)
                {
                    gameInterface.shop.ArmorOffer[_index].Bought = true;
                    gameInterface.player.Money = gameInterface.player.Money - _price;
                    gameInterface.shop.ArmorOffer[_index].Bought = true;
                    gameInterface.player.Armor = new Armor(_name, _boost, _price, true);
                }
                else
                {
                    Console.Clear();
                    ShowInfo();
                }
            }
            else if (gameInterface.player.Money < _price && gameInterface.shop.ArmorOffer[_index].Bought == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Masz za mało pieniędzy");
                Thread.Sleep(2000);
                ShowInfo();
            }
            else if (gameInterface.shop.ArmorOffer[_index].Bought == true) { Console.WriteLine("Przedmiot sptzedany"); }
        }

        private void BuyWeapon(int _index, int _price, string _name, double _boost)
        {
            if (gameInterface.player.Money >= _price && gameInterface.shop.WeaponOffer[_index].Bought == false)
            {
                Console.Clear();
                Console.WriteLine("Na pewno chcesz kupić " + gameInterface.shop.WeaponOffer[_index].Name + "?");
                Console.WriteLine("[ENTER] - TAK         [ESCAPE] - NIE");
                ConsoleKeyInfo ask = Console.ReadKey();
                if (ask.Key == ConsoleKey.Enter)
                {
                    gameInterface.shop.WeaponOffer[_index].Bought = true;
                    gameInterface.player.Money -= _price;
                    gameInterface.shop.WeaponOffer[_index].Bought = true;
                    gameInterface.player.Weapon = new Weapon(_name, _boost, _price, true);
                }
                else
                {
                    Console.Clear();
                    ShowInfo();
                }
            }
            else if (gameInterface.player.Money < _price && gameInterface.shop.WeaponOffer[_index].Bought == false) { Console.WriteLine("Masz za mało pieniędzy"); }
            else if (gameInterface.shop.WeaponOffer[_index].Bought == true) { Console.WriteLine("Przedmiot sptzedany"); }
        }

        public void ShowInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("SKLEP" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Pieniądze: " + gameInterface.player.Money.ToString() + "$");
            Console.WriteLine(" [1] - kup: Zbroja 1");
            Console.WriteLine(" [2] - kup: Zbroja 2");
            Console.WriteLine(" [3] - kup: Zbroja 3");
            Console.WriteLine(" [4] - kup: Sztylet");
            Console.WriteLine(" [5] - kup: Miecz");
            Console.WriteLine(" [6] - kup: Topór");
            Console.WriteLine("[SPACE] - wyjdź ze sklepu" + "\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{} PANCERZ {}");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Armor item in gameInterface.shop.ArmorOffer)
            {
                if (item.Bought == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(item.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Dodatkowe życie: " + item.HpBoost.ToString());
                    Console.WriteLine("Cena: " + item.Price.ToString() + "$" + "\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("SPRZEDANE" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{} BROŃ {}");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Weapon item in gameInterface.shop.WeaponOffer)
            {
                if(item.Bought == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(item.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Dodatkowe obrażenia: " + item.DamageBoost.ToString());
                    Console.WriteLine("Cena: " + item.Price.ToString());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("SPRZEDANE" + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
