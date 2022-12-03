using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project
{
    class ShelterState : InterfaceState
    {
        public ShelterState(Interface gameInterface) : base(gameInterface) { ShowInfo(); }

        public override void EnterButton() { }
        public override void EscapeButton() { }
        public override void SpaceButton() { gameInterface.SetState(new MenuSate(gameInterface)); }
        public override void TabButton()
        {
            Console.Clear();
            gameInterface.player.ShowStats();
            Thread.Sleep(2000);
            ShowInfo();
        }

        public override void Button_1() { gameInterface.SetState(new ArenaState(gameInterface)); }
        public override void Button_2() { gameInterface.SetState(new ShopState(gameInterface)); }
        public override void Button_3() { gameInterface.SetState(new ForgeState(gameInterface)); }
        public override void Button_4() { }
        public override void Button_5() { }
        public override void Button_6() { }
        public override void Button_7() { }
        public override void Button_8() { }
        public override void Button_9() { }

        public void ShowInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("DOM" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[1] - wejdź na arenę");
            Console.WriteLine("[2] - wejdź do sklepu");
            Console.WriteLine("[3] - wejdź do kuźni");
            Console.WriteLine("[TAB] - wyświetl statystyki");
            Console.WriteLine("[SPACE] - wyjdź z gry");
        }
    }
}
