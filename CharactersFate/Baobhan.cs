namespace FGO_BSx.CharactersFate
{
    internal class Baobhan : Interfaces.IArcher
    {
        private static readonly Random random = new Random();

        internal string Name { get; } = "Baobhan";
        internal int HpMax { get; set; } = 4929;
        internal int AtkMax { get; set; } = 6320;
        internal int DefMax { get; set; } = 499;
        internal int Hp { get; set; } = 4929;
        internal int Atk { get; set; } = 6320;
        internal int Def { get; set; } = 499;
        internal double SpCost { get; set; } = 100;
        internal double SpInitial { get; set; } = 0;
        internal double BasicAttack { get; set; } = 0.65;
        internal double Extra { get; set; } = 0.55;
        internal static double UltNpHit1 { get; set; } = 0.9;
        internal static double UltNpHit2 { get; set; } = 1.2;
        internal static double UltNpHit3 { get; set; } = 2.1;
        internal static double UltNpHit4 { get; set; } = 3.02;
        internal static double UltNpHit5 { get; set; } = 3.5;
        internal int SPD { get; set; } = 100;
        internal double CritDmg { get; set; } = 10;
        internal double CritRate { get; set; } = 5;
        internal double ClassDmgBonus { get; set; }
        internal string? LastComment { get; set; }
        internal static int FinnesseImproveDuration { get; set; } = -1;
        internal static int ExtraAttackCooldown { get; set; } = 5;
        internal static double[] NPInstances { get; } = { UltNpHit1, UltNpHit2, UltNpHit3, UltNpHit4, UltNpHit5 };
        internal static int Level { get; set; } = 1;
        internal static int Exp { get; set; } = 0;
        internal static int ExpNeeded { get; set; } = 70;



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
            if (Atk > AtkMax) { }
            else
            {
                Atk = (int)(Atk * 1.35);
            }
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
            danoTotal += Controls.DamageFormulas.CauseDamage(random, Atk, BasicAttack, CritRate, CritDmg, 2, defesaInimigo, danoTotal, Name);
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
            Console.Clear();
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.Red);
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
            danoTotal += Controls.DamageFormulas.CauseDamage(random, Atk, Extra, CritRate, CritDmg, 4, defesaInimigo, danoTotal, Name);
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
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\BaobhanNP1.wav";

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
                    Thread.Sleep(2000);
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
            Console.ReadKey(true);
            
        }
        
        private void PerformFetchFailnaught2()
        {
            string comment = "Hehe... Ehehe, ahahaha!\nWeakling! Loser!\nWatch as you die without even knowing why!\nFetch Failnaught!";
            LastComment = comment;
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\BaobhanNP2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            byte i = 0;
            foreach (char c in comment)
            {
                if (c == '!' && i < 1)
                {
                    Console.Write(c);
                    Thread.Sleep(2700);
                    i++;
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(40);
                }
                if (c == '!' && i == 3)
                {
                    Console.Write(c);
                    Thread.Sleep(2000);
                    i++;
                }
            }
            Console.WriteLine();
            Console.ReadKey(true);
            
        }

        private void PerformComment1()
        {
            string comment = "You have awful taste!";
            LastComment = comment;
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\BaobhanBasic1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
            Console.ReadKey(true);

        }

        private void PerformComment2()
        {
            string comment = "Does it hurt?";
            LastComment = comment;
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\BaobhanBasic2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
            Console.ReadKey(true);

        }

        private void PerformComment3()
        {
            string comment = "Why don't you die?";
            LastComment = comment;
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\BaobhanBasic3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
            Console.ReadKey(true);
            
        }

        private void PerformComment4()
        {
            string comment = "Cruelty. Depravity.";
            LastComment = comment;
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\Skill1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
            Console.ReadKey(true);

        }

        private void PerformComment5()
        {
            string comment = "Like taking a bath !";
            LastComment = comment;
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\Skill2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
            Console.ReadKey(true);

        }

        private void PerformComment6()
        {
            string comment = "More, more!";
            LastComment = comment;
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\Skill3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);
            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
            Console.ReadKey(true);

        }
        private void PerformExtra1()
        {
            string comment = "Watch closely.";
            LastComment = comment;
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\BaobhanExtra1.wav";

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
            string comment = "Look, look!";
            LastComment = comment;
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\BaobhanExtra2.wav";

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
            Console.ReadKey(true);
            Console.Clear();
        }
        private void PerformExtra3()
        {
            string comment = "How about being reborn as a wretched scapegoat?";
            LastComment = comment;
            string audioFilePath = @"..\..\..\Track&Sounds\Characters\BaobhanNoises\BaobhanExtra3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(12);
            }
            Console.WriteLine();
            Console.ReadKey(true);
            Console.Clear();
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
