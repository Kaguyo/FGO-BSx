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
        private string _name = "Okada";
        private int _hpMax = 5751;
        private int _atkMax = 652;
        private int _defMax = 498;
        private int _hp = 5751;
        private int _atk = 152;
        private int _def = 498;
        private double _spCost = 130;
        private double _spInitial = 15;
        private double _basicAtk = 1.60;
        private double _ultNp = 6.3;
        private int _spd = 130;
        private int _lvl = 1;
        private double _critDmg = 10;
        private double _critRate = 5;
        internal string? LastComment { get; set; }
        internal string Name
        {
            get { return _name; }
        }
        internal int HpMax
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
        internal int Hp
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


        public void Shimatsuken(int defesaInimigo)
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
            }
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

        public void AntiSaberAtkUp(int defesaInimigo)
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

        public void SwordSkill(int defesaInimigo)
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
        public static void SkillsOkada(double sp, double spCost)
        {
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