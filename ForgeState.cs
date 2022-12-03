using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project
{
    class ForgeState : InterfaceState
    {
        public ForgeState(Interface gameInterface) : base(gameInterface) { ShowInfo(); }

        public override void EnterButton() { }

        public override void EscapeButton() { }

        public override void SpaceButton() { gameInterface.SetState(new ShelterState(gameInterface)); }

        public override void TabButton() { ShowInfo(); }

        public override void Button_1() { UpgradeArmor(); }

        public override void Button_2() { UpgradeWeapon(); }

        public override void Button_3()
        {
            if(gameInterface.player.Money >= 400) { ChangeAlly(); }
            else
            {
                Console.WriteLine("Masz za mało pieniędzy");
                Thread.Sleep(1000);
                ShowInfo();
            }
        }

        public override void Button_4() { }

        public override void Button_5() { }

        public override void Button_6() { }

        public override void Button_7() { }

        public override void Button_8() { }

        public override void Button_9() { }

        private void ChangeAlly()
        {
            Console.Clear();
            Console.WriteLine("Wybierz swojego sojusznika, cena - 400$");
            Console.WriteLine("Twoje");
            Console.WriteLine("[1] - Angel (po każdym ataku otzrymujesz jeden punkt doświadczenia)");
            Console.WriteLine("[2] - Devil (po każdym ataku dostajesz jedną monetę)");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                gameInterface.player.ChangeAlly(1);
                gameInterface.player.Money -= 400;
                ShowInfo();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                gameInterface.player.ChangeAlly(0);
                gameInterface.player.Money -= 400;
                ShowInfo();
            }
        }

        private void ShowInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("KUŹNIA" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[1] - ulepsz pancerz");
            Console.WriteLine("[2] - ulepsz broń");
            if (gameInterface.player.Lvl > 2) { Console.WriteLine("[3] - zmiana sojusznika"); }
            else { }
            Console.WriteLine("[SPACE] - wyjdź z kuźni");
            Console.WriteLine("Pieniądze: " + gameInterface.player.Money.ToString() + "$" + "\n");
            if (gameInterface.player.Armor != null)
            {
                double price = gameInterface.player.Armor.HpBoostLvl * 50;
                Console.WriteLine("PANCERZ: " + gameInterface.player.Armor.Name);
                Console.WriteLine("Cena ulepszenia: " + price.ToString() + "$");
                Console.WriteLine("Bonus do Hp przed: " + Math.Round(gameInterface.player.Armor.HpBoost).ToString());
                Console.WriteLine("Bonus do Hp po: " + Math.Round(gameInterface.player.Armor.HpBoost * 1.1).ToString() + "\n");
            }
            else { Console.WriteLine("PANCERZ: BRAK" + "\n"); }
            if(gameInterface.player.Weapon != null)
            {
                double price = gameInterface.player.Weapon.DamageBoostLvl * 50;
                Console.WriteLine("BROŃ: " + gameInterface.player.Weapon.Name);
                Console.WriteLine("Cena ulepszenia: " + price.ToString());
                Console.WriteLine("Bonus do obrażeń przed: " + Math.Round(gameInterface.player.Weapon.DamageBoost).ToString());
                Console.WriteLine("Bonus do obrażeń po: " + Math.Round(gameInterface.player.Weapon.DamageBoost * 1.1).ToString() + "\n");
            }
            else { Console.WriteLine("BROŃ: BRAK"); }
            if (gameInterface.player.Lvl < 3) { Console.WriteLine("Sojusznicy : [osiągnij 3 poziom aby odblokkować]"); }
            else
            {
                if (gameInterface.player.ChosenAlly == null) { Console.WriteLine("Brak sojusznika"); }
                else { Console.WriteLine("Sojusznik: " + gameInterface.player.ShowAlly()); }
            }

        }

        private void UpgradeArmor()
        {
            double price;
            if(gameInterface.player.Armor != null)
            {
                Console.Clear();
                price = gameInterface.player.Armor.HpBoostLvl * 50;
                Console.WriteLine("Czy chcesz ulepszyć " + gameInterface.player.Armor.Name + " za " + price.ToString() + "$?");
                Console.WriteLine("[ENTER] - TAK            [ESCAPE] - NIE");
                ConsoleKeyInfo ask = Console.ReadKey();
                if (ask.Key == ConsoleKey.Enter)
                {
                    if(gameInterface.player.Money >= price)
                    {
                        gameInterface.player.Armor.HpBoostLvl++;
                        gameInterface.player.Armor.HpBoost = gameInterface.player.Armor.HpBoost * 1.1;
                        gameInterface.player.Money = gameInterface.player.Money - price;
                        ShowInfo();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Masz za mało pieniędzy");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1500);
                        ShowInfo();
                    }
                }
                else { ShowInfo(); }
            }
        }

        public void UpgradeWeapon()
        {
            double price;
            if (gameInterface.player.Weapon != null)
            {
                Console.Clear();
                price = gameInterface.player.Weapon.DamageBoostLvl * 50;
                Console.WriteLine("Czy chcesz ulepszyć " + gameInterface.player.Weapon.Name + " za " + price.ToString() + "$?");
                Console.WriteLine("[ENTER] - TAK            [ESCAPE] - NIE");
                ConsoleKeyInfo ask = Console.ReadKey();
                if (ask.Key == ConsoleKey.Enter)
                {
                    if (gameInterface.player.Money >= price)
                    {
                        gameInterface.player.Weapon.DamageBoostLvl++;
                        gameInterface.player.Weapon.DamageBoost = gameInterface.player.Weapon.DamageBoost * 1.1;
                        gameInterface.player.Money = gameInterface.player.Money - price;
                        ShowInfo();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Masz za mało pieniędzy");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1500);
                        ShowInfo();
                    }
                }else if(ask.Key == ConsoleKey.Escape) { ShowInfo(); }
            }
        }
    }
}
