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
    internal class Baobhan : FGO_BSx.Interfaces.IArcher
    {
        internal String name = "Baobhan";
        internal double hpMax = 4929;
        internal int atkMax = 152;
        internal int defMax = 499;
        internal double hp = 4929;
        internal int atk = 152;
        internal int def = 499;
        internal int spCost = 100;
        internal int spInitial = 0;
        internal double basicAtk = 1.30;
        internal double ultNp = 4.3;
        internal int spd = 100;
        internal int lvl = 1;
        internal double critDmg = 10;
        internal double critRate = 5;

        private static Random random = new Random();
        private static IWavePlayer waveOutDevice;
        private static WaveStream audioFileReader;

        public void FetchFailnaught() 
        {
            FGO_BSx.Controls.SistemaFGO.WriteColored(name, ConsoleColor.Red);
            Console.WriteLine(":");
            int choice = random.Next(1, 3);
            int lastChoice;

            switch (choice)
            {
                case 1:
                    lastChoice = choice;
                    PerformFetchFailnaught1();
                    break;
                case 2:
                    lastChoice = choice;
                    PerformFetchFailnaught2();
                    break;
            }
        }
        private void PerformFetchFailnaught2()
        {
            string comment = "Hehe... Ehehe, ahahaha!\nWeakling! Loser!\nWatch as you die without even knowing why!\nFetch Failnaught!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\srcFate\Characters\BaobhanNoises\S311_Stage1_NP2.wav";

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
        static void WriteColored2(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        private void PerformFetchFailnaught1()
        {
            string comment = "Kyaaahahahahaha!\nHey, how does it feel to be murdered by a weakling like me?\nIs it frustrating? Disappointing?\nNot that I care!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\srcFate\Characters\BaobhanNoises\S311_Stage3_NP3.wav";

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

        public void FinesseImprovement() 
        {
            FGO_BSx.Controls.SistemaFGO.WriteColored(name, ConsoleColor.Red);
            Console.WriteLine(":");
            int choice = random.Next(1, 4);
            int lastChoice;

            switch (choice)
            {
                case 1:
                    lastChoice = choice;
                    PerformComment4();
                    break;
                case 2:
                    lastChoice = choice;
                    PerformComment5();
                    break;
                case 3:
                    lastChoice = choice;
                    PerformComment6();
                    break;
            }
        }
        private void PerformComment6()
        {
            string comment = "More, more!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\srcFate\Characters\BaobhanNoises\S311_Stage1_Skill4.wav";

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
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\srcFate\Characters\BaobhanNoises\S311_Stage1_Skill3.wav";

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
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\srcFate\Characters\BaobhanNoises\S311_Stage1_Skill2.wav";

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
            FGO_BSx.Controls.SistemaFGO.WriteColored(name, ConsoleColor.Red);
            Console.WriteLine(":");
            int choice = random.Next(1, 4);
            int lastChoice;

            while (true)
            {
                if (choice == 1)
                {
                    PerformComment1();
                    lastChoice = choice;
                    break;
                }
                else if (choice == 2)
                {
                    PerformComment2();
                    lastChoice = choice;
                    break;
                }
                else if (choice == 3 && (hp / hpMax) <= (hpMax / 0.2))
                {
                    PerformComment3();
                    lastChoice = choice;
                    break;
                }
                else
                {
                    choice = random.Next(1, 4);
                }
            }
        }
        private void PerformComment1()
        {
            string comment = "You have awful taste!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\srcFate\Characters\BaobhanNoises\S311_Stage1_SelectAttack1.wav";

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
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\srcFate\Characters\BaobhanNoises\S311_Stage1_Attack3.wav";

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
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\srcFate\Characters\BaobhanNoises\S311_Stage1_SelectAttack3.wav";

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
            FGO_BSx.Controls.SistemaFGO.WriteColored("Range Attack", ConsoleColor.Red);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("1", ConsoleColor.Green);
            Console.WriteLine(")");
            FGO_BSx.Controls.SistemaFGO.WriteColored("Finesse Improvement", ConsoleColor.Red);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("2", ConsoleColor.Green);
            Console.WriteLine(")");
            if (sp < spCost)
            {
                FGO_BSx.Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Red);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.Magenta);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.Gray);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Fetch Failnaught", ConsoleColor.Red);
                Console.Write(" (");
                Controls.SistemaFGO.WriteColored("3", ConsoleColor.Green);
                Console.Write(")");
                FGO_BSx.Controls.SistemaFGO.WriteColored(")", ConsoleColor.Gray);
                Controls.SistemaFGO.WriteColored("\nNP Energy", ConsoleColor.Magenta);
                Console.Write(": ");
                sp /= spCost;
                sp *= 100;
                FGO_BSx.Controls.SistemaFGO.WriteColored((int)sp, ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("/", ConsoleColor.Magenta);
                FGO_BSx.Controls.SistemaFGO.WriteColored("100", ConsoleColor.Green);
                FGO_BSx.Controls.SistemaFGO.WriteColored("  NOT READY", ConsoleColor.DarkRed);
                FGO_BSx.Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Red);
            }
            else if (sp >= spCost)
            {
                sp = spCost;
                FGO_BSx.Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Red);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.Magenta);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.Gray);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Fetch Failnaught", ConsoleColor.Red);
                Console.Write(" (");
                Controls.SistemaFGO.WriteColored("3", ConsoleColor.Green);
                Console.Write(")");
                FGO_BSx.Controls.SistemaFGO.WriteColored(")", ConsoleColor.Gray);
                Controls.SistemaFGO.WriteColored("\nNP Energy", ConsoleColor.Magenta);
                Console.Write(": ");
                sp /= spCost;
                sp *= 100;
                FGO_BSx.Controls.SistemaFGO.WriteColored(((int)sp), ConsoleColor.Green);
                Controls.SistemaFGO.WriteColored("/", ConsoleColor.Magenta);
                FGO_BSx.Controls.SistemaFGO.WriteColored("100", ConsoleColor.Green);
                FGO_BSx.Controls.SistemaFGO.WriteColored("  READY", ConsoleColor.Green);
                FGO_BSx.Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Red);
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
