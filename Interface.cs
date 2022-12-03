using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Interface
    {
        public InterfaceState state;
        public Player player;
        public Arena arena;
        public Shop shop;
        public Forge forge;

        public Interface()
        {
            player = new Player("name");
            shop = new Shop();
            shop.ArmorOffer.Add(new Armor("Zbroja 1", 10, 100, false));
            shop.ArmorOffer.Add(new Armor("Zbroja 2", 20, 500, false));
            shop.ArmorOffer.Add(new Armor("Zbroja 3", 50, 1000, false));
            shop.WeaponOffer.Add(new Weapon("Sztylet", 5, 100, false));
            shop.WeaponOffer.Add(new Weapon("Miecz", 10, 500, false));
            shop.WeaponOffer.Add(new Weapon("Topór", 20, 1000, false));
            forge = new Forge();
            state = new MenuSate(this);
            arena = new Arena();
            arena.Opponents = new List<Opponent>();
        }

        public void CheckButton()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if(key.Key == ConsoleKey.Enter) { EnterButton(); }
            else if (key.Key == ConsoleKey.Escape) { EscapeButton(); }
            else if (key.Key == ConsoleKey.Spacebar) { SpaceButton(); }
            else if (key.Key == ConsoleKey.Tab) { TabButton(); }
            else if (key.Key == ConsoleKey.D1) { Button_1(); }
            else if (key.Key == ConsoleKey.D2) { Button_2(); }
            else if (key.Key == ConsoleKey.D3) { Button_3(); }
            else if (key.Key == ConsoleKey.D4) { Button_4(); }
            else if (key.Key == ConsoleKey.D5) { Button_5(); }
            else if (key.Key == ConsoleKey.D6) { Button_6(); }
            else if (key.Key == ConsoleKey.D7) { Button_7(); }
            else if (key.Key == ConsoleKey.D8) { Button_8(); }
            else if (key.Key == ConsoleKey.D9) { Button_9(); }
            else { Console.WriteLine("ten przycisk nic nie robi"); }
        }

        public void EnterButton() { state.EnterButton(); }
        public void EscapeButton() { state.EscapeButton(); }
        public void SpaceButton() { state.SpaceButton(); }
        public void TabButton() { state.TabButton(); }
        public void Button_1() { state.Button_1(); }
        public void Button_2() { state.Button_2(); }
        public void Button_3() { state.Button_3(); }
        public void Button_4() { state.Button_4(); }
        public void Button_5() { state.Button_5(); }
        public void Button_6() { state.Button_6(); }
        public void Button_7() { state.Button_7(); }
        public void Button_8() { state.Button_8(); }
        public void Button_9() { state.Button_9(); }

        public void SetState(InterfaceState state) { this.state = state; }
    }
}
