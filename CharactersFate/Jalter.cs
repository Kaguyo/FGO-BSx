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
        private int _hpMax = 6551;
        private int _atkMax = 7220;
        private int _defMax = 590;
        private int _hp = 6551;
        private int _atk = 7220;
        private int _def = 590;
        private double _spCost = 250;
        private double _spInitial = 0;
        private double _basicAtk = 0.55; // 2 hits
        private static double _ultNpHit1 = 0.8; // 1 hit
        private static double _ultNpHit2 = 1.2; // 1 hit
        private static double _ultNpHit3 = 1.35; // 1 hit
        private static double _ultNpHit4 = 1.5; // 1 hit
        private static double _ultNpHit5 = 1.7; // 1 hit
        private static double _ultNpHit6 = 1.86; // 1 hit
        private static double _ultNpHit7 = 1.92; // 1 hit
        private static double _ultNpHit8 = 2.02; // 1 hit
        private static double _ultNpHit9 = 2.95; // 1 hit
        private double _extraAtk = 0.35; // 5 hits
        private int _spd = 100;
        private double _critDmg = 10;
        private double _critRate = 5;
        private double _classDmgBonus;
        
        // Properties
        internal double ClassDmgBonus { get => _classDmgBonus; set => _classDmgBonus = value; }
        internal string? LastComment { get; set; }
        internal string Name { get => _name; }
        internal int HpMax { get => _hpMax; set => _hpMax = value; }
        internal int AtkMax { get => _atkMax; set => _atkMax = value; }
        internal int DefMax { get => _defMax; set => _defMax = value; }
        internal int Hp { get => _hp; set => _hp = value; }
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
        internal static int SelfModDuration { get; set; } = -1;
        internal static int OblivionDuration { get; set; } = -1;
        internal int SPD { get => _spd; set => _spd = value; }
        internal double CritDmg { get => _critDmg; set => _critDmg = value; }
        internal double CritRate { get => _critRate; set => _critRate = value; }
        internal static int Level { get; set; } = 1;
        internal static int Exp { get; set; } = 0;
        internal static int ExpNeeded { get; set; } = 70;

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
                int choice = random.Next(1, 5);

                if (choice == 1 && LastComment != "Ahahaha!")
                {
                    PerformComment1();
                    break;
                }
                else if (choice == 2 && LastComment != "Well!?")
                {
                    PerformComment2();
                    break;
                }
                else if (choice == 3 && LastComment != "Pathetic!")
                {
                    PerformComment3();
                    break;
                }
                else if (choice == 4 && LastComment != "Burn away!")
                {
                    PerformComment4();
                    break;
                }
            }
            danoTotal += Controls.DamageFormulas.CauseDamage(random, Atk, BasicAttack, CritRate, CritDmg, 2, defesaInimigo, danoTotal, Name);
            ExtraAttackCooldown -= 1;
            SelfModDuration -= 1;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            if (SelfModDuration == 0) CritRate -= 35;
            OblivionDuration -= 1;
            if (OblivionDuration == 0) CritDmg -= 90;
            return danoTotal;
        }
        public int SelfModificationCritUp(int defesaInimigo, int danoTotal)
        {
            while (true) 
            {
                int choice = random.Next(1, 4);
                if (choice == 1 && LastComment != "Right choice.")
                {
                    string comment = "Right choice.";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Skill1.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment) 
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    Console.WriteLine();
                    Console.ReadKey(true);
                    
                    break;
                }
                else if (choice == 2 && LastComment != "Just leave it to me.")
                {
                    string comment = "Just leave it to me.";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Skill2.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    Console.WriteLine();
                    Console.ReadKey(true);
                    
                    break;
                }
                else if (choice == 3 && LastComment != "Okay, okay.") 
                {
                    string comment = "Okay, okay.";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Skill3.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    Console.WriteLine();
                    Console.ReadKey(true);

                    break;
                }
            }
            SelfModDuration = 2;
            CritRate += 35;
            Hp += 150;
            SpInitial += 10;
            ExtraAttackCooldown -= 1;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            OblivionDuration -= 1;
            if (OblivionDuration == 0) CritDmg -= 90;
            return danoTotal;
        }
        public int OblivionCorrectionCritUp(int defesaInimigo, int danoTotal)
        {
            while (true)
            {
                int choice = random.Next(1, 4);
                if (choice == 1 && LastComment != "Howl, Fafnir!")
                {
                    string comment = "Howl, Fafnir!.";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Obv1.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    Console.WriteLine();
                    Console.ReadKey(true);

                    break;
                }
                else if (choice == 2 && LastComment != "How's that!")
                {
                    string comment = "How's that!";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Obv2.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    Console.WriteLine();
                    Console.ReadKey(true);
                    
                    break;
                }
                else if (choice == 3 && LastComment != "Come, dragon of mine.")
                {
                    string comment = "Come, dragon of mine.";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Obv3.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    Console.WriteLine();
                    Console.ReadKey(true);

                    break;
                }
            }
            OblivionDuration = 2;
            SpInitial += 15;
            CritDmg += 90;
            ExtraAttackCooldown -= 1;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            SelfModDuration -= 1;
            if (SelfModDuration == 0)
            {
                CritRate -= 35;
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

                if (choice == 1 && LastComment != "This is the howl of a soul filled with hatred!\nLa Grondement Du Haine!")
                {
                    PerformLeGrondementdelaHaine1();
                    break;
                }
                else if (choice == 2 && LastComment != "My flames of vengeance. My flames of retribution. I'll skewer you with my festering hatred!\nLa Grondement du Haine!! Ahahahahahahahaha!!")
                {
                    PerformLeGrondementdelaHaine2();
                    break;
                }
                else if (choice == 3 && LastComment != "My sword is hatred! My dragon is vengeance! My flames are retribution! Everything will be pierced!\nLa Grondement du Haine!!")
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
            SelfModDuration -= 1;
            if (SelfModDuration == 0)
            {
                CritRate -= 35;
            }
            OblivionDuration -= 1;
            if (OblivionDuration == 0) CritDmg -= 90;
            return danoTotal;
        }
        public int ExtraAttack(int defesaInimigo, int danoTotal)
        {
            Console.Clear();
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
            return Controls.DamageFormulas.CauseDamage(random, Atk, Extra, CritRate, CritDmg, 5, defesaInimigo, danoTotal, Name);
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
            string comment = "Thy path has long since come to an end!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Extra1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
            Console.ReadKey(true);
            Console.Clear();

        }
        private void PerformExtra2()
        {
            string comment = "Thou shalt be punished by flame.";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Extra2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
            Console.ReadKey(true);
            Console.Clear();
        }
        private void PerformExtra3()
        {
            string comment = "Ramble amidst the flames!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Extra3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
            Console.ReadKey(true);
            Console.Clear();
        }
        private void PerformLeGrondementdelaHaine1()
        {
            string comment = "This is the howl of a soul filled with hatred!\r\nLa Grondement Du Haine!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\NP1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            int x = 1;
            foreach (char c in comment)
            {
                if (c == '!' && x == 1)
                {
                    Console.Write(c);
                    Controls.SistemaFGO.WriteColored2(ConsoleColor.DarkYellow);
                    Thread.Sleep(300);
                    x++;
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(20);
                }
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey(true);
            
        }
        private void PerformLeGrondementdelaHaine2()
        {
            string comment = "My flames of vengeance. My flames of retribution. I'll skewer you with my festering hatred!\nLa Grondement du Haine!! Ahahahahahahahaha!!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\NP2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            int x = 1;
            foreach (char c in comment)
            {
                if (c == '.')
                {
                    Console.Write(c);
                    Thread.Sleep(150);
                }
                else if (c == '!' && x == 1)
                {
                    Console.Write(c);
                    Thread.Sleep(100);
                    Controls.SistemaFGO.WriteColored2(ConsoleColor.DarkYellow);
                    x++;
                }
                else if (c == '!' && x <= 3)
                {
                    Console.Write(c);
                    Thread.Sleep(20);
                    x++;
                }
                else if (c == 'A' && x > 3) 
                {
                    Console.ResetColor();
                    Console.Write(c) ; Thread.Sleep(20);
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(20);
                }
            }
            Console.WriteLine();
            Console.ReadKey(true);
            
        }
        private void PerformLeGrondementdelaHaine3()
        {
            string comment = "My sword is hatred! My dragon is vengeance! My flames are retribution! Everything will be pierced!\nLa Grondement du Haine!!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\NP3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            int x = 1;
            foreach (char c in comment)
            {
                if (c == '!' && x <= 4)
                {
                    Console.Write(c);
                    Thread.Sleep(90);
                    x++;
                }
                else if (x > 4)
                {
                    Controls.SistemaFGO.WriteColored(c, ConsoleColor.DarkYellow);
                    Thread.Sleep(20);
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(20);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey(true);
            
        }

        private void PerformComment1()
        {
            string comment = "Ahahaha!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Atk1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
            Console.ReadKey(true);

        }

        private void PerformComment2()
        {
            string comment = "Well!?";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Atk2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
            Console.ReadKey(true);

        }

        private void PerformComment3()
        {
            string comment = "Pathetic!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Atk3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
            Console.WriteLine();
            Console.ReadKey(true);
 
        }
        private void PerformComment4()
        {
            string comment = "Burn away!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\JalterNoises\Atk4.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
            Console.WriteLine();
            Console.ReadKey(true);

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
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.DarkYellow);
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
                Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.DarkYellow);
            }
            else if (sp >= spCost)
            {
                sp = spCost;
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.DarkYellow);
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
                Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.DarkYellow);
            }
        }
    }
}