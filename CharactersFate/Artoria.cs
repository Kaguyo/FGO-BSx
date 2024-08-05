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
    internal class Artoria : FGO_BSx.Interfaces.ISaber
    {
        internal String name = "Artoria";
        internal double hpMax = 5629;
        internal int atkMax = 172;
        internal int defMax = 529;
        internal double hp = 5629;
        internal int atk = 172;
        internal int def = 529;
        internal double spCost = 140;
        internal double spInitial = 105;
        internal double basicAtk = 1.70;
        internal double ultNp = 5.33;
        internal int spd = 110;
        internal int lvl = 1;
        internal double critDmg = 10;
        internal double critRate = 5;

        private static Random random = new Random();
        private static IWavePlayer waveOutDevice;
        private static WaveStream audioFileReader;

        public void Excalibur()
        {
            FGO_BSx.Controls.SistemaFGO.WriteColored(name, ConsoleColor.Yellow);
            Console.WriteLine(":");
            int choice = random.Next(1, 4);
            int lastChoice = 0;

            while (choice == lastChoice)
            {
                choice = random.Next(1, 4);
            }
            switch (choice)
            {
                case 1:
                    PerformExcalibur1();
                    break;
                case 2:
                    PerformExcalibur2();
                    break;
                case 3:
                    PerformExcalibur3();
                    break;
            }
        }

        public void ManaLoading()
        {
            FGO_BSx.Controls.SistemaFGO.WriteColored(name, ConsoleColor.Yellow);
            Console.WriteLine(":");
            int choice = random.Next(1, 4);
            int lastChoice = 0;

            while (choice == lastChoice)
            {
                choice = random.Next(1, 4);
            }
            switch (choice)
            {
                case 1:
                    PerformManaLoading1();
                    break;
                case 2:
                    PerformManaLoading2();
                    break;
                case 3:
                    PerformManaLoading3();
                    break;
            }
        }

        public void SwordSkill()
        {
            FGO_BSx.Controls.SistemaFGO.WriteColored(name, ConsoleColor.Yellow);
            Console.WriteLine(":");
            int choice = random.Next(1, 4);
            int lastChoice;

            switch (choice)
            {
                case 1:
                    lastChoice = choice;
                    PerformComment1();
                    break;
                case 2:
                    lastChoice = choice;
                    PerformComment2();
                    break;
                case 3:
                    lastChoice = choice;
                    PerformComment3();
                    break;
            }
        }

        private void PerformComment1()
        {
            string comment = "I'll take them myself!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_Skill4.wav";

            PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private void PerformComment2()
        {
            string comment = "I'll show you my strength!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_Skill2.wav";

            PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private void PerformComment3()
        {
            string comment = "I'll cut them down!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_Attack4.wav";

            PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private void PerformComment4()
        {
            string comment = "There's still more!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_Attack5.wav";

            PlaySound(audioFilePath);

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private void PerformExcalibur1()
        {
            string comment = "Sheathed in the breath of the planet,\na torrent of shining life.\nFeel its wrath.\nEXCALIBUR ! !";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_NP1.wav";

            PlaySound(audioFilePath);

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
                    FGO_BSx.Controls.SistemaFGO.WriteColored(c.ToString(), ConsoleColor.Yellow);
                    Thread.Sleep(40);
                }
                else if (calibur.Contains(c))
                {
                    FGO_BSx.Controls.SistemaFGO.WriteColored(c.ToString(), ConsoleColor.Yellow);
                    Thread.Sleep(10);
                }
                else if (trailing.Contains(c))
                {
                    FGO_BSx.Controls.SistemaFGO.WriteColored(c.ToString(), ConsoleColor.Yellow);
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
            Console.ReadKey();
        }

        private void PerformExcalibur2()
        {
            string comment = "This light is the planet's hope...\nproof of the life that illuminates this world!\nBehold!\nEXCALIBUR ! !";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_NP2.wav";

            PlaySound(audioFilePath);

            string exclamations = "EX";
            string calibur = "CALIBUR ! !";

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
                    WriteColored2(ConsoleColor.Yellow);
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
            Console.ReadKey();
        }

        private void PerformExcalibur3()
        {
            string comment = "This light is the planet's hope...\nproof of the life that illuminates this world!\nLet us end this!\nEXCALIBUR ! !";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_NP3.wav";

            PlaySound(audioFilePath);

            string exclamations = "EX";
            string calibur = "CALIBUR ! !";

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
                    WriteColored2(ConsoleColor.Yellow);
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
            Console.ReadKey();
        }

        private void PerformManaLoading1()
        {
            string comment = "Sacred sword, release...";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_mana1.wav";

            PlaySound(audioFilePath);

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
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_mana2.wav";

            PlaySound(audioFilePath);

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
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_mana3.wav";

            PlaySound(audioFilePath);

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

        private void PlaySound(string audioFilePath)
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

        public static void SkillsArtoria(double sp, double spCost)
        {
            FGO_BSx.Controls.SistemaFGO.WriteColored("Sword Attack", ConsoleColor.Yellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("1", ConsoleColor.Green);
            Console.WriteLine(")");
            FGO_BSx.Controls.SistemaFGO.WriteColored("Mana Loading", ConsoleColor.Yellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("2", ConsoleColor.Green);
            Console.WriteLine(")");
            if (sp < spCost)
            {
                FGO_BSx.Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Yellow);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.Magenta);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.Gray);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Excalibur", ConsoleColor.Yellow);
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
                FGO_BSx.Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Yellow);
            }
            else if (sp >= spCost)
            {
                sp = spCost;
                FGO_BSx.Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Yellow);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.Magenta);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.Gray);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Excalibur", ConsoleColor.Yellow);
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
                FGO_BSx.Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Yellow);
            }
        }
    }
}