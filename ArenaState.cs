using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project
{
    class ArenaState : InterfaceState
    {
        public ArenaState(Interface gameInterface) : base(gameInterface) { ShowInfo(); }

        public double end = 1;

        public override void EnterButton() { Fight(); }

        public override void EscapeButton() { }

        public override void SpaceButton() { gameInterface.SetState(new ShelterState(gameInterface)); }

        public override void TabButton() { CheckOpponents(2000); }

        public override void Button_1() { }

        public override void Button_2() { }

        public override void Button_3() { }

        public override void Button_4() { }

        public override void Button_5() { }

        public override void Button_6() { }

        public override void Button_7() { }

        public override void Button_8() { }

        public override void Button_9() { }

        private void CheckOpponents(int _time)
        {
            CreateOppponents();
            Console.WriteLine("\n" + "{} PRZCIWNICY {}");
            int a = 1;
            foreach (Opponent oppnent in gameInterface.arena.Opponents)
            {
                Console.WriteLine("Przeciwnik nr " + a.ToString() + ":  "+ oppnent.Name);
                a++;
            }
            gameInterface.arena.Opponents.Clear();
            Thread.Sleep(_time);
            ShowInfo();
        }

        private void ShowInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ARENA" + "\n");
            int wave = gameInterface.player.SurvivedWaves + 1;
            Console.WriteLine("Fala: " + wave.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[ENTER] - zacznij walkę");
            Console.WriteLine("[SPACE] - wróć do domu");
            Console.WriteLine("[TAB] - sprawdź przeciwników w najbliższym starciu" + "\n");
            gameInterface.player.ShowStats();
        }

        private void Fight()
        {
            double playerHp = gameInterface.player.Hp;
            gameInterface.arena.Opponents.Clear();
            CreateOppponents();
            Console.Clear();
            do
            {
                FightOptions();
            } while (end == 1);
            gameInterface.player.Hp = playerHp;
            end = 1;
            ShowInfo();
        }

        public void FightOptions()
        {
            double gainedMoney = 0;
            Console.Clear();
            gameInterface.player.ShowStats();
            ShowOpponents();
            Console.WriteLine("\n");
            if (gameInterface.arena.Opponents.Count == 1 && gameInterface.player.Hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("TWÓJ RUCH");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[1] - zaatakuj przeciwnika nr1");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    gameInterface.player.Attack(gameInterface.arena.Opponents[0]);
                    if(gameInterface.arena.Opponents[0].Hp > 0) { OpponentsAttack(); }
                    else
                    {
                        gainedMoney += gameInterface.arena.Opponents[0].Lvl * 2 + 1;
                        gameInterface.player.Money += gainedMoney;
                        gameInterface.player.AddExp(gameInterface.arena.Opponents[0].Lvl);
                        gameInterface.arena.Opponents.RemoveAt(0);
                    }
                }
                else { Console.WriteLine("Ten przycsik nic nie robi"); }
            }
            else if (gameInterface.arena.Opponents.Count == 2 && gameInterface.player.Hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("TWÓJ RUCH");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[1] - zaatakuj przeciwnika nr1");
                Console.WriteLine("[2] - zaatakuj przeciwnika nr2");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    gameInterface.player.Attack(gameInterface.arena.Opponents[0]);
                    if (gameInterface.arena.Opponents[0].Hp > 0) { OpponentsAttack(); }
                    else
                    {
                        gainedMoney += gameInterface.arena.Opponents[0].Lvl * 2 + 1;
                        gameInterface.player.Money += gainedMoney;
                        gameInterface.player.AddExp(gameInterface.arena.Opponents[0].Lvl);
                        gameInterface.arena.Opponents.RemoveAt(0);
                    }
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    gameInterface.player.Attack(gameInterface.arena.Opponents[1]);
                    if (gameInterface.arena.Opponents[1].Hp > 0) { OpponentsAttack(); }
                    else
                    {
                        gainedMoney += gameInterface.arena.Opponents[1].Lvl * 2 + 1;
                        gameInterface.player.Money += gainedMoney;
                        gameInterface.player.AddExp(gameInterface.arena.Opponents[1].Lvl);
                        gameInterface.arena.Opponents.RemoveAt(1);
                    }
                }
                else { Console.WriteLine("Ten przycsik nic nie robi"); }
            }
            else if (gameInterface.arena.Opponents.Count == 3 && gameInterface.player.Hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("TWÓJ RUCH");
                Console.WriteLine("[1] - zaatakuj przeciwnika nr1");
                Console.WriteLine("[2] - zaatakuj przeciwnika nr2");
                Console.WriteLine("[3] - zaatakuj przeciwnika nr3");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    gameInterface.player.Attack(gameInterface.arena.Opponents[0]);
                    if (gameInterface.arena.Opponents[0].Hp > 0) { OpponentsAttack(); }
                    else
                    {
                        gainedMoney += gameInterface.arena.Opponents[0].Lvl * 2 + 1;
                        gameInterface.player.Money += gainedMoney;
                        gameInterface.player.AddExp(gameInterface.arena.Opponents[0].Lvl);
                        gameInterface.arena.Opponents.RemoveAt(0);
                    }
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    gameInterface.player.Attack(gameInterface.arena.Opponents[1]);
                    if (gameInterface.arena.Opponents[1].Hp > 0) { OpponentsAttack(); }
                    else
                    {
                        gainedMoney += gameInterface.arena.Opponents[1].Lvl * 2 + 1;
                        gameInterface.player.Money += gainedMoney;
                        gameInterface.player.AddExp(gameInterface.arena.Opponents[1].Lvl);
                        gameInterface.arena.Opponents.RemoveAt(1);
                    }
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    gameInterface.player.Attack(gameInterface.arena.Opponents[2]);
                    if (gameInterface.arena.Opponents[2].Hp > 0) { OpponentsAttack(); }
                    else
                    {
                        gainedMoney += gameInterface.arena.Opponents[2].Lvl * 2 + 1;
                        gameInterface.player.Money += gainedMoney;
                        gameInterface.player.AddExp(gameInterface.arena.Opponents[2].Lvl);
                        gameInterface.arena.Opponents.RemoveAt(3);
                    }
                }
                else { Console.WriteLine("Ten przycsik nic nie robi"); }
            }
            else if (gameInterface.arena.Opponents.Count == 0 && gameInterface.player.Hp > 0) //WYGRANA
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("WYGRANA");
                Console.ForegroundColor = ConsoleColor.White;
                gameInterface.player.SurvivedWaves++;
                Thread.Sleep(2000);
                end = 2;
            }
            else if (gameInterface.player.Hp <= 0) // PRZEGRANA
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PRZEGRANA");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                gameInterface.player.Money = gameInterface.player.Money + gainedMoney;
                gameInterface.player.Deaths++;
                end = 2;
            }
            else { Console.WriteLine("ERROR"); }
        }

        private void CreateOppponents()
        {
            string sW = gameInterface.player.SurvivedWaves.ToString();
            if (gameInterface.player.SurvivedWaves < 10) { gameInterface.arena.Opponents.Add(new Zombie("Zombie lvl " + sW, gameInterface.player.SurvivedWaves + 1)); }
            if (gameInterface.player.SurvivedWaves > 10 & gameInterface.player.SurvivedWaves < 20)
            {
                gameInterface.arena.Opponents.Add(new Zombie("Zombie lvl " + sW, gameInterface.player.SurvivedWaves + 1));
                gameInterface.arena.Opponents.Add(new Knight("Rycerz lvl " + sW, gameInterface.player.SurvivedWaves + 1));
            }
            if (gameInterface.player.SurvivedWaves > 20 & gameInterface.player.SurvivedWaves < 30)
            {
                gameInterface.arena.Opponents.Add(new Zombie("Zombie lvl " + sW, gameInterface.player.SurvivedWaves + 1));
                gameInterface.arena.Opponents.Add(new Skeleton("Szkielet lvl " + sW, gameInterface.player.SurvivedWaves + 1));
            }
            if (gameInterface.player.SurvivedWaves > 30 & gameInterface.player.SurvivedWaves < 40)
            {
                gameInterface.arena.Opponents.Add(new Knight("Rycerz lvl " + sW, gameInterface.player.SurvivedWaves + 1));
                gameInterface.arena.Opponents.Add(new Skeleton("Szkielet lvl " + sW, gameInterface.player.SurvivedWaves + 1));
            }
            if (gameInterface.player.SurvivedWaves > 40 & gameInterface.player.SurvivedWaves < 50)
            {
                gameInterface.arena.Opponents.Add(new Zombie("Zombie lvl " + sW, gameInterface.player.SurvivedWaves + 1));
                gameInterface.arena.Opponents.Add(new Knight("Rycerz lvl " + sW, gameInterface.player.SurvivedWaves + 1));
                gameInterface.arena.Opponents.Add(new Skeleton("Szkielet lvl " + sW, gameInterface.player.SurvivedWaves + 1));
            }
            if (gameInterface.player.SurvivedWaves == 10 || gameInterface.player.SurvivedWaves == 20 || gameInterface.player.SurvivedWaves == 30 || gameInterface.player.SurvivedWaves == 40 || gameInterface.player.SurvivedWaves == 50)
            {
                gameInterface.arena.Opponents.Add(new Boss("Boss lvl " + sW, gameInterface.player.SurvivedWaves + 1));
            }
            else { }
        }

        public void ShowOpponents()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{} PRZECIWNICY {}");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Opponent opp in gameInterface.arena.Opponents)
            {
                Console.WriteLine("Przeciwnik: " + opp.Name);
                Console.WriteLine("Hp: " + Math.Round(opp.Hp).ToString() + "    Dmg: " + Math.Round(opp.damage).ToString() + "\n");
            }
        }

        private void OpponentsAttack() { foreach (Opponent op in gameInterface.arena.Opponents) { gameInterface.player.GetHit(op); } }
    }
}
