using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class ExitState : InterfaceState
    {
        public ExitState(Interface gameInterface) : base(gameInterface) { ShowInfo(); }

        public override void EnterButton() { Environment.Exit(1); }

        public override void EscapeButton() { }

        public override void SpaceButton() { }

        public override void TabButton() { gameInterface.SetState(new MenuSate(gameInterface)); }

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("DDO YOU WANT TO EXIT?" + "\n" + "[ENTER] - YES      [TAB] - NO");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
