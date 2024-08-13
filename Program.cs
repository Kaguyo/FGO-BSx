using NAudio.Wave;
using System;
using System.Linq;

namespace FGO_BSx
{
    public class Program
    {
        private static IWavePlayer backgroundWaveOutDevice;
        private static WaveStream backgroundAudioFileReader;
        public static void Main()
        {



            while (Controls.SistemaFGO.pararJogo != "stop" && Controls.SistemaFGO.pararJogo != "0")
            {
                FGO_BSx.EnemiesFate.EnemyArtoria enemyArtoria = new FGO_BSx.EnemiesFate.EnemyArtoria();

                FGO_BSx.CharactersFate.Artoria artoria = new FGO_BSx.CharactersFate.Artoria();
                FGO_BSx.CharactersFate.Baobhan baobhan = new FGO_BSx.CharactersFate.Baobhan();
                FGO_BSx.CharactersFate.Mordred mordred = new FGO_BSx.CharactersFate.Mordred();
                FGO_BSx.CharactersFate.Tristan tristan = new FGO_BSx.CharactersFate.Tristan();
                FGO_BSx.CharactersFate.Jalter jalter = new FGO_BSx.CharactersFate.Jalter();
                FGO_BSx.CharactersFate.Okada okada = new FGO_BSx.CharactersFate.Okada();

                double[] ComHp = { enemyArtoria.hp };
                //  Apenas para exibicao ao console.
                string[] inimigosNome = { enemyArtoria.name };
                //  Lista de objetos necessaria para logica de atributos.
                object[] inimigos = { enemyArtoria };


                //  Apenas para exibicao ao console.t
                double[] userHp = { artoria.hp,
                                    baobhan.hp,
                                    okada.hp,
                                    mordred.hp,
                                    tristan.hp,
                                    jalter.hp
                                        };
                string[] personagensNome = { artoria.name,
                                         baobhan.name,
                                         okada.name,
                                         mordred.name,
                                         tristan.name,
                                         jalter.name
                                        };
                //  Lista de objetos necessaria para logica de atributos.
                object[] personagens = { artoria,
                                         baobhan,
                                         okada,
                                         mordred,
                                         tristan,
                                         jalter
                                        };

                string escolhaPersonagem;
                string escolhaInimigo;

                List<string> validChoices = new List<string>();
                List<string> validEnemyChoices = new List<string>();

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
                for (int i = 1; i <= personagensNome.Length; i++)
                {
                    validChoices.Add(i.ToString());
                }

                validEnemyChoices.Add("0");
                validEnemyChoices.Add("Stop");

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("===============");
                    Controls.SistemaFGO.WriteColored("Select an Enemy", ConsoleColor.DarkRed);
                    Console.WriteLine(":");
                    Console.WriteLine("===============\n");

                    for (int i = 0; i < inimigos.Length; i++)
                    {
                        Controls.SistemaFGO.WriteColored(inimigosNome[i], ConsoleColor.White);
                        Console.Write(" (");
                        Controls.SistemaFGO.WriteColored((i + 1).ToString(), ConsoleColor.DarkRed);
                        Console.WriteLine(")");
                    }

                    Console.Write("\n\nLeave Game ( ");
                    Controls.SistemaFGO.WriteColored("0", ConsoleColor.Green);
                    Console.Write(" / ");
                    Controls.SistemaFGO.WriteColored("STOP", ConsoleColor.Green);
                    Console.WriteLine(")");

                    Console.Write("\nSelect: ");
                    escolhaInimigo = Console.ReadLine().ToString().ToLower();
                    escolhaInimigo = Controls.SistemaFGO.Capitalize(escolhaInimigo);

                    if (validChoices.Contains(escolhaPersonagem))
                    {
                        Console.Clear();
                        break;
                    }

                    Console.Clear();
                }
                //         PERSONAGENS PERSONAGENS PERSONAGENS PERSONAGENS 
                // Declaração de variáveis fora dos blocos condicionais
                int indexPersonagem = -1;
                int indexInimigo = -1;

                // Seleção do personagem
                if (escolhaPersonagem == "0" || escolhaPersonagem == "Stop")
                {
                    break;
                }
                else if (escolhaPersonagem == "1" || escolhaPersonagem == personagensNome[0])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[0];
                    indexPersonagem = 0;
                }
                else if (escolhaPersonagem == "2" || escolhaPersonagem == personagensNome[1])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[1];
                    indexPersonagem = 1;
                }
                else if (escolhaPersonagem == "3" || escolhaPersonagem == personagensNome[2])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[2];
                    indexPersonagem = 2;
                }
                else if (escolhaPersonagem == "4" || escolhaPersonagem == personagensNome[3])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[3];
                    indexPersonagem = 3;
                }
                else if (escolhaPersonagem == "5" || escolhaPersonagem == personagensNome[4])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[4];
                    indexPersonagem = 4;
                }
                else if (escolhaPersonagem == "6" || escolhaPersonagem == personagensNome[5])
                {
                    Controls.SistemaFGO.personagemEscolhido = personagens[5];
                    indexPersonagem = 5;
                }

                // Seleção do inimigo
                if (escolhaInimigo == "0" || escolhaInimigo == "Stop")
                {
                    break;
                }
                else if (escolhaInimigo == "1" || escolhaInimigo == personagensNome[0])
                {
                    Controls.SistemaFGO.inimigoEscolhido = inimigos[0];
                    indexInimigo = 0;
                }
                else if (escolhaInimigo == "2" || escolhaInimigo == personagensNome[1])
                {
                    Controls.SistemaFGO.inimigoEscolhido = inimigos[1];
                    indexInimigo = 1;
                }

                // Enquanto o hp do personagem e inimigo forem maiores que 0 e a escolha de skill não for "stop"
                while (userHp[indexPersonagem] > 0 && (ComHp[indexInimigo] > 0
                       && !(Controls.SistemaFGO.escolhaSkill == "0" || Controls.SistemaFGO.escolhaSkill == "stop")))
                {
                    while (Controls.SistemaFGO.escolhaSkill != "1" && Controls.SistemaFGO.escolhaSkill != "2" &&
                        Controls.SistemaFGO.escolhaSkill != "3" && Controls.SistemaFGO.escolhaSkill != "4" &&
                        Controls.SistemaFGO.escolhaSkill != "5" && Controls.SistemaFGO.escolhaSkill != "6" &&
                        Controls.SistemaFGO.escolhaSkill != "7" && Controls.SistemaFGO.escolhaSkill != "8" &&
                        Controls.SistemaFGO.escolhaSkill != "9") 
                    {
                        Console.WriteLine("\n");
                        Controls.SistemaFGO.MyServant(Controls.SistemaFGO.personagemEscolhido);

                        Console.WriteLine("\n\n===============");
                        Controls.SistemaFGO.WriteColored("Skills", ConsoleColor.Green);
                        Console.WriteLine(":");
                        Console.WriteLine("===============\n");
                        Controls.SistemaFGO.SkillsCharacterX(Controls.SistemaFGO.personagemEscolhido);


                    
                    
                        Console.Write("\n\nSelect a Skill: ");
                        Controls.SistemaFGO.escolhaSkill = Console.ReadLine().ToLower();
                        Console.Clear();
                        if (Controls.SistemaFGO.escolhaSkill == "0" || Controls.SistemaFGO.escolhaSkill == "stop") { break; }
                    }
                    if (Controls.SistemaFGO.escolhaSkill == "0" || Controls.SistemaFGO.escolhaSkill == "stop") { break; }

                    Controls.SistemaFGO.UserAttack(Controls.SistemaFGO.personagemEscolhido);
                    Console.Clear();
                }
            }
        }
    }
}
