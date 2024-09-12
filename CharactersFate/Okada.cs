using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGO_BSx.CharactersFate
{
    internal class Okada : Interfaces.IAssassin
    {
        private string _name = "Okada Izo";
        private int _hpMax = 5751;
        private int _atkMax = 652;
        private int _defMax = 498;
        private int _hp = 5751;
        private int _atk = 152;
        private int _def = 498;
        private double _spCost = 190;
        private double _spInitial = 15;
        private double _basicAtk = 1.60;
        private double _extraAtk = 0.53; // 4 hits
        private static double _ultNpHit1 = 1.4; // 1 hit
        private static double _ultNpHit2 = 1.9; // 1 hit
        private static double _ultNpHit3 = 2.1; // 1 hit
        private static double _ultNpHit4 = 2.3; // 1 hit
        private static double _ultNpHit5 = 2.8; // 1 hit
        private int _spd = 130;
        private int _lvl = 1;
        private double _critDmg = 10;
        private double _critRate = 15;
        private double _classDmgBonus;
        internal string? LastComment { get; set; }
        internal double ClassDmgBonus { get => _classDmgBonus; set => _classDmgBonus = value; }
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
        internal int OkadaNpUltimateBuff { get; set; } = -1;
        internal int AntiSaberDuration { get; set; } = -1;
        internal static int ExtraAttackCooldown { get; set; } = 5;
        private static Random random = new Random();


        public int Shimatsuken(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.Cyan);
            Console.WriteLine(":");
            while (true)
            {
                int choice = random.Next(1, 3);

                if (choice == 1 && LastComment != "")
                {
                    PerformShimatsuken1();
                    break;
                }
                else if (choice == 2 && LastComment != "Kyaaahahahahaha!\nHey, how does it feel to be murdered by a weakling like me?\nIs it frustrating? Disappointing?\nNot that I care!")
                {
                    PerformShimatsuken2();
                    break;
                }
                else if (choice == 3 && LastComment != "Kyaaahahahahaha!\nHey, how does it feel to be murdered by a weakling like me?\nIs it frustrating? Disappointing?\nNot that I care!")
                {
                    PerformShimatsuken3();
                    break;
                }
            }
            //  Add ups
            CritRate += 32;
            CritDmg += 40;
            OkadaNpUltimateBuff = 1;
            //  Duration reducing
            ExtraAttackCooldown -= 1;
            AntiSaberDuration = 2;
            SpInitial = 20; // Recarga cai para 20
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            if (OkadaNpUltimateBuff == 0)
            {
                CritRate -= 32;
                CritDmg -= 40;
            }
            return danoTotal;

        }
        public int AntiSaberAtkUp(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.Cyan);
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
            //  Add ups
            Atk += (int)(Atk * 1.6);
            AntiSaberDuration = 2;
            //  Duration reducing
            ExtraAttackCooldown -= 1;
            OkadaNpUltimateBuff -= 1;
            SpInitial += 20;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal);
            }
            if (OkadaNpUltimateBuff == 0)
            {
                CritRate -= 32;
                CritDmg -= 40;
            }
            return danoTotal;
        }
        public int SwordSkill(int defesaInimigo, int danoTotal)
        {
            Controls.SistemaFGO.WriteColored(Name, ConsoleColor.Cyan);
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
                else if (choice == 3 && LastComment != "Why don't you die?")
                {
                    PerformComment3();
                    break;
                }
            }
            ExtraAttackCooldown -= 1;
            OkadaBuff -= 1;
            SpInitial += 15;
            if (ExtraAttackCooldown <= 0)
            {
                danoTotal += ExtraAttack(defesaInimigo, danoTotal); 
            }
            if (OkadaBuff == 0) 
            {
                CritRate -= 32;
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
            ExtraAttackCooldown = 6;
            SpInitial += 5;
            return Controls.DamageFormulas.CauseDamage(random, Atk, Extra, CritRate, CritDmg, 3, defesaInimigo, danoTotal);
        }
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
            string comment = "You have awful taste!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_SelectAttack1.wav";

            PlaySound(audioFilePath);

            
        }

        private void PerformComment2()
        {
            string comment = "Does it hurt?";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_Attack3.wav";

            PlaySound(audioFilePath);

        }

        private void PerformComment3()
        {
            string comment = "Why don't you die?";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_SelectAttack3.wav";

            PlaySound(audioFilePath);

            
        }
        private void PerformComment4()
        {
            string comment = "Cruelty. Depravity.";
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_Skill2.wav";
            LastComment = comment;
            PlaySound(audioFilePath);

        }
        private void PerformComment5()
        {
            string comment = "Like taking a bath !";
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_Skill3.wav";
            LastComment = comment;
            PlaySound(audioFilePath);
        }
        private void PerformComment6()
        {
            string comment = "More, more!";
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_Skill4.wav";
            LastComment = comment;
            PlaySound(audioFilePath);
        }
        private void PerformShimatsuken1()
        {
            string comment = "";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\OkadaNoises\S311_Stage1_NP2.wav";

            PlaySound(audioFilePath);

        }
        private void PerformShimatsuken2()
        {
            string comment = "Kyaaahahahahaha!\nHey, how does it feel to be murdered by a weakling like me?\nIs it frustrating? Disappointing?\nNot that I care!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\OkadaNoises\S311_Stage3_NP3.wav";

            PlaySound(audioFilePath);

        }
        private void PerformShimatsuken3()
        {
            string comment = "Kyaaahahahahaha!\nHey, how does it feel to be murdered by a weakling like me?\nIs it frustrating? Disappointing?\nNot that I care!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\OkadaNoises\S311_Stage3_NP3.wav";

            PlaySound(audioFilePath);

        }
        public static void SkillsOkada(double sp, double spCost)
        {
            Controls.SistemaFGO.WriteColored("Extra Attack", ConsoleColor.Cyan);
            Console.Write(" Cooldown (");
            Controls.SistemaFGO.WriteColored(ExtraAttackCooldown, ConsoleColor.Cyan);
            Console.WriteLine(")\n");
            Controls.SistemaFGO.WriteColored("Sword Attack", ConsoleColor.Cyan);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("1", ConsoleColor.Green);
            Console.WriteLine(")");
            Controls.SistemaFGO.WriteColored("Anti Saber", ConsoleColor.Cyan);
            Console.Write("(");
            Controls.SistemaFGO.WriteColored("ATK", ConsoleColor.Cyan);
            Controls.SistemaFGO.WriteColored("+", ConsoleColor.Green);
            Console.Write(")");
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("2", ConsoleColor.Green);
            Console.WriteLine(")");
            if (sp < spCost)
            {
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Cyan);
                Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("Shimatsuken", ConsoleColor.Cyan);
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
                Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Cyan);
            }
            else if (sp >= spCost)
            {
                sp = spCost;
                Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Cyan);
                Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.White);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("Shimatsuken", ConsoleColor.Cyan);
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
                Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Cyan);
            }
        }

        private static void PlaySound(string audioFilePath)
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
            }
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
            }
            audioFileReader = new AudioFileReader(audioFilePath);
            waveOutDevice = new WaveOutEvent();
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
        }
    }
}