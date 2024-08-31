using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NAudio.Wave;
using System.Xml.Linq;

namespace FGO_BSx.CharactersFate
{
    internal class Baobhan : Interfaces.IArcher
    {
        private string _name = "Baobhan";
        private double _hpMax = 4929;
        private int _atkMax = 152;
        private int _defMax = 499;
        private double _hp = 4929;
        private int _atk = 152;
        private int _def = 499;
        private double _spCost = 100;
        private double _spInitial = 0;
        private double _basicAtk = 1.30;
        private double _ultNp = 4.3;
        private int _spd = 100;
        private int _lvl = 1;
        private double _critDmg = 10;
        private double _critRate = 5;
        internal string? LastComment { get; set; }
        internal string Name
        {
            get { return _name; }
        }
        internal double HpMax
        {
            get
            {
                return _hpMax;
            }
            set
            {
                _hpMax = value;
            }
        }
        internal int AtkMax
        {
            get
            {
                return _atkMax;
            }
            set
            {
                _atkMax = value;
            }
        }
        internal int DefMax
        {
            get
            {
                return _defMax;
            }
            set
            {
                _defMax = value;
            }
        }
        internal double Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }
        }
        internal int Atk
        {
            get
            {
                return _atk;
            }
            set
            {
                _atk = value;
            }
        }
        internal int Def
        {
            get
            {
                return _def;
            }
            set
            {
                _def = value;
            }
        }
        internal double SpCost
        {
            get
            {
                return _spCost;
            }
            set
            {
                _spCost = value;
            }
        }
        internal double SpInitial
        {
            get
            {
                return _spInitial;
            }
            set
            {
                _spInitial = value;
            }
        }
        internal double BasicAttack
        {
            get
            {
                return _basicAtk;
            }
            set
            {
                _basicAtk = value;
            }
        }
        internal double UltNp
        {
            get
            {
                return _ultNp;
            }
            set
            {
                _ultNp = value;
            }
        }
        internal int SPD
        {
            get
            {
                return _spd;
            }
            set
            {
                _spd = value;
            }
        }
        internal int Lvl
        {
            get
            {
                return _lvl;
            }
            set
            {
                _lvl = value;
            }
        }
        internal double CritDmg
        {
            get
            {
                return _critDmg;
            }
            set
            {
                _critDmg = value;
            }
        }
        internal double CritRate
        {
            get
            {
                return _critRate;
            }
            set
            {
                _critRate = value;
            }
        }

        private static Random random = new Random();
        private static IWavePlayer waveOutDevice;
        private static WaveStream audioFileReader;

        public void FetchFailnaught() 
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
        }
        private void PerformFetchFailnaught1()
        {
            string comment = "Kyaaahahahahaha!\nHey, how does it feel to be murdered by a weakling like me?\nIs it frustrating? Disappointing?\nNot that I care!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage3_NP3.wav";

            PlaySound(audioFilePath);
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
                    Thread.Sleep(1000);
                    i++;
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(40);
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        private void PerformFetchFailnaught2()
        {
            string comment = "Hehe... Ehehe, ahahaha!\nWeakling! Loser!\nWatch as you die without even knowing why!\nFetch Failnaught!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_NP2.wav";

            PlaySound(audioFilePath);
            byte i = 0;
            byte j = 0;
            foreach (char c in comment)
            {
                if (c == 'E')
                {
                    if (i != 1)
                    {
                        Thread.Sleep(1100);
                        Console.Write(c);
                        i++;
                    }
                }
                else if (c == '!')
                {
                    Thread.Sleep(1100);
                    j++;
                    if (j == 2)
                    {
                        Thread.Sleep(150);
                        Console.Write(c);
                    }
                    else if (j == 3)
                    {
                        Thread.Sleep(1000);
                        Console.Write(c);
                    }
                    else if (j == 4) 
                    {
                        Console.Write(c);
                        Thread.Sleep(500);
                        WriteColored2(ConsoleColor.Red); 
                    }
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(35);
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public void FinesseImprovement() 
        {
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
                }
            }
        }
        private void PerformComment6()
        {
            string comment = "More, more!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_Skill4.wav";

            PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                if (c == ',')
                {
                    Console.Write(c);
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(15);
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        private void PerformComment5()
        {
            string comment = "Like taking a bath !";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_Skill3.wav";

            PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                if (c == 'h')
                {
                    Console.Write(c);
                    Thread.Sleep(350);
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(40);
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        private void PerformComment4()
        {
            string comment = "Cruelty. Depravity.";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_Skill2.wav";

            PlaySound(audioFilePath);
            byte i = 0;
            foreach (char c in comment)
            {

                if (c == '.')
                {
                    Console.Write(c);
                    if (i != 1)
                    {
                        Thread.Sleep(290);
                        i++;
                    }
                }
                else
                {
                    Console.Write(c);
                    Thread.Sleep(40);
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public void RangeAttack() 
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
        }
        private void PerformComment1()
        {
            string comment = "You have awful taste!";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_SelectAttack1.wav";

            PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private void PerformComment2()
        {
            string comment = "Does it hurt?";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_Attack3.wav";

            PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(25);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private void PerformComment3()
        {
            string comment = "Why don't you die?";
            LastComment = comment;
            string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Characters\BaobhanNoises\S311_Stage1_SelectAttack3.wav";

            PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public static void SkillsBaobhan(double sp, double spCost)
        {
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
        static void WriteColored2(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
