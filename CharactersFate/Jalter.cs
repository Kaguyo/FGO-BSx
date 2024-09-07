using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FGO_BSx.CharactersFate
{
    internal class Jalter : Interfaces.IAvenger
    {
        private static readonly Random random = new Random();

        // Fields
        private string _name = "Jeanne d'Arc (Alter)";
        private double _hpMax = 6551;
        private int _atkMax = 722;
        private int _defMax = 590;
        private double _hp = 6551;
        private int _atk = 222;
        private int _def = 590;
        private double _spCost = 250;
        private double _spInitial = 0;
        private double _basicAtk = 0.35; // 2 hits
        private static double _ultNpHit1 = 0.6; // 1 hit
        private static double _ultNpHit2 = 1.1; // 1 hit
        private static double _ultNpHit3 = 1.22; // 1 hit
        private static double _ultNpHit4 = 1.3; // 1 hit
        private static double _ultNpHit5 = 1.5; // 1 hit
        private static double _ultNpHit6 = 1.66; // 1 hit
        private static double _ultNpHit7 = 1.72; // 1 hit
        private static double _ultNpHit8 = 1.92; // 1 hit
        private static double _ultNpHit9 = 2.69; // 1 hit
        private double _extraAtk = 0.35; // 5 hits
        private int _spd = 100;
        private int _lvl = 1;
        private double _critDmg = 10;
        private double _critRate = 5;
        private double _classDmgBonus;
        
        // Properties
        internal double ClassDmgBonus { get => _classDmgBonus; set => _classDmgBonus = value; }
        internal string? LastComment { get; set; }
        internal string Name { get => _name; }
        internal double HpMax { get => _hpMax; set => _hpMax = value; }
        internal int AtkMax { get => _atkMax; set => _atkMax = value; }
        internal int DefMax { get => _defMax; set => _defMax = value; }
        internal double Hp { get => _hp; set => _hp = value; }
        internal int Atk { get => _atk; set => _atk = value; }
        internal int Def { get => _def; set => _def = value; }
        internal double SpCost { get => _spCost; set => _spCost = value; }
        internal double SpInitial { get => _spInitial; set => _spInitial = value; }
        internal double BasicAttack { get => _basicAtk; set => _basicAtk = value; }
        internal double Extra { get => _extraAtk; set => _extraAtk = value; }
        internal static double UltNpHit1 { get => _ultNpHit1; set => _ultNpHit1 = value; }
        internal static double UltNpHit2 { get => _ultNpHit2; set => _ultNpHit2 = value; }
        internal static double UltNpHit3 { get => _ultNpHit3; set => _ultNpHit3 = value; }
        internal static double UltNpHit4 { get => _ultNpHit4; set => _ultNpHit4 = value; }
        internal static double UltNpHit5 { get => _ultNpHit5; set => _ultNpHit5 = value; }
        internal static double UltNpHit6 { get => _ultNpHit6; set => _ultNpHit6 = value; }
        internal static double UltNpHit7 { get => _ultNpHit7; set => _ultNpHit7 = value; }
        internal static double UltNpHit8 { get => _ultNpHit8; set => _ultNpHit8 = value; }
        internal static double UltNpHit9 { get => _ultNpHit9; set => _ultNpHit9 = value; }
        internal static int ExtraAttackCooldown { get; set; } = 5;

        internal int SPD { get => _spd; set => _spd = value; }
        internal int Lvl { get => _lvl; set => _lvl = value; }
        internal double CritDmg { get => _critDmg; set => _critDmg = value; }
        internal double CritRate { get => _critRate; set => _critRate = value; }
        internal double[] NPInstances = { UltNpHit1, UltNpHit2, UltNpHit3, UltNpHit4, UltNpHit5, UltNpHit6, UltNpHit7, UltNpHit8, UltNpHit9 };

        //  =========================================
        //  INICIO DE "FUNCOES PRIMARIAS".
        //  =========================================

        /* This comment serves to mark the beginning or end of functions that are designed to call other functions which perform actions in the game,
        as well as make general changes to stats, cooldowns, buffs, debuffs, etc., for better organization and pattern consistency.
        */
        public int SwordSkill(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.DarkYellow);
            Console.WriteLine(":");

            while (true)
            {
                int choice = random.Next(1, 4);

                if (choice == 1 && LastComment != "I'll take them myself!")
                {
                    PerformComment1();
                    break;
                }
                else if (choice == 2 && LastComment != "I'll show you my strength!")
                {
                    PerformComment2();
                    break;
                }
                else if (choice == 3 && LastComment != "I'll cut them down!")
                {
                    PerformComment3();
                    break;
                }
            }
            ExtraAttackCooldown -= 1;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            return danoTotal;
        }
        public int LeGrondementdelaHaine(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.DarkYellow);
            Console.WriteLine(":");

            while (true)
            {
                int choice = random.Next(1, 4);

                if (choice == 1 && LastComment != "I'll take them myself!")
                {
                    PerformLeGrondementdelaHaine1();
                    break;
                }
                else if (choice == 2 && LastComment != "I'll show you my strength!")
                {
                    PerformLeGrondementdelaHaine2();
                    break;
                }
                else if (choice == 3 && LastComment != "I'll cut them down!")
                {
                    PerformLeGrondementdelaHaine3();
                    break;
                }
            }
            danoTotal += Controls.DamageFormulas.JalterNP(random, Atk, NPInstances, CritRate, CritDmg, 9, defesaInimigo, danoTotal);
            Hp += 300;
            if (Hp > HpMax) Hp = HpMax;
            ExtraAttackCooldown -= 1;
            SpInitial = 0;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            return danoTotal;
        }
        public int ExtraAttack(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(_name, ConsoleColor.DarkYellow);
            Console.WriteLine(":");
            while (true)
            {
                int choice = random.Next(1, 4);

                if (choice == 1 && LastComment != "I'll take them myself!")
                {
                    PerformExtra1();
                    break;
                }
                else if (choice == 2 && LastComment != "O wind, whirl away!")
                {
                    PerformExtra2();
                    break;
                }
                else if (choice == 3 && LastComment != "Strike Air!")
                {
                    PerformExtra3();
                    break;
                }
            }
            SpInitial += 8;
            ExtraAttackCooldown = 5;
            return Controls.DamageFormulas.CauseDamage(random, Atk, Extra, CritRate, CritDmg, 5, defesaInimigo, danoTotal);
        }
        //  =========================================
        //  FIM DE "FUNCOES PRIMARIAS".
        //  =========================================


        //  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX


        //  =========================================
        //  INICIO DE "FUNCOES ACTIONS".
        //  =========================================

        /* This comment serves to mark the beginning or end of functions that are designed to perform actions in the game,
        specially character comments logics.
        */
        private void PerformExtra1()
        {
            string comment = "Got you!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\Extra1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
        }
        private void PerformExtra2()
        {
            string comment = "O wind, whirl away!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\Extra2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                if (c == ',')
                {
                    Console.Write(c);
                    Thread.Sleep(300);
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(22);
                }
            }
            Console.WriteLine();
        }
        private void PerformExtra3()
        {
            string comment = "Strike Air!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\Extra3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
        }
        private void PerformLeGrondementdelaHaine1()
        {
            string comment = "I'll cut them down!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\";

            Controls.SistemaFGO.PlaySound(audioFilePath);
        }
        private void PerformLeGrondementdelaHaine2()
        {
            string comment = "I'll cut them down!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\";

            Controls.SistemaFGO.PlaySound(audioFilePath);
        }
        private void PerformLeGrondementdelaHaine3()
        {
            string comment = "I'll cut them down!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\";

            Controls.SistemaFGO.PlaySound(audioFilePath);
        }
        private void PerformComment1()
        {
            string comment = "I'll take them myself!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\Basic1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
        }

        private void PerformComment2()
        {
            string comment = "I'll show you my strength!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\Basic2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
        }

        private void PerformComment3()
        {
            string comment = "I'll cut them down!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\Basic3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }
        //  =========================================
        //  FIM DE "FUNCOES ACTIONS".
        //  =========================================

        public static void SkillsJalter(double sp, double spCost) 
        {
            Controls.SistemaFGO.WriteColored("Extra Attack", ConsoleColor.DarkYellow);
            Console.Write(" Cooldown (");
            Controls.SistemaFGO.WriteColored(ExtraAttackCooldown, ConsoleColor.DarkYellow);
            Console.WriteLine(")\n");
            Controls.SistemaFGO.WriteColored("Sword Attack", ConsoleColor.DarkYellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("1", ConsoleColor.Green);
            Console.WriteLine(")");
            Controls.SistemaFGO.WriteColored("Self Modification", ConsoleColor.DarkYellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("2", ConsoleColor.Green);
            Console.WriteLine(")");
            Controls.SistemaFGO.WriteColored("Ephemeral Dream", ConsoleColor.DarkYellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("3", ConsoleColor.Green);
            Console.WriteLine(")");
            if (sp < spCost)
            {
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Yellow);
                Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("Le Grondement de la Haine", ConsoleColor.DarkYellow);
                Console.Write(" (");
                Controls.SistemaFGO.WriteColored("4", ConsoleColor.Green);
                Console.Write(")");
                Controls.SistemaFGO.WriteColored(")", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("\nNP Energy", ConsoleColor.White);
                Console.Write(": ");
                sp /= spCost;
                sp *= 100;
                Controls.SistemaFGO.WriteColored((int)sp, ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("/", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored("100", ConsoleColor.Green);
                Controls.SistemaFGO.WriteColored("  NOT READY", ConsoleColor.DarkRed);
                Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Yellow);
            }
            else if (sp >= spCost)
            {
                sp = spCost;
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Yellow);
                Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("Le Grondement de la Haine", ConsoleColor.DarkYellow);
                Console.Write(" (");
                Controls.SistemaFGO.WriteColored("3", ConsoleColor.Green);
                Console.Write(")");
                Controls.SistemaFGO.WriteColored(")", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("\nNP Energy", ConsoleColor.White);
                Console.Write(": ");
                sp /= spCost;
                sp *= 100;
                Controls.SistemaFGO.WriteColored(((int)sp), ConsoleColor.Green);
                Controls.SistemaFGO.WriteColored("/", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored("100", ConsoleColor.Green);
                Controls.SistemaFGO.WriteColored("  READY", ConsoleColor.Green);
                Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Yellow);
            }
        }
    }
}
