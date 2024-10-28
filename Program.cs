namespace FGO_BSx
{
    public class Program
    {
        public static void Main()
        {
           
            while (true)
            {
                string faseDeJogo = "";
                ConsoleKey escolhaPersonagem;
                string personagemFiltrado;
                ConsoleKey escolhaInimigo;
                string inimigoFiltrado = "";
                int defInimigo = 0;
                int defUsuario = 0;
                FGO_BSx.EnemiesFate.EnemyArtoria enemyArtoria = new FGO_BSx.EnemiesFate.EnemyArtoria();

                FGO_BSx.CharactersFate.Artoria artoria = new FGO_BSx.CharactersFate.Artoria();
                FGO_BSx.CharactersFate.Baobhan baobhan = new FGO_BSx.CharactersFate.Baobhan();
                FGO_BSx.CharactersFate.Mordred mordred = new FGO_BSx.CharactersFate.Mordred();
                FGO_BSx.CharactersFate.Jalter jalter = new FGO_BSx.CharactersFate.Jalter();

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
                                    mordred.Hp,
                                    jalter.Hp
                                  ];
                int[] personagensSpeed = [ artoria.SPD,
                                    baobhan.SPD,
                                    mordred.SPD,
                                    jalter.SPD
                                  ];
                string[] personagensNome = [ artoria.Name,
                                             baobhan.Name,
                                             mordred.Name,
                                             jalter.Name
                                           ];
                object[] personagens = [ artoria,
                                         baobhan,
                                         mordred,
                                         jalter
                                       ];

                List<string> validChoices = new List<string>();
                List<string> validEnemyChoices = new List<string>();

                for (int i = 1; i <= inimigoNome.Length; i++)
                {
                    validEnemyChoices.Add(i.ToString());
                }
                for (int i = 1; i <= personagensNome.Length; i++)
                {
                    validChoices.Add(i.ToString());
                }
                validEnemyChoices.Add("stop");
                validChoices.Add("stop");

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("================");
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

                    Console.Write("\n\nLeave Game (");
                    Controls.SistemaFGO.WriteColored("Esc", ConsoleColor.Green);
                    Console.WriteLine(")");

                    Console.Write("\nSelect: ");
                    escolhaPersonagem = Console.ReadKey(true).Key;
                    personagemFiltrado = Controls.SistemaFGO.FiltroEscolha(escolhaPersonagem);

                    if (personagemFiltrado == "stop")
                    {
                        faseDeJogo = "end";
                        Console.Clear();
                        break;
                    }
                    else if (validChoices.Contains(personagemFiltrado))     // GameLine goes on
                    {
                        string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Effects\Selected.wav";
                        Controls.SistemaFGO.PlaySound(audioFilePath);
                        Console.Clear();
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

                            Console.Write("\n\nBack (");
                            Controls.SistemaFGO.WriteColored("Esc", ConsoleColor.Green);
                            Console.WriteLine(")");

                            Console.Write("\nSelect: ");
                            escolhaInimigo = Console.ReadKey(true).Key;
                            inimigoFiltrado = Controls.SistemaFGO.FiltroEscolha(escolhaInimigo);
                            if (inimigoFiltrado == "stop")
                            {
                                audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Effects\Selected.wav";
                                Controls.SistemaFGO.PlaySound(audioFilePath);
                                Console.Clear();
                                break;
                            }
                            else if (validEnemyChoices.Contains(inimigoFiltrado))
                            {
                                audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Effects\Selected.wav";
                                Controls.SistemaFGO.PlaySound(audioFilePath);
                                faseDeJogo = "combat";
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Effects\Fail.wav";
                                Controls.SistemaFGO.PlaySound(audioFilePath);
                            }
                        }
                        if (faseDeJogo == "combat")
                            break;
                    }
                    else 
                    {
                        string audioFilePath = @"C:\Users\Kaguyo\source\repos\FGO-BSx\Track&Sounds\Effects\Fail.wav";
                        Controls.SistemaFGO.PlaySound(audioFilePath);
                    }
                }
                if (faseDeJogo == "combat") 
                {
                    // GameLine goes on
                    
                    //         PERSONAGENS PERSONAGENS PERSONAGENS PERSONAGENS 
                    // Declaração de variáveis fora dos blocos condicionais
                    int indexPersonagem = -1;
                    int indexInimigo = -1;

                    // Seleção do personagem
                    if (personagemFiltrado == "stop")
                    {
                        break;
                    }
                    else if (personagemFiltrado == "1" || personagemFiltrado == personagensNome[0])
                    {
                        Controls.SistemaFGO.personagemEscolhido = personagens[0];
                        indexPersonagem = 0;
                        defUsuario = Controls.SistemaFGO.DefesaUsuario(personagens[0]);
                    }
                    else if (personagemFiltrado == "2" || personagemFiltrado == personagensNome[1])
                    {
                        Controls.SistemaFGO.personagemEscolhido = personagens[1];
                        indexPersonagem = 1;
                        defUsuario = Controls.SistemaFGO.DefesaUsuario(personagens[0]);
                    }
                    else if (personagemFiltrado == "3" || personagemFiltrado == personagensNome[2])
                    {
                        Controls.SistemaFGO.personagemEscolhido = personagens[2];
                        indexPersonagem = 2;
                        defUsuario = Controls.SistemaFGO.DefesaUsuario(personagens[0]);
                    }
                    else if (personagemFiltrado == "4" || personagemFiltrado == personagensNome[3])
                    {
                        Controls.SistemaFGO.personagemEscolhido = personagens[3];
                        indexPersonagem = 3;
                        defUsuario = Controls.SistemaFGO.DefesaUsuario(personagens[0]);
                    }
                    else if (personagemFiltrado == "5" || personagemFiltrado == personagensNome[4])
                    {
                        Controls.SistemaFGO.personagemEscolhido = personagens[4];
                        indexPersonagem = 4;
                        defUsuario = Controls.SistemaFGO.DefesaUsuario(personagens[0]);
                    }
                    else if (personagemFiltrado == "6" || personagemFiltrado == personagensNome[5])
                    {
                        Controls.SistemaFGO.personagemEscolhido = personagens[5];
                        indexPersonagem = 5;
                        defUsuario = Controls.SistemaFGO.DefesaUsuario(personagens[0]);
                    }

                    // Seleção do inimigo
                    if (inimigoFiltrado == "stop")
                    {
                        break;
                    }
                    else if (inimigoFiltrado == "1" || inimigoFiltrado == inimigoNome[0])
                    {
                        Controls.SistemaFGO.inimigoEscolhido = inimigo[0];
                        indexInimigo = 0;
                        defInimigo = Controls.SistemaFGO.DefesaInimigo(inimigo[0]);
                    }
                    else if (inimigoFiltrado == "2" || inimigoFiltrado == inimigoNome[1])
                    {
                        Controls.SistemaFGO.inimigoEscolhido = inimigo[1];
                        indexInimigo = 1;
                        defInimigo = Controls.SistemaFGO.DefesaInimigo(inimigo[1]);
                    }
                    int danoTotalUser = 0;
                    int danoTotalEnemy = 0;
                    double spInimigo, spCostInimigo;
                    int userHealth = personagensHp[indexPersonagem];
                    int enemyHealth = inimigoHp[indexInimigo];
                    bool keyboardEntry = false;
                    // Enquanto o Hp do personagem e inimigo forem maiores que 0 e a escolha de skill não for "stop"
                    while (userHealth > 0 && enemyHealth > 0)
                    {
                        danoTotalUser = 0;
                        danoTotalEnemy = 0;
                        spInimigo = inimigoSp[indexInimigo];
                        spCostInimigo = inimigoSpCost[indexInimigo];

                        if (personagensSpeed[indexPersonagem] >= inimigoSpeed[indexInimigo])
                        {
                            while ((Controls.SistemaFGO.escolhaSkill != ConsoleKey.D1 && Controls.SistemaFGO.escolhaSkill != ConsoleKey.D2 &&
                            Controls.SistemaFGO.escolhaSkill != ConsoleKey.D3 && Controls.SistemaFGO.escolhaSkill != ConsoleKey.D4 &&
                            Controls.SistemaFGO.escolhaSkill != ConsoleKey.D5 && Controls.SistemaFGO.escolhaSkill != ConsoleKey.D6 &&
                            Controls.SistemaFGO.escolhaSkill != ConsoleKey.D7 && Controls.SistemaFGO.escolhaSkill != ConsoleKey.D8 &&
                            Controls.SistemaFGO.escolhaSkill != ConsoleKey.D9) || (!Controls.SistemaFGO.SuccessToAttack))
                            {
                                keyboardEntry = false;  // Block input initially
                                while (!keyboardEntry)
                                {
                                    Console.WriteLine("\n");
                                    Controls.SistemaFGO.MyServantAndEnemy(Controls.SistemaFGO.personagemEscolhido, userHealth, Controls.SistemaFGO.inimigoEscolhido, enemyHealth, spInimigo, spCostInimigo);
                                    Console.WriteLine("\n===============");
                                    Controls.SistemaFGO.WriteColored("Skills", ConsoleColor.Green);
                                    Console.WriteLine(":");
                                    Console.WriteLine("===============\n");
                                    Controls.SistemaFGO.SkillsCharacterX(Controls.SistemaFGO.personagemEscolhido);

                                    Console.Write("\n\nSelect a Skill: ");
                                    keyboardEntry = true;  // Allow input once output is done
                                }

                                // Check for keyboard input only when `keyboardEntry` is true
                                if (keyboardEntry)
                                {
                                    Controls.SistemaFGO.escolhaSkill = Console.ReadKey(true).Key;
                                    Console.Clear();
                                }
                                Controls.SistemaFGO.SuccessToAttack = false;
                                danoTotalUser = Controls.SistemaFGO.UserAttack(Controls.SistemaFGO.personagemEscolhido, defInimigo, danoTotalUser);
                                if (Controls.SistemaFGO.SuccessToAttack)
                                {
                                    enemyHealth -= danoTotalUser;
                                    break;
                                }
                            }

                            Console.Clear();
                            int xcount = 0;
                            int ycount = 1;
                            while (keyboardEntry)
                            {
                                for (int i = 0; i < 1000; i++)
                                {
                                    xcount++;
                                    if (i == 0)
                                        Console.Write("Turno do Oponente.");

                                    if (xcount - 150 == 0)
                                    {
                                        ycount++;
                                        if (ycount != 4)
                                        {
                                            Console.Write(".");
                                            Thread.Sleep(300);
                                        }
                                        xcount = 0;
                                    }
                                    if (ycount == 4)
                                    {
                                        Console.Clear();
                                        Console.Write("Turno do Oponente");
                                        ycount = 1;
                                    }
                                }
                                keyboardEntry = false;  // Block further input during enemy turn
                            }
                            danoTotalEnemy = Controls.SistemaFGO.EnemyAttack(Controls.SistemaFGO.inimigoEscolhido, defUsuario, danoTotalEnemy);
                            Console.Clear();
                            userHealth -= danoTotalEnemy;
                        }
                        else
                        {
                            Console.Clear();
                            int xcount = 0;
                            int ycount = 1;
                            while (keyboardEntry)
                            {
                                for (int i = 0; i < 1000; i++)
                                {
                                    xcount++;

                                    if (i == 0)
                                        Console.Write("Turno do Oponente.");
                                    if (xcount - 150 == 0)
                                    {
                                        ycount++;
                                        if (ycount != 4)
                                        {
                                            Console.Write(".");
                                            Thread.Sleep(300);
                                        }
                                        xcount = 0;
                                    }
                                    if (ycount == 4)
                                    {
                                        Console.Clear();
                                        Console.Write("Turno do Oponente");
                                        ycount = 1;
                                    }
                                }
                                keyboardEntry = false;
                            }
                            danoTotalEnemy = Controls.SistemaFGO.EnemyAttack(Controls.SistemaFGO.inimigoEscolhido, defUsuario, danoTotalEnemy);
                            Thread.Sleep(1000);
                            Console.Clear();
                            userHealth -= danoTotalEnemy;
                            while ((Controls.SistemaFGO.escolhaSkill != ConsoleKey.D1 && Controls.SistemaFGO.escolhaSkill != ConsoleKey.D2 &&
                            Controls.SistemaFGO.escolhaSkill != ConsoleKey.D3 && Controls.SistemaFGO.escolhaSkill != ConsoleKey.D4 &&
                            Controls.SistemaFGO.escolhaSkill != ConsoleKey.D5 && Controls.SistemaFGO.escolhaSkill != ConsoleKey.D6 &&
                            Controls.SistemaFGO.escolhaSkill != ConsoleKey.D7 && Controls.SistemaFGO.escolhaSkill != ConsoleKey.D8 &&
                            Controls.SistemaFGO.escolhaSkill != ConsoleKey.D9) || (!Controls.SistemaFGO.SuccessToAttack))
                            {
                                keyboardEntry = false;
                                Console.WriteLine("\n");
                                while (!keyboardEntry)
                                {
                                    Console.WriteLine("\n");
                                    Controls.SistemaFGO.MyServantAndEnemy(Controls.SistemaFGO.personagemEscolhido, userHealth, Controls.SistemaFGO.inimigoEscolhido, enemyHealth, spInimigo, spCostInimigo);
                                    Console.WriteLine("\n===============");
                                    Controls.SistemaFGO.WriteColored("Skills", ConsoleColor.Green);
                                    Console.WriteLine(":");
                                    Console.WriteLine("===============\n");
                                    Controls.SistemaFGO.SkillsCharacterX(Controls.SistemaFGO.personagemEscolhido);

                                    Console.Write("\n\nSelect a Skill: ");
                                    keyboardEntry = true;
                                }
                                if (keyboardEntry)
                                {
                                    Controls.SistemaFGO.escolhaSkill = Console.ReadKey(true).Key;
                                    Console.Clear();
                                }
                                Controls.SistemaFGO.SuccessToAttack = false;
                                danoTotalUser = Controls.SistemaFGO.UserAttack(Controls.SistemaFGO.personagemEscolhido, defInimigo, danoTotalUser);
                                if (Controls.SistemaFGO.SuccessToAttack)
                                {
                                    enemyHealth -= danoTotalUser;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}