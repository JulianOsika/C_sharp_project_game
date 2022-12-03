using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    abstract class InterfaceState
    {
        public Interface gameInterface;

        public InterfaceState(Interface gameInterface) { this.gameInterface = gameInterface; }

        public abstract void EnterButton();
        public abstract void EscapeButton();
        public abstract void SpaceButton();
        public abstract void TabButton();

        public abstract void Button_1();
        public abstract void Button_2();
        public abstract void Button_3();
        public abstract void Button_4();
        public abstract void Button_5();
        public abstract void Button_6();
        public abstract void Button_7();
        public abstract void Button_8();
        public abstract void Button_9();

    }
}
