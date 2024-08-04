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
        private static Random random = new Random();
        private static IWavePlayer waveOutDevice; // Para tocar áudio
        private static WaveStream audioFileReader; // Para ler o arquivo de áudio

        public void SwordSkill()
        {
            WriteColored(name, ConsoleColor.Yellow);
            Console.WriteLine(":");
            int choice = random.Next(1, 5);
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
                case 4:
                    lastChoice = choice;
                    PerformComment4();
                    break;
            }
        }

        public void Excalibur()
        {
            WriteColored(name, ConsoleColor.Yellow);
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

        private void PerformComment1()
        {
            string comment = "I'll take them myself!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_Skill4.wav";

            PlaySound(audioFilePath); // Inicia o áudio

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22); // Corrigido para um valor mais razoável
            }
            Console.WriteLine(); // Para adicionar uma nova linha após o comentário
            Console.ReadKey();
        }

        private void PerformComment2()
        {
            string comment = "I'll show you my strength!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_Skill2.wav";

            PlaySound(audioFilePath); // Inicia o áudio

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(22); // Corrigido para um valor mais razoável
            }
            Console.WriteLine(); // Para adicionar uma nova linha após o comentário
            Console.ReadKey();
        }

        private void PerformComment3()
        {
            string comment = "I'll cut them down!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_Attack4.wav";

            PlaySound(audioFilePath); // Inicia o áudio

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(10); // Corrigido para um valor mais razoável
            }
            Console.WriteLine(); // Para adicionar uma nova linha após o comentário
            Console.ReadKey();
        }

        private void PerformComment4()
        {
            string comment = "There's still more!";
            string audioFilePath = @"C:\Users\Kaguyo\Desktop\ArtoriasNoises\S002_Attack5.wav";

            PlaySound(audioFilePath); // Inicia o áudio

            foreach (char c in comment)
            {
                Console.Write(c);
                Thread.Sleep(10); // Corrigido para um valor mais razoável
            }
            Console.WriteLine(); // Para adicionar uma nova linha após o comentário
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
                    WriteColored(c.ToString(), ConsoleColor.Yellow);
                    Thread.Sleep(40);
                }
                else if (calibur.Contains(c))
                {
                    WriteColored(c.ToString(), ConsoleColor.Yellow);
                    Thread.Sleep(10);
                }
                else if (trailing.Contains(c))
                {
                    WriteColored(c.ToString(), ConsoleColor.Yellow);
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
                    Thread.Sleep(0200);
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
                else { Console.Write(c);
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
                    Thread.Sleep(0200);
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

        static void WriteColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        static void WriteColored2(ConsoleColor color)// Não Reseta a cor ao padrão
        {
            Console.ForegroundColor = color;
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
    }
}