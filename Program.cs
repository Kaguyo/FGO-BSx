using System;
using System.Linq;

namespace FGO_BSx
{
    public class Program
    {
        public static void Main()
        {
            string PararJogo = "";
            string EscolhaSkill = "";

            while (PararJogo != "stop" && PararJogo != "0")
            {
                FGO_BSx.CharactersFate.Artoria artoria = new FGO_BSx.CharactersFate.Artoria();
                FGO_BSx.CharactersFate.Baobhan baobhan = new FGO_BSx.CharactersFate.Baobhan();
                FGO_BSx.CharactersFate.Mordred mordred = new FGO_BSx.CharactersFate.Mordred();
                FGO_BSx.CharactersFate.Tristan tristan = new FGO_BSx.CharactersFate.Tristan();
                FGO_BSx.CharactersFate.FirstHassan firstHassan = new FGO_BSx.CharactersFate.FirstHassan();
                FGO_BSx.CharactersFate.Okada okada = new FGO_BSx.CharactersFate.Okada();

                string[] personagens = { artoria.name, baobhan.name, okada.name, mordred.name, tristan.name, firstHassan.name };
                string escolhaPersonagem = "";

                while (!(personagens.Contains(escolhaPersonagem)
                        && escolhaPersonagem != "1"
                        && escolhaPersonagem != "2"
                        && escolhaPersonagem != "3"
                        && escolhaPersonagem != "4"
                        && escolhaPersonagem != "5"
                        && escolhaPersonagem != "6"
                        && escolhaPersonagem != "0"))
                {
                    Console.Clear();
                    Console.WriteLine("===============");
                    WriteColored("Select a Servant", ConsoleColor.Green);
                    Console.WriteLine(":");
                    Console.WriteLine("===============\n");

                    for (int i = 0; i < personagens.Length; i++)
                    {
                        if (personagens[i].Contains("Artoria"))
                        {
                            WriteColored(personagens[i], ConsoleColor.White);
                            Console.Write(" (");
                            WriteColored((i + 1).ToString(), ConsoleColor.Green);
                            Console.WriteLine(")");
                        }
                        else if (personagens[i].Contains("Hassan"))
                        {
                            WriteColored(personagens[i], ConsoleColor.White);
                            Console.Write(" (");
                            WriteColored((i + 1).ToString(), ConsoleColor.Green);
                            Console.WriteLine(")");
                        }
                        else if (personagens[i].Contains("Baobhan"))
                        {
                            WriteColored(personagens[i], ConsoleColor.White);
                            Console.Write(" (");
                            WriteColored((i + 1).ToString(), ConsoleColor.Green);
                            Console.WriteLine(")");
                        }
                        else if (personagens[i].Contains("Okada"))
                        {
                            WriteColored(personagens[i], ConsoleColor.White);
                            Console.Write(" (");
                            WriteColored((i + 1).ToString(), ConsoleColor.Green);
                            Console.WriteLine(")");
                        }
                        else if (personagens[i].Contains("Mordred"))
                        {
                            WriteColored(personagens[i], ConsoleColor.White);
                            Console.Write(" (");
                            WriteColored((i + 1).ToString(), ConsoleColor.Green);
                            Console.WriteLine(")");
                        }
                        else if (personagens[i].Contains("Tristan"))
                        {
                            WriteColored(personagens[i], ConsoleColor.White);
                            Console.Write(" (");
                            WriteColored((i + 1).ToString(), ConsoleColor.Green);
                            Console.WriteLine(")");
                        }
                    }

                    Console.Write("\n\nLeave Game ( ");
                    WriteColored("0", ConsoleColor.Green);
                    Console.Write(" / ");
                    WriteColored("STOP", ConsoleColor.Green);
                    Console.WriteLine(")");

                    Console.Write("\nSelect: ");
                    escolhaPersonagem = Console.ReadLine().ToString().ToLower();
                    escolhaPersonagem = Capitalize(escolhaPersonagem);

                    Console.Clear();
                }

                Console.WriteLine("===============");
                WriteColored("Skills", ConsoleColor.Green);
                Console.WriteLine(":");
                Console.WriteLine("===============\n");

                Console.Write("Basic Skill (");
                WriteColored("1", ConsoleColor.Green);
                Console.WriteLine(")");

                Console.Write("Ultimate Skill (");
                WriteColored("2", ConsoleColor.Green);
                Console.WriteLine(")");

                Console.Write("Desistir (");
                WriteColored("0", ConsoleColor.Green);
                Console.Write(" / ");
                WriteColored("STOP", ConsoleColor.Green);
                Console.WriteLine(")");

                while (EscolhaSkill != "1" && EscolhaSkill != "2" && EscolhaSkill != "0" && EscolhaSkill != "stop")
                {
                    Console.Write("\nSelect a Skill: ");
                    EscolhaSkill = Console.ReadLine().ToLower();
                }

                if (EscolhaSkill == "1")
                {
                    artoria.SwordSkill();
                    EscolhaSkill = "";
                }
                else if (EscolhaSkill == "2")
                {
                    artoria.Excalibur();
                    EscolhaSkill = "";
                }
                else if (EscolhaSkill == "0" || EscolhaSkill == "stop")
                {
                    break;
                }
            }
        }

        private static void WriteColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        private static void WriteColored(int i, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(i);
            Console.ResetColor();
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
    }
}
