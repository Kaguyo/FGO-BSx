namespace FGO_BSx.CharactersFate
{
    internal class Artoria : Interfaces.ISaber
    {
        internal static readonly Random random = new Random();

        // Fields
        private string _name = "Artoria";
        private double _hpMax = 5629;
        private int _atkMax = 772;
        private int _defMax = 629;
        private double _hp = 5629;
        private int _atk = 172;
        private int _def = 529;
        private double _spCost = 140;
        private double _spInitial = 0;
        private double _basicAtk = 1.70; // single hit
        private double _ultNp = 10.63; // single hit
        private double _extraAtk = 0.73; // 3 hits
        private int _spd = 110;
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
        internal double UltNp { get => _ultNp; set => _ultNp = value; }
        internal int SPD { get => _spd; set => _spd = value; }
        internal int Lvl { get => _lvl; set => _lvl = value; }
        internal double CritDmg { get => _critDmg; set => _critDmg = value; }
        internal double CritRate { get => _critRate; set => _critRate = value; }
        internal int ExcaliburBuff { get; set; }
        internal int ExtraAttackCooldown { get; set; }

        //  =========================================
        //  INICIO DE "FUNCOES PRIMARIAS".
        //  =========================================

        /* This comment serves to mark the beginning or end of functions that are designed to call other functions which perform actions in the game,
        as well as make general changes to stats, cooldowns, buffs, debuffs, etc., for better organization and pattern consistency.
        */
        public int Excalibur(int defesaInimigo, int danoTotal)
        {
            ExcaliburBuff = 2; // Contador de duração do buff após uso de Excalibur

            Controls.SistemaFGO.WriteColored(_name, ConsoleColor.Yellow);
            Console.WriteLine(":");
            while (true)
            {
                int choice = random.Next(1, 4);

                if (choice == 1 && LastComment != "Sheathed in the breath of the planet,\na torrent of shining life.\nFeel its wrath.\nEXCALIBUR ! !")
                {
                    CritRate += 20;
                    CritDmg += 40;
                    PerformExcalibur1();
                    break;
                }
                else if (choice == 2 && LastComment != "This light is the planet's hope...\nproof of the life that illuminates this world!\nBehold!\nEXCALIBUR ! !")
                {
                    CritRate += 20;
                    CritDmg += 40;
                    PerformExcalibur2();
                    break;
                }
                else if (choice == 3 && LastComment != "This light is the planet's hope...\nproof of the life that illuminates this world!\nLet us end this!\nEXCALIBUR ! !") 
                {
                    CritRate += 20;
                    CritDmg += 40;
                    PerformExcalibur3();
                    break;
                }
            }
            danoTotal += Controls.DamageFormulas.ArtoriaNP(random, Atk, UltNp, CritRate, CritDmg, defesaInimigo, danoTotal);
            ExtraAttackCooldown -= 1;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            return danoTotal;
        }

        public int ManaLoading(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(_name, ConsoleColor.Yellow);
            Console.WriteLine(":");
            while (true)
            {
                int choice = random.Next(1, 4);

                if (choice == 1 && LastComment != "Sacred sword, release...")
                {
                    PerformManaLoading1();
                    SpInitial += 60;
                    break;
                }
                else if (choice == 2 && LastComment != "If that is your decision...")
                {
                    PerformManaLoading2();
                    SpInitial += 60;
                    break;
                }
                else if (choice == 3 && LastComment != "All right. Let's finish this") 
                {
                    PerformManaLoading3();
                    SpInitial += 60;
                    break;
                }
            }
            ExtraAttackCooldown -= 1;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal = ExtraAttack(defesaInimigo, danoTotal);
            }
            ExcaliburBuff -= 1;
            if (ExcaliburBuff == 0) 
            {
                CritRate -= 20;
                CritDmg -= 40;
            }
            return danoTotal;
        }

        public int SwordSkill(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(_name, ConsoleColor.Yellow);
            Console.WriteLine(":");
            while (true)
            {
                int choice = random.Next(1, 5);

                if (choice == 1 && LastComment != "I'll take them myself!")
                {
                    PerformComment1();
                    SpInitial += 15;
                    break;
                }
                else if (choice == 2 && LastComment != "I'll show you my strength!")
                {
                    PerformComment2();
                    SpInitial += 15;
                    break;
                }
                else if (choice == 3 && LastComment != "I'll cut them down!")
                {
                    PerformComment3();
                    SpInitial += 15;
                    break;
                }
                else if (choice == 4 && LastComment != "There's still more!")
                {
                    PerformComment4();
                    SpInitial += 15;
                    break;
                }
            }
            danoTotal += Controls.DamageFormulas.CauseDamage(random, Atk, BasicAttack, CritRate, CritDmg, 1, defesaInimigo, danoTotal);
            ExtraAttackCooldown -= 1;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            ExcaliburBuff -= 1;
            if (ExcaliburBuff == 0)
            {
                CritRate -= 20;
                CritDmg -= 40;
            }
            return danoTotal;
        }
        public int ExtraAttack(int defesaInimigo, int danoTotal) 
        {
            Controls.SistemaFGO.WriteColored(_name, ConsoleColor.Yellow);
            Console.WriteLine(":");
            while (true)
            {
                int choice = random.Next(1, 4);

                if (choice == 1 && LastComment != "I'll take them myself!")
                {
                    PerformExtra1();
                    SpInitial += 5;
                    break;
                }
                else if (choice == 2 && LastComment != "O wind, whirl away!")
                {
                    PerformExtra2();
                    SpInitial += 5;
                    break;
                }
                else if (choice == 3 && LastComment != "Strike Air!") 
                {
                    PerformExtra3();
                    SpInitial += 5;
                    break;
                }
            }
            ExtraAttackCooldown = 6;
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
        specially the character comments.
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

        private void PerformComment4()
        {
            string comment = "There's still more!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\Basic4.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }

        private void PerformExcalibur1()
        {
            string comment = "Sheathed in the breath of the planet,\na torrent of shining life.\nFeel its wrath.\nEXCALIBUR ! !";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\NP1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            string exclamations = "EX";
            string calibur = "CALIBUR";
            string trailing = " ! !";

            foreach (char c in comment)
            {
                if (c == '\n')
                {
                    Console.Write(c);
                    Thread.Sleep(600);
                }
                else if (exclamations.Contains(c))
                {
                    Controls.SistemaFGO.WriteColored(c.ToString(), ConsoleColor.Yellow);
                    Thread.Sleep(40);
                }
                else if (calibur.Contains(c))
                {
                    Controls.SistemaFGO.WriteColored(c.ToString(), ConsoleColor.Yellow);
                    Thread.Sleep(10);
                }
                else if (trailing.Contains(c))
                {
                    Controls.SistemaFGO.WriteColored(c.ToString(), ConsoleColor.Yellow);
                    Thread.Sleep(42);
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(42);
                }
                if (c == 'X' && (comment.Contains("EXCALIBUR") || comment.Contains("EX")) &&
                    comment.IndexOf('X') == comment.IndexOf("EX", StringComparison.OrdinalIgnoreCase) + 1)
                {
                    Thread.Sleep(2000);
                }
            }
            Console.WriteLine();
        }

        private void PerformExcalibur2()
        {
            string comment = "This light is the planet's hope...\nproof of the life that illuminates this world!\nBehold!\nEXCALIBUR ! !";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\NP2.wav";
            string calibur = "CALIBUR ! !";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                if (c == '\n')
                {
                    Console.Write(c);
                    Thread.Sleep(650);
                }
                else if (c == 'B')
                {
                    Console.Write(c.ToString());
                    Thread.Sleep(42);
                }
                else if (c == 'E')
                {
                    Thread.Sleep(0500);
                    Controls.SistemaFGO.WriteColored2(ConsoleColor.Yellow);
                    Console.Write(c);
                    Thread.Sleep(42);
                }
                else if (c == 'X')
                {
                    Console.Write(c.ToString());
                    Thread.Sleep(1700);
                    foreach (char x in calibur)
                    {
                        Console.Write(x.ToString());
                        Thread.Sleep(10);
                    }
                    break;
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(42);
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        private void PerformExcalibur3()
        {
            string comment = "This light is the planet's hope...\nproof of the life that illuminates this world!\nLet us end this!\nEXCALIBUR ! !";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\NP3.wav";
            string calibur = "CALIBUR ! !";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                if (c == '\n')
                {
                    Console.Write(c);
                    Thread.Sleep(650);
                }
                else if (c == 'L')
                {
                    Console.Write(c.ToString());
                    Thread.Sleep(42);
                }
                else if (c == 'E')
                {
                    Thread.Sleep(0600);
                    Controls.SistemaFGO.WriteColored2(ConsoleColor.Yellow);
                    Console.Write(c);
                    Thread.Sleep(42);
                }
                else if (c == 'X')
                {
                    Console.Write(c.ToString());
                    Thread.Sleep(2000);
                    foreach (char x in calibur)
                    {
                        Console.Write(x.ToString());
                        Thread.Sleep(10);
                    }
                    break;
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(42);
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        private void PerformManaLoading1()
        {
            string comment = "Sacred sword, release...";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\Mana1.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                if (c == ',') 
                {
                    Console.Write(c);
                    Thread.Sleep(0400);
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(22);
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private void PerformManaLoading2()
        {
            string comment = "If that is your decision...";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\Mana2.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private void PerformManaLoading3()
        {
            string comment = "All right. Let's finish this";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\ArtoriasNoises\Mana3.wav";

            Controls.SistemaFGO.PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                if (c == '.')
                {
                    Console.Write(c);
                    Thread.Sleep(0400);
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(22);
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        //  =========================================
        //  FIM DE "FUNCOES ACTIONS".
        //  =========================================

        public static void SkillsArtoria(double sp, double spCost)
        {
            Controls.SistemaFGO.WriteColored("Sword Attack", ConsoleColor.Yellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("1", ConsoleColor.Green);
            Console.WriteLine(")");
            Controls.SistemaFGO.WriteColored("Mana Loading", ConsoleColor.Yellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("2", ConsoleColor.Green);
            Console.WriteLine(")");
            if (sp < spCost)
            {
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Yellow);
                Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("Excalibur", ConsoleColor.Yellow);
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
                Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Yellow);
            }
            else if (sp >= spCost)
            {
                sp = spCost;
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Yellow);
                Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("Excalibur", ConsoleColor.Yellow);
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