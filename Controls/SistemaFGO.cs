using FGO_BSx.CharactersFate;
using System;

namespace FGO_BSx.Controls
{
    public class SistemaFGO
    {
        static public string pararJogo = "";
        static public string escolhaSkill = "";
        static public object personagemEscolhido;

        public static void WriteColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteColored(int i, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(i);
            Console.ResetColor();
        }

        public static void WriteColoredAnsi(string text, string ansiColor)
        {
            Console.Write($"{ansiColor}{text}\x1b[0m");
        }

        public static void WriteColoredAnsi(int i, string ansiColor)
        {
            Console.Write($"{ansiColor}{i}\x1b[0m");
        }

        public static string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Converter a primeira letra para maiúscula
            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static void MyServant(object personagemEscolhido)
        {
            if (personagemEscolhido is Artoria artoria)
            {
                WriteColored("Artoria", ConsoleColor.Yellow);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)artoria.hp, (int)artoria.hpMax);
            }
            else if (personagemEscolhido is Baobhan baobhan)
            {
                WriteColored("Baobhan", ConsoleColor.Red);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)baobhan.hp, (int)baobhan.hpMax);
            }
            else if (personagemEscolhido is FirstHassan firstHassan)
            {
                WriteColored("Hassan", ConsoleColor.DarkMagenta);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)firstHassan.hp, (int)firstHassan.hpMax);
            }
            else if (personagemEscolhido is Mordred mordred)
            {
                WriteColored("Mordred", ConsoleColor.Yellow);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)mordred.hp, (int)mordred.hpMax);
            }
            else if (personagemEscolhido is Tristan tristan)
            {
                WriteColored("Tristan", ConsoleColor.DarkRed);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)tristan.hp, (int)tristan.hpMax);
            }
            else if (personagemEscolhido is Okada okada)
            {
                WriteColored("Okada", ConsoleColor.DarkGray);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)okada.hp, (int)okada.hpMax);
            }
        }

        public static void DisplayHP(int hp, int hpMax)
        {
            if ((double)hp / hpMax <= 0.2)
            {
                WriteColoredAnsi(hp, "\x1b[38;5;124m"); // Vermelho
            }
            else if ((double)hp / hpMax < 0.6)
            {
                WriteColoredAnsi(hp, "\x1b[38;5;226m"); // Amarelo intenso
            }
            else
            {
                WriteColoredAnsi(hp, "\x1b[38;5;46m"); // Verde
            }
            Console.Write("/");
            WriteColoredAnsi(hpMax, "\x1b[38;5;46m"); // Verde
        }
    }
}