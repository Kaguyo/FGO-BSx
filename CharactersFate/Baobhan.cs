namespace FGO_BSx.CharactersFate
{
    internal class Baobhan : Interfaces.IArcher
    {
        private static readonly Random random = new Random();

        // Fields
        private string _name = "Baobhan";
        private int _hpMax = 4929;
        private int _atkMax = 6320;
        private int _defMax = 499;
        private int _hp = 4929;
        private int _atk = 6320;
        private int _def = 499;
        private double _spCost = 100;
        private double _spInitial = 0;
        private double _basicAtk = 0.65; // 2 hits
        private double _extraAtk = 0.55; // 4 hits
        private static double _ultNpHit1 = 0.9; // 1 hit
        private static double _ultNpHit2 = 1.2; // 1 hit
        private static double _ultNpHit3 = 2.1; // 1 hit
        private static double _ultNpHit4 = 3.02; // 1 hit
        private static double _ultNpHit5 = 3.5; // 1 hit
        private int _spd = 100;
        private int _lvl = 1;
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
        internal int SPD { get => _spd; set => _spd = value; }
        internal int Lvl { get => _lvl; set => _lvl = value; }
        internal double CritDmg { get => _critDmg; set => _critDmg = value; }
        internal double CritRate { get => _critRate; set => _critRate = value; }
        internal int FinnesseImproveDuration { get; set; } = -1;
        internal static int ExtraAttackCooldown { get; set; } = 5;
        internal double[] NPInstances = { UltNpHit1, UltNpHit2, UltNpHit3, UltNpHit4, UltNpHit5 };

        //  =========================================
        //  INICIO DE "FUNCOES PRIMARIAS".
        //  =========================================

            /* This comment serves to mark the beginning or end of functions that are designed to call other functions which perform actions in the game,
            as well as make general changes to stats, cooldowns, buffs, debuffs, etc., for better organization and pattern consistency.
            */
        public int FetchFailnaught(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.Red);
            Console.WriteLine(":");
            while (true)
            {
                int choice = random.Next(1, 3);
                if (choice == 1 && LastComment != "Kyaaahahahahaha!\nHey, how does it feel to be murdered by a weakling like me?\nIs it frustrating? Disappointing?\nNot that I care!")
                {
                    PerformFetchFailnaught1();
                    break;
                }
                else if (choice == 2 && LastComment != "Hehe... Ehehe, ahahaha!\nWeakling! Loser!\nWatch as you die without even knowing why!\nFetch Failnaught!")
                {
                    PerformFetchFailnaught2();
                    break;
                }
            }
            danoTotal += Controls.DamageFormulas.BaobhanNP(random, Atk, NPInstances, CritRate, CritDmg, 5, defesaInimigo, danoTotal);
            ExtraAttackCooldown -= 2;
            SpInitial = 0;
            if (ExtraAttackCooldown <= 0)
            {
               danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            FinnesseImproveDuration -= 1;
            if (FinnesseImproveDuration == 0)
            {
                Atk = AtkMax;
            }
            return danoTotal;
        }

        public int FinesseImprovement(int defesaInimigo, int danoTotal)
        {
            FinnesseImproveDuration = 3;
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.Red);
            Console.WriteLine(":");
            while (true)
            {
                int choice = random.Next(1, 4);

                if (choice == 1 && LastComment != "Cruelty. Depravity.")
                {
                    PerformComment4();
                    break;
                }
                else if (choice == 2 && LastComment != "Like taking a bath !")
                {
                    PerformComment5();
                    break;
                }
                else if (choice == 3 && LastComment != "More, more!")
                {
                    PerformComment6();
                    break;
                }
            }
            Atk = (int)(Atk * 1.35);
            ExtraAttackCooldown -= 1;
            SpInitial += 25;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            return danoTotal;
        }

        public int RangeAttack(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.Red);
            Console.WriteLine(":");

            while (true)
            {
                int choice = random.Next(1, 4);

                if (choice == 1 && LastComment != "You have awful taste!")
                {
                    PerformComment1();
                    break;
                }
                else if (choice == 2 && LastComment != "Does it hurt?")
                {
                    PerformComment2();
                    break;
                }
                else if (choice == 3 && (Hp / HpMax) <= (HpMax / 0.2) && LastComment != "Why don't you die?")
                {
                    PerformComment3();
                    break;
                }
            }
            danoTotal += Controls.DamageFormulas.CauseDamage(random, Atk, BasicAttack, CritRate, CritDmg, 2, defesaInimigo, danoTotal);
            ExtraAttackCooldown -= 1;
            SpInitial += 10;
            if (ExtraAttackCooldown <= 0)
            {
               danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            FinnesseImproveDuration -= 1;
            if (FinnesseImproveDuration == 0)
            {
                Atk = AtkMax;
            }
            return danoTotal;
        }
        public int ExtraAttack(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(_name, ConsoleColor.Red);
            Console.WriteLine(":");
            while (true)
            {
                int choice = random.Next(1, 4);

                if (choice == 1 && LastComment != "Watch closely.")
                {
                    PerformExtra1();
                    break;
                }
                else if (choice == 2 && LastComment != "Look, look!")
                {
                    PerformExtra2();
                    break;
                }
                else if (choice == 3 && LastComment != "How about being reborn as a wretched scapegoat?")
                {
                    PerformExtra3();
                    break;
                }
            }
            danoTotal += Controls.DamageFormulas.CauseDamage(random, Atk, Extra, CritRate, CritDmg, 4, defesaInimigo, danoTotal);
            SpInitial += 5;
            ExtraAttackCooldown = 5;
            return danoTotal;
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
        private void PerformFetchFailnaught1()
        {
            string comment = "Kyaaahahahahaha!\nHey, how does it feel to be murdered by a weakling like me?\nIs it frustrating? Disappointing?\nNot that I care!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\BaobhanNP1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            byte i = 0;
            foreach (char c in comment)
            {
                if (c == '!' && i < 1)
                {
                    Console.Write(c);
                    Thread.Sleep(1700);
                    i++;
                }
                else if (c == '?' && i < 2)
                {
                    Console.Write(c);
                    Thread.Sleep(1800);
                    i++;
                }
                else if (c == '?' && i < 3)
                {
                    Console.Write(c);
                    Thread.Sleep(1800);
                    i++;
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(40);
                }
            }
            Console.WriteLine();
        }
        
        private void PerformFetchFailnaught2()
        {
            string comment = "Hehe... Ehehe, ahahaha!\nWeakling! Loser!\nWatch as you die without even knowing why!\nFetch Failnaught!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\BaobhanNP2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            byte i = 0;
            foreach (char c in comment)
            {
                if (c == '!' && i < 1)
                {
                    Console.Write(c);
                    Thread.Sleep(2400);
                    i++;
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(40);
                }
            }
            Console.WriteLine();
        }

        private void PerformComment1()
        {
            string comment = "You have awful taste!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\BaobhanBasic1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
        }

        private void PerformComment2()
        {
            string comment = "Does it hurt?";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\BaobhanBasic2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
        }

        private void PerformComment3()
        {
            string comment = "Why don't you die?";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\BaobhanBasic3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
        }

        private void PerformComment4()
        {
            string comment = "Cruelty. Depravity.";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\Skill1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
        }

        private void PerformComment5()
        {
            string comment = "Like taking a bath !";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\Skill2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
        }

        private void PerformComment6()
        {
            string comment = "More, more!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\Skill3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
        }
        private void PerformExtra1()
        {
            string comment = "Watch closely.";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\BaobhanExtra1.wav";

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
            string comment = "Look, look!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\BaobhanExtra2.wav";

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
            string comment = "How about being reborn as a wretched scapegoat?";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\BaobhanExtra3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(12);
            }
            Console.WriteLine();
        }
        //  =========================================
        //  FIM DE "FUNCOES ACTIONS".
        //  =========================================

        public static void SkillsBaobhan(double sp, double spCost)
        {
            Controls.SistemaFGO.WriteColored("Extra Attack", ConsoleColor.Red);
            Console.Write(" Cooldown (");
            Controls.SistemaFGO.WriteColored(ExtraAttackCooldown, ConsoleColor.Red);
            Console.WriteLine(")\n");
            Controls.SistemaFGO.WriteColored("Range Attack", ConsoleColor.Red);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("1", ConsoleColor.Green);
            Console.WriteLine(")");
            Controls.SistemaFGO.WriteColored("Finesse Improvement", ConsoleColor.Red);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("2", ConsoleColor.Green);
            Console.WriteLine(")");
            if (sp < spCost)
            {
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Red);
                Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("Fetch Failnaught", ConsoleColor.Red);
                Console.Write(" (");
                Controls.SistemaFGO.WriteColored("3", ConsoleColor.Green);
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
                Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Red);
            }
            else if (sp >= spCost)
            {
                sp = spCost;
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Red);
                Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("Fetch Failnaught", ConsoleColor.Red);
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
                Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Red);
            }
        }
    }
}
