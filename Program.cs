﻿namespace FGO_BSx
{
    public class Program
    {
        public static void Main()
        {


            while (true)
            {
                string escolhaPersonagem;
                string escolhaInimigo;
                int defInimigo = 0;
                FGO_BSx.EnemiesFate.EnemyArtoria enemyArtoria = new FGO_BSx.EnemiesFate.EnemyArtoria();

                FGO_BSx.CharactersFate.Artoria artoria = new FGO_BSx.CharactersFate.Artoria();
                FGO_BSx.CharactersFate.Baobhan baobhan = new FGO_BSx.CharactersFate.Baobhan();
                FGO_BSx.CharactersFate.Mordred mordred = new FGO_BSx.CharactersFate.Mordred();
                FGO_BSx.CharactersFate.Tristan tristan = new FGO_BSx.CharactersFate.Tristan();
                FGO_BSx.CharactersFate.Jalter jalter = new FGO_BSx.CharactersFate.Jalter();
                FGO_BSx.CharactersFate.Okada okada = new FGO_BSx.CharactersFate.Okada();

                //  Lista de propriedades necessaria para lógica de combate

                //  Propriedades dos inimigos

                int[] inimigoHp = [enemyArtoria.Hp];

                double[] inimigoSp = [enemyArtoria.SpInitial];

                double[] inimigoSpCost = [enemyArtoria.SpCost];

                int[] inimigoSpeed = [enemyArtoria.SPD];
                                   
                string[] inimigoNome = [enemyArtoria.Name];

                object[] inimigo = [enemyArtoria];


                //  Propriedades personagens do usuario

                int[] personagensHp = [artoria.Hp,
                                    baobhan.Hp,
                                    okada.Hp,
                                    mordred.Hp,
                                    tristan.Hp,
                                    jalter.Hp
                                  ];
                int[] personagensSpeed = [ artoria.SPD,
                                    baobhan.SPD,
                                    okada.SPD,
                                    mordred.SPD,
                                    tristan.SPD,
                                    jalter.SPD
                                  ];
                string[] personagensNome = [ artoria.Name,
                                             baobhan.Name,
                                             okada.Name,
                                             mordred.Name,
                                             tristan.Name,
                                             jalter.Name
                                           ];
                object[] personagens = [ artoria,
                                         baobhan,
                                         okada,
                                         mordred,
                                         tristan,
                                         jalter
                                       ];

                

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
                }
                if (escolhaPersonagem == "0" || escolhaPersonagem == "Stop")
                {
                    break;
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("===============");
                    Controls.SistemaFGO.WriteColored("Select an Enemy", ConsoleColor.DarkRed);
                    Console.WriteLine(":");
                    Console.WriteLine("===============\n");

                    for (int i = 0; i < inimigo.Length; i++)
                    {
                        Controls.SistemaFGO.WriteColored(inimigoNome[i], ConsoleColor.White);
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

                    if (validEnemyChoices.Contains(escolhaInimigo))
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
                else if (escolhaInimigo == "1" || escolhaInimigo == inimigoNome[0])
                {
                    Controls.SistemaFGO.inimigoEscolhido = inimigo[0];
                    indexInimigo = 0;
                    defInimigo = Controls.SistemaFGO.DefesaInimigo(inimigo[0]);
                }
                else if (escolhaInimigo == "2" || escolhaInimigo == inimigoNome[1])
                {
                    Controls.SistemaFGO.inimigoEscolhido = inimigo[1];
                    indexInimigo = 1;
                    defInimigo = Controls.SistemaFGO.DefesaInimigo(inimigo[1]);
                }
                int danoTotal = 0;
                double spInimigo, spCostInimigo;

                // Enquanto o Hp do personagem e inimigo forem maiores que 0 e a escolha de skill não for "stop"
                while (personagensHp[indexPersonagem] > 0 && inimigoHp[indexInimigo] > 0 && !(Controls.SistemaFGO.escolhaSkill == "0" || Controls.SistemaFGO.escolhaSkill == "stop"))
                {   
                    while ((Controls.SistemaFGO.escolhaSkill != "1" && Controls.SistemaFGO.escolhaSkill != "2" &&
                    Controls.SistemaFGO.escolhaSkill != "3" && Controls.SistemaFGO.escolhaSkill != "4" &&
                    Controls.SistemaFGO.escolhaSkill != "5" && Controls.SistemaFGO.escolhaSkill != "6" &&
                    Controls.SistemaFGO.escolhaSkill != "7" && Controls.SistemaFGO.escolhaSkill != "8" &&
                    Controls.SistemaFGO.escolhaSkill != "9") || (! Controls.SistemaFGO.SuccessToAttack )) 
                    {
                        danoTotal = 0;
                        Controls.SistemaFGO.SuccessToAttack = false;
                        spInimigo = inimigoSp[indexInimigo];
                        spCostInimigo = inimigoSpCost[indexInimigo];

                        if (personagensSpeed[indexPersonagem] >= inimigoSpeed[indexInimigo])
                        {
                            Console.WriteLine("\n");
                            Controls.SistemaFGO.MyServantAndEnemy(Controls.SistemaFGO.personagemEscolhido, personagensHp[indexPersonagem], Controls.SistemaFGO.inimigoEscolhido, inimigoHp[indexInimigo], spInimigo, spCostInimigo);
                            Console.WriteLine("\n===============");
                            Controls.SistemaFGO.WriteColored("Skills", ConsoleColor.Green);
                            Console.WriteLine(":");
                            Console.WriteLine("===============\n");
                            Controls.SistemaFGO.SkillsCharacterX(Controls.SistemaFGO.personagemEscolhido);

                            Console.Write("\n\nSelect a Skill: ");
                            Controls.SistemaFGO.escolhaSkill = Console.ReadLine().ToLower();
                            Console.Clear();
                            danoTotal = Controls.SistemaFGO.UserAttack(Controls.SistemaFGO.personagemEscolhido, defInimigo, danoTotal);
                        }
                        if (Controls.SistemaFGO.escolhaSkill == "0" || Controls.SistemaFGO.escolhaSkill == "stop") { break; }
                    }
                    if (Controls.SistemaFGO.escolhaSkill == "0" || Controls.SistemaFGO.escolhaSkill == "stop") { break; }
                    inimigoHp[indexInimigo] -= danoTotal;
                    Console.Clear();
                }
            }
        }
    }
}