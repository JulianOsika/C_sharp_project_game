using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class MenuSate : InterfaceState
    {
        public MenuSate(Interface gameInterface) : base(gameInterface) { ShowInfo(); }

        public override void EnterButton()
        {
            if (gameInterface.player.Name == "name")
            {
                Console.Clear();
                Console.WriteLine("Podaj swój nick");
                string nick = Console.ReadLine();
                gameInterface.player.Name = nick;
                gameInterface.SetState(new ShelterState(gameInterface));
            }
            else { gameInterface.SetState(new ShelterState(gameInterface)); }
        }

        public override void EscapeButton() { }
        public override void SpaceButton() { gameInterface.SetState(new ExitState(gameInterface)); }
        public override void TabButton() { }
        public override void Button_1() { }
        public override void Button_2() { }
        public override void Button_3() { }
        public override void Button_4() { }
        public override void Button_5() { }
        public override void Button_6() { }
        public override void Button_7() { }
        public override void Button_8() { }
        public override void Button_9() { }

        public void ShowInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("MENU");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[ENTER] - Rozpocznij grę" + "\n" + "[SPACE] - Wyjdź z gry");
        }

    }
}
