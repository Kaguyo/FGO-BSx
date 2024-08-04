using System;
using System.Linq;

namespace FGO_BSx
{
    public class Program
    {
        public static void Main()
        {
            

            while (Controls.SistemaFGO.pararJogo != "stop" && Controls.SistemaFGO.pararJogo != "0")
            {
                FGO_BSx.CharactersFate.Artoria artoria = new FGO_BSx.CharactersFate.Artoria();
                FGO_BSx.CharactersFate.Baobhan baobhan = new FGO_BSx.CharactersFate.Baobhan();
                FGO_BSx.CharactersFate.Mordred mordred = new FGO_BSx.CharactersFate.Mordred();
                FGO_BSx.CharactersFate.Tristan tristan = new FGO_BSx.CharactersFate.Tristan();
                FGO_BSx.CharactersFate.FirstHassan firstHassan = new FGO_BSx.CharactersFate.FirstHassan();
                FGO_BSx.CharactersFate.Okada okada = new FGO_BSx.CharactersFate.Okada();

                //  Apenas para exibicao ao console.
                string[] personagensNome = { artoria.name, 
                                         baobhan.name,
                                         okada.name, 
                                         mordred.name, 
                                         tristan.name, 
                                         firstHassan.name 
                                        };
                //  Lista de objetos necessaria para logica de atributos.
                object[] personagens = { artoria,
                                         baobhan,
                                         okada,
                                         mordred,
                                         tristan,
                                         firstHassan
                                        };

                string escolhaPersonagem = "";

                List<string> validChoices = new List<string>();

                for (int i = 1; i <= personagensNome.Length; i++)
                {
                    validChoices.Add(i.ToString());
                }

                validChoices.Add("0");
                validChoices.Add("stop");

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("===============");
                    Controls.SistemaFGO.WriteColored("Select a Servant", ConsoleColor.Green);
                    Console.WriteLine(":");
                    Console.WriteLine("===============\n");

                    for (int i = 0; i < personagens.Length; i++)
                    {
                        Controls.SistemaFGO.WriteColored(personagensNome[i], ConsoleColor.White);
                        Console.Write(" (");
                        Controls.SistemaFGO.WriteColored((i + 1).ToString(), ConsoleColor.Green);
                        Console.WriteLine(")");
                    }

                    Console.Write("\n\nLeave Game ( ");
                    Controls.SistemaFGO.WriteColored("0", ConsoleColor.Green);
                    Console.Write(" / ");
                    Controls.SistemaFGO.WriteColored("STOP", ConsoleColor.Green);
                    Console.WriteLine(")");

                    Console.Write("\nSelect: ");
                    escolhaPersonagem = Console.ReadLine().ToString().ToLower();
                    escolhaPersonagem = Controls.SistemaFGO.Capitalize(escolhaPersonagem);

                    if (validChoices.Contains(escolhaPersonagem))
                    {
                        Console.Clear();
                        break;
                    }

                    Console.Clear();
                }
                if (escolhaPersonagem == "0" || escolhaPersonagem == "stop")
                {
                    break;
                }
                else if (escolhaPersonagem == "1" || escolhaPersonagem == personagensNome[0]) 
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[0];
                }
                else if (escolhaPersonagem == "2" || escolhaPersonagem == personagensNome[1])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[1];
                }
                else if (escolhaPersonagem == "3" || escolhaPersonagem == personagensNome[2])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[2];
                }
                else if (escolhaPersonagem == "4" || escolhaPersonagem == personagensNome[3])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[3];
                }
                else if (escolhaPersonagem == "5" || escolhaPersonagem == personagensNome[4])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[4];
                }
                else if (escolhaPersonagem == "6" || escolhaPersonagem == personagensNome[5])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[5];
                }

                Console.WriteLine("\n\n");
                Controls.SistemaFGO.MyServant(Controls.SistemaFGO.personagemEscolhido);
                Console.WriteLine("\n\n===============");
                Controls.SistemaFGO.WriteColored("Skills", ConsoleColor.Green);
                Console.WriteLine(":");
                Console.WriteLine("===============\n");

                Console.Write("Basic Skill (");
                Controls.SistemaFGO.WriteColored("1", ConsoleColor.Green);
                Console.WriteLine(")");

                Console.Write("Ultimate Skill (");
                Controls.SistemaFGO.WriteColored("2", ConsoleColor.Green);
                Console.WriteLine(")");

                Console.Write("Desistir (");
                Controls.SistemaFGO.WriteColored("0", ConsoleColor.Green);
                Console.Write(" / ");
                Controls.SistemaFGO.WriteColored("STOP", ConsoleColor.Green);
                Console.WriteLine(")");

                while (Controls.SistemaFGO.escolhaSkill != "1" && Controls.SistemaFGO.escolhaSkill != "2" && Controls.SistemaFGO.escolhaSkill != "0" && Controls.SistemaFGO.escolhaSkill != "stop")
                {
                    Console.Write("\nSelect a Skill: ");
                    Controls.SistemaFGO.escolhaSkill = Console.ReadLine().ToLower();
                    Console.Clear();
                }

                if (Controls.SistemaFGO.escolhaSkill == "1")
                {
                    artoria.SwordSkill();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "2")
                {
                    artoria.Excalibur();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "0" || Controls.SistemaFGO.escolhaSkill == "stop")
                {
                    break;
                }
            }
        }
    }
}
