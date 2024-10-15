using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGO_BSx.CharactersFate
{
    internal class Mordred : FGO_BSx.Interfaces.ISaber
    {
        private static readonly Random random = new Random();

        private string _name = "Mordred";
        private int _hpMax = 6021;
        private int _atkMax = 702;
        private int _defMax = 590;
        private int _hp = 6021;
        private int _atk = 702;
        private int _def = 590;
        private double _spCost = 160;
        private double _spInitial = 0;
        private double _basicAtk = 1.70;
        private double _extraAtk = 0.73; // 3 hits
        private static double _ultNpHit1 = 0.9; // 1 hit
        private static double _ultNpHit2 = 1.9; // 1 hit
        private static double _ultNpHit3 = 3; // 1 hit
        private static double _ultNpHit4 = 3.9; // 1 hit
        private static double _ultNpHit5 = 5.2; // 1 hit
        private int _spd = 100;
        private int _lvl = 1;
        private double _critDmg = 10;
        private double _critRate = 5;
        private double _classDmgBonus;

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
        internal int SPD { get => _spd; set => _spd = value; }
        internal int Lvl { get => _lvl; set => _lvl = value; }
        internal double CritDmg { get => _critDmg; set => _critDmg = value; }
        internal double CritRate { get => _critRate; set => _critRate = value; }
        internal int KnightofCrimsonThunderBuff { get; set; } = -1;
        internal static int ExtraAttackCooldown { get; set; } = 5;
        internal double[] NPInstances = { UltNpHit1, UltNpHit2, UltNpHit3, UltNpHit4, UltNpHit5 };
        //  =========================================
        //  INICIO DE "FUNCOES PRIMARIAS".
        //  =========================================

        /* This comment serves to mark the beginning or end of functions that are designed to call other functions which perform actions in the game,
        as well as make general changes to stats, cooldowns, buffs, debuffs, etc., for better organization and pattern consistency.
        */
       
        public int SwordSkill(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.Yellow);
            Console.WriteLine(":");

            while (true)
            {
                int choice = random.Next(1, 5);

                if (choice == 1 && LastComment != "Shut up!")
                {
                    PerformComment1();
                    break;
                }
                else if (choice == 2 && LastComment != "Silence!")
                {
                    PerformComment2();
                    break;
                }
                else if (choice == 3 && LastComment != "Drop dead!")
                {
                    PerformComment3();
                    break;
                }
                else if (choice == 4 && LastComment != "What's the matter!?")
                {
                    PerformComment4();
                    break;
                }
            }
            danoTotal += Controls.DamageFormulas.CauseDamage(random, Atk, BasicAttack, CritRate, CritDmg, 2, defesaInimigo, danoTotal);
            ExtraAttackCooldown -= 1;
            KnightofCrimsonThunderBuff -= 1;
            SpInitial += 10;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            if (KnightofCrimsonThunderBuff == 0) 
            {
                CritRate -= 35;
            }

            return danoTotal;
        }
        public int KnightofCrimsonThunder(int defesaInimigo, int danoTotal)
        {
            while (true)
            {
                int choice = random.Next(1, 4);
                if (choice == 1 && LastComment != "This feels awesome!")
                {
                    string comment = "This feels awesome!";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\KoCT1.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    break;
                }
                else if (choice == 2 && LastComment != "Yeah!")
                {
                    string comment = "Yeah!";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\KoCT2.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    break;
                }
                else if (choice == 3 && LastComment != "Got it!")
                {
                    string comment = "Got it!";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\KoCT3.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    break;
                }
            }
            if (KnightofCrimsonThunderBuff > 0)
            {
                CritRate -= 35;
            }
            KnightofCrimsonThunderBuff = 2;
            CritRate += 35;
            SpInitial += 5;
            ExtraAttackCooldown -= 1;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            
            return danoTotal;
        }
        public int ManaLoading(int defesaInimigo, int danoTotal)
        {
            while (true)
            {
                int choice = random.Next(1, 4);
                if (choice == 1 && LastComment != "Okay!")
                {
                    string comment = "Okay!";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\Skill1.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    break;
                }
                else if (choice == 2 && LastComment != "Leave it to me!")
                {
                    string comment = "Leave it to me!";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\Skill2.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    break;
                }
                else if (choice == 3 && LastComment != "All right!")
                {
                    string comment = "All right!";
                    LastComment = comment;
                    string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\Skill3.wav";

                    Controls.SistemaFGO.PlaySound(audioFilePath);

                    foreach (char c in comment)
                    {
                        Console.Write(c);
                        Thread.Sleep(20);
                    }
                    break;
                }
            }
            Hp += 150;
            if (Hp > HpMax) Hp = HpMax;
            SpInitial += 55;
            ExtraAttackCooldown -= 1;
            KnightofCrimsonThunderBuff -= 1;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            if (KnightofCrimsonThunderBuff == 0)
            {
                CritRate -= 35;
            }

            return danoTotal;
        }
        public int ClarentBloodArthur(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.DarkYellow);
            Console.WriteLine(":");

            while (true)
            {
                int choice = random.Next(1, 4);

                if (choice == 1 && LastComment != "So it's time for some overkill!")
                {
                    PerformClarentBloodArthur1();
                    break;
                }
                else if (choice == 2 && LastComment != "This is the evil sword that destroyed my father...\n Clarent Blood Arthur!")
                {
                    PerformClarentBloodArthur2();
                    break;
                }
                else if (choice == 3 && LastComment != "I am no king, but I follow in the king's path.\r\nI will destroy all that I must to bring the king peace!\r\nClarent Blood Arthur!")
                {
                    PerformClarentBloodArthur3();
                    break;
                }
            }
            Hp += 300;
            if (Hp > HpMax) Hp = HpMax;
            ExtraAttackCooldown -= 1;
            SpInitial = 0;
            if (KnightofCrimsonThunderBuff > 0)
            {
                danoTotal += Controls.DamageFormulas.MordredNP(random, Atk, NPInstances, CritRate, CritDmg, 5, defesaInimigo, danoTotal, 1.4);
            }
            else 
            {
                danoTotal += Controls.DamageFormulas.MordredNP(random, Atk, NPInstances, CritRate, CritDmg, 5, defesaInimigo, danoTotal, 1);
            }
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            KnightofCrimsonThunderBuff -= 1;
            if (KnightofCrimsonThunderBuff == 0) 
            {
                CritRate -= 35;
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

                if (choice == 1 && LastComment != "Take that, you fiend!")
                {
                    PerformExtra1();
                    break;
                }
                else if (choice == 2 && LastComment != "I'm gonna teach you a lesson!")
                {
                    PerformExtra2();
                    break;
                }
                else if (choice == 3 && LastComment != "Crush!")
                {
                    PerformExtra3();
                    break;
                }
            }
            SpInitial += 8;
            ExtraAttackCooldown = 5;
            return Controls.DamageFormulas.CauseDamage(random, Atk, Extra, CritRate, CritDmg, 3, defesaInimigo, danoTotal);
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
            string comment = "Take that, you fiend!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\Extra1.wav";

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
            string comment = "I'm gonna teach you a lesson!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\Extra2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
        }
        private void PerformExtra3()
        {
            string comment = "Crush!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\Extra3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
        }
        private void PerformClarentBloodArthur1()
        {
            string comment = "So it's time for some overkill!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\NP1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                    Console.Write(c);
                    Thread.Sleep(20);
            }
            Console.WriteLine();
        }
        private void PerformClarentBloodArthur2()
        {
            string comment = "This is the evil sword that destroyed my father...\nClarent Blood Arthur!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\NP2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            int x = 0;
            foreach (char c in comment)
            {
                if (c == '.')
                {
                    x++;
                    Console.Write(c);
                    if (x != 3) 
                    {
                        Thread.Sleep(20);
                    }
                    else 
                    { 
                        Thread.Sleep(500);
                        Controls.SistemaFGO.WriteColored2(ConsoleColor.Yellow);
                    }
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(20);
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }
        private void PerformClarentBloodArthur3()
        {
            string comment = "I am no king, but I follow in the king's path.\nI will destroy all that I must to bring the king peace!\nClarent Blood Arthur!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\NP3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                if (c == ',')
                {
                    Console.Write(c);
                    Thread.Sleep(40);
                }
                else if (c == '.') 
                {
                    Console.Write(c);
                    Thread.Sleep(120);
                }
                else if (c == '!')
                {
                    Console.Write(c);
                    Thread.Sleep(220);
                    Controls.SistemaFGO.WriteColored2(ConsoleColor.Yellow);
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(20);
                }
            }
            Console.WriteLine();
        }
      
        private void PerformComment1()
        {
            string comment = "Shut up!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\Atk1.wav";

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
            string comment = "Silence!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\Atk2.wav";

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
            string comment = "Drop dead!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\Atk3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
            Console.WriteLine();
        }
        private void PerformComment4()
        {
            string comment = "What's the matter!?";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\MordredNoises\Atk4.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
            Console.WriteLine();
        }
        //  =========================================
        //  FIM DE "FUNCOES ACTIONS".
        //  =========================================
        public static void SkillsMordred(double sp, double spCost) 
        {
            Controls.SistemaFGO.WriteColored("Extra Attack", ConsoleColor.Yellow);
            Console.Write(" Cooldown (");
            Controls.SistemaFGO.WriteColored(ExtraAttackCooldown, ConsoleColor.Yellow);
            Console.WriteLine(")\n");
            Controls.SistemaFGO.WriteColored("Sword Attack", ConsoleColor.Yellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("1", ConsoleColor.Green);
            Console.WriteLine(")");
            Controls.SistemaFGO.WriteColored("Mana Loading", ConsoleColor.Yellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("2", ConsoleColor.Green);
            Console.WriteLine(")");
            Controls.SistemaFGO.WriteColored("Knights of Crimson Thunder", ConsoleColor.Yellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("3", ConsoleColor.Green);
            Console.WriteLine(")");
            if (sp < spCost)
            {
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Yellow);
                Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("Clarent Blood Arthur", ConsoleColor.Yellow);
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
                Controls.SistemaFGO.WriteColored("Clarent Blood Arthur", ConsoleColor.Yellow);
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
