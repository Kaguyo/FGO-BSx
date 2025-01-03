using FGO_BSx.CharactersFate;
using NAudio.Wave;
using System.Text.Json;

namespace FGO_BSx.Controls
{
    public class PlayerData
    {
        public string JourneyName { get; set; }

        public int ArtoriaLevel { get; set; }
        public int ArtoriaExp { get; set; }
        public int MordredLevel { get; set; }                                                                                      
        public int MordredExp { get; set; }
        public int BaobhanLevel { get; set; }
        public int BaobhanExp { get; set; }
        public int JalterLevel { get; set; }
        public int JalterExp { get; set; }

        public PlayerData(string journeyName)
        {
            JourneyName = journeyName;

            ArtoriaLevel = Artoria.Level;
            ArtoriaExp = Artoria.Exp;

            MordredLevel = Mordred.Level;
            MordredExp = Mordred.Exp;

            BaobhanLevel = Baobhan.Level;
            BaobhanExp = Baobhan.Exp;

            JalterLevel = Jalter.Level;
            JalterExp = Jalter.Exp;
        }
    }

    public class SaveGame
    {
        internal static string[] SavedJourneys = Array.Empty<string>();

        internal static bool CreateSave(string filePath, string journeyName)
        {
            try
            {
                PlayerData save = new PlayerData(journeyName);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(save, options);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERR: {ex.Message}");
                Thread.Sleep(500);
                return false;
            }
            return true;
        }

        internal static bool NewSave(string journeyName, string operationType) 
        {
            try
            {
                string saveDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Save");
                string saveFilePath = Path.Combine(saveDirectory, $"{journeyName}.json");

                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }

                if (File.Exists(saveFilePath) && operationType == "newGame")
                {
                    Console.WriteLine("File name already exists.");
                    Console.WriteLine("Please rename it or exclude the previous file.");
                    Console.ReadKey(true);
                    Console.Clear();
                    return false;
                }

              
                bool checkOperation = CreateSave(saveFilePath, journeyName);
                if (checkOperation)
                {
                    Console.WriteLine("Journey created successfully.");
                    Console.ReadKey(true);
                    return true;
                }
                else
                {
                    throw new Exception("Journey couldn't be created.");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
    public class SistemaFGO : SaveGame
    {
        private static readonly Random random = new Random();
        private static WaveStream? audioFileReader;
        private static WaveOutEvent? backgroundWaveOutDevice;
        private static WaveStream? backgroundAudioFileReader;
        static internal ConsoleKey escolhaSkill { get; set; }
        static internal object? inimigoEscolhido;
        static internal object? personagemEscolhido;
        private static WaveOutEvent? waveOutDevice;

        internal static bool SuccessToAttack { get; set; }
        static string CaptureEscReadLine()
        {
            var entrada = string.Empty;

            while (true)
            {
                var tecla = Console.ReadKey(intercept: true); // Captura tecla sem exibir no console

                if (tecla.Key == ConsoleKey.Escape)
                {
                    return null; // Retorna null se ESC for pressionado
                }
                else if (tecla.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine(); // Move para a próxima linha
                    return entrada; // Retorna a entrada digitada
                }
                else if (tecla.Key == ConsoleKey.Backspace && entrada.Length > 0)
                {
                    entrada = entrada.Remove(entrada.Length - 1); // Remove o último caractere
                    Console.Write("\b \b"); // Remove o caractere do console
                }
                else
                {
                    entrada += tecla.KeyChar; // Adiciona a tecla à entrada
                    Console.Write(tecla.KeyChar); // Exibe a tecla no console
                }
            }
        }
        public static int rowUpdate(ConsoleKey teclaSelecionada, int row) 
        {

            if (teclaSelecionada == ConsoleKey.D1)
            {
                row = 1;
            }
            else if (teclaSelecionada == ConsoleKey.D2)
            {
                row = 2;
            }
            else if (teclaSelecionada == ConsoleKey.D3) 
            {
                row = 3;
            }
            else if (teclaSelecionada == ConsoleKey.W || teclaSelecionada == ConsoleKey.UpArrow)
            {
                if (row > 1) row--;
                else row = 3;
            }
            else if (teclaSelecionada == ConsoleKey.S || teclaSelecionada == ConsoleKey.DownArrow)
            {
                if (row < 3) row++;
                else row = 1;
            }

            return row;
        }
        public static string NewGame(string operationType) 
        {
            while (true) 
            {
                Console.WriteLine("================");
                WriteColored("New Game\n", ConsoleColor.Green);
                Console.WriteLine("================\n");

                Console.Write("Enter a Name to your Journey: ");
                string journeyName = CaptureEscReadLine();
                if (journeyName == null) 
                {
                    Console.Clear();
                    return null; // Finaliza operacao cancelando metodo NewGame
                }
                else if (journeyName.Length > 16)
                {
                    Console.Clear();
                    Console.Write("ERROR: Characters limit exceded (16).");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                else if (journeyName.Length < 1)
                {
                    Console.Clear();
                    Console.Write("ERROR: Must enter atleast one character.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    bool checkOperation = NewSave(journeyName, operationType);
                    if (checkOperation) return "Seccess"; // Se todas operacoes funcionarem, fim da funcao, contrario: Loop while.
                    else 
                    {
                        Console.Write("Press any ");
                        WriteColored("Key", ConsoleColor.Green);
                        Console.Write("to continue");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                }
            }
        }
        public static string FiltroEscolha(ConsoleKey escolhaPersonagem)
        {
            string numeralChoice = "";
            if (escolhaPersonagem == ConsoleKey.D1)
                numeralChoice = "1";
            else if (escolhaPersonagem == ConsoleKey.D2)
                numeralChoice = "2";
            else if (escolhaPersonagem == ConsoleKey.D3)
                numeralChoice = "3";
            else if (escolhaPersonagem == ConsoleKey.D4)
                numeralChoice = "4";
            else if (escolhaPersonagem == ConsoleKey.D5)
                numeralChoice = "5";
            else if (escolhaPersonagem == ConsoleKey.D6)
                numeralChoice = "6";
            else if (escolhaPersonagem == ConsoleKey.D7)
                numeralChoice = "7";
            else if (escolhaPersonagem == ConsoleKey.D8)
                numeralChoice = "8";
            else if (escolhaPersonagem == ConsoleKey.D9)
                numeralChoice = "9";
            else if (escolhaPersonagem == ConsoleKey.Escape)
                numeralChoice = "stop";
            
            return numeralChoice;
        }
        public static string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static void DisplayHP(int hp, double hpMax)
        {
            double fraction = hp / hpMax;
            if (fraction <= 0.2)
            {
                if (hp < 0)
                    hp = 0;
                WriteColored(hp, ConsoleColor.Red);
            }
            else if (fraction < 0.6)
            {
                WriteColored(hp, ConsoleColor.Yellow);
            }
            else
            {
                WriteColored(hp, ConsoleColor.Green);
            }
            Console.Write("/");
            WriteColored(hpMax, ConsoleColor.Green);
        }
        public static void DisplayEnemyInfo(object inimigoEscolhido, int vidaInimigo, double sp, double spCost) 
        {
            if (inimigoEscolhido is EnemiesFate.EnemyArtoria enemyArtoria) 
            {
                Console.Write("(");
                WriteColored("Enemy", ConsoleColor.Red);
                Console.Write(")");
                WriteColored("Artoria", ConsoleColor.Yellow);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaInimigo, enemyArtoria.Hp);
                Console.Write("\n                                            "); // pula a quantidade de posições necessarias para melhor leitura visual no terminal
                WriteColored("NP Energy", ConsoleColor.Yellow);
                Console.Write(": ");
                if (sp >= spCost)
                {
                    sp = spCost;
                    sp /= spCost;
                    sp *= 100;
                    WriteColored((int)sp, ConsoleColor.Green);
                    WriteColored("/", ConsoleColor.White);
                    WriteColored("100", ConsoleColor.Green);
                }
                else 
                {
                    sp /= spCost;
                    sp *= 100;
                    WriteColored((int)sp, ConsoleColor.Red);
                    WriteColored("/", ConsoleColor.White);
                    WriteColored("100", ConsoleColor.Green);
                }
            }
        }
        public static double ReturnSpInimigo(object inimigoEscolhido) 
        {
            double enemySpInitial = 0;
            if (inimigoEscolhido is EnemiesFate.EnemyArtoria)
            {
                enemySpInitial = EnemiesFate.EnemyArtoria.SpInitial;
            }
            return enemySpInitial;
        }
        public static void MyServantAndEnemy(object personagemEscolhido, int vidaUsuario, object inimigoEscolhido, int vidaInimigo, double spEnemy, double spCostEnemy)
        {
            if (personagemEscolhido is Artoria artoria)
            {
                WriteColored("Artoria", ConsoleColor.Yellow);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, artoria.Hp);
                Console.Write("  |  ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
            else if (personagemEscolhido is Baobhan baobhan)
            {
                WriteColored("Baobhan", ConsoleColor.Red);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, baobhan.Hp);
                Console.Write("  |  ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
            else if (personagemEscolhido is Jalter jalter)
            {
                WriteColored("Jeanne D'arc (Alter)", ConsoleColor.DarkYellow);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, jalter.Hp);
                Console.Write("  |  ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
            else if (personagemEscolhido is Mordred mordred)
            {
                WriteColored("Mordred", ConsoleColor.Yellow);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, mordred.Hp);
                Console.Write("  |  ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
        }

        public static void SkillsCharacterX(object Personagem)
        {
            if (Personagem is Artoria artoria)
            {
                Artoria.SkillsArtoria(artoria.SpInitial, artoria.SpCost);
            }
            else if (Personagem is Baobhan baobhan)
            {
                Baobhan.SkillsBaobhan(baobhan.SpInitial, baobhan.SpCost);
            }
            else if (Personagem is Jalter jalter)
            {
                Jalter.SkillsJalter(jalter.SpInitial, jalter.SpCost);
            }
            else if (Personagem is Mordred mordred)
            {
                Mordred.SkillsMordred(mordred.SpInitial, mordred.SpCost);
            }
        }

        internal static void PlaySound(string audioFilePath)
        {
           PlaySound(audioFilePath, waveOutDevice);
        }

        internal static void PlaySound(string audioFilePath, WaveOutEvent waveOutDevice)
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
        public static int EnemyAttack(object inimigo, int defesaUsuario, int danoTotalEnemy) 
        {
            if (inimigo is EnemiesFate.EnemyArtoria enemyArtoria) 
            {
                string audioFilePath = @"..\..\..\Track&Sounds\Effects\Selected.wav";
    
                while (true)
                {
                    int choice = random.Next(1, 4);
                    if (choice == 1)
                    {
                        danoTotalEnemy = enemyArtoria.SwordSkill(defesaUsuario, danoTotalEnemy);
                        break;
                    }
                    else if (choice == 2)
                    {
                        danoTotalEnemy = enemyArtoria.ManaLoading(defesaUsuario, danoTotalEnemy);
                        break;
                    }
                    else if (choice == 3 && EnemiesFate.EnemyArtoria.SpInitial >= EnemiesFate.EnemyArtoria.SpCost)
                    {
                        danoTotalEnemy = enemyArtoria.Excalibur(defesaUsuario, danoTotalEnemy);
                        break;
                    }
                }
            }
            return danoTotalEnemy;
        }
        public static int UserAttack(object personagem, int defesaInimigo, int danoTotalUser)
        {
            string audioFilePath = @"..\..\..\Track&Sounds\Effects\Selected.wav";
            if (personagem is Artoria artoria)
            {
                if (escolhaSkill == ConsoleKey.D1)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = artoria.SwordSkill(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (escolhaSkill == ConsoleKey.D2)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = artoria.ManaLoading(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (escolhaSkill == ConsoleKey.D3 && artoria.SpInitial >= artoria.SpCost)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = artoria.Excalibur(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
            }
            else if (personagem is Baobhan baobhan)
            {
               
    
                if (escolhaSkill == ConsoleKey.D1)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = baobhan.RangeAttack(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (escolhaSkill == ConsoleKey.D2)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = baobhan.FinesseImprovement(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (escolhaSkill == ConsoleKey.D3 && baobhan.SpInitial >= baobhan.SpCost)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = baobhan.FetchFailnaught(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
            }
            else if (personagem is Jalter jalter)
            {
                if (escolhaSkill == ConsoleKey.D1)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = jalter.SwordSkill(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (escolhaSkill == ConsoleKey.D2)
                {
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = jalter.SelfModificationCritUp(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (escolhaSkill == ConsoleKey.D3)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = jalter.OblivionCorrectionCritUp(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (escolhaSkill == ConsoleKey.D4 && jalter.SpInitial >= jalter.SpCost)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = jalter.LeGrondementdelaHaine(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
            }
            else if (personagem is Mordred mordred)
            {
                if (escolhaSkill == ConsoleKey.D1)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = mordred.SwordSkill(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (escolhaSkill == ConsoleKey.D2)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = mordred.ManaLoading(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (escolhaSkill == ConsoleKey.D3)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = mordred.KnightofCrimsonThunder(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (escolhaSkill == ConsoleKey.D4 && mordred.SpInitial >= mordred.SpCost)
                {
                    Console.Clear();
                    PlaySound(audioFilePath, waveOutDevice);
                    danoTotalUser = mordred.ClarentBloodArthur(defesaInimigo, danoTotalUser);
                    SuccessToAttack = true;
                    Console.Clear();
                }
            }
            if (!SuccessToAttack) 
            {
                audioFilePath = @"..\..\..\Track&Sounds\Effects\Selected.wav";
                PlaySound(audioFilePath, waveOutDevice); 
            }

            if (escolhaSkill != ConsoleKey.Escape)
            escolhaSkill = ConsoleKey.D0;

            return danoTotalUser;
        }
        public static void EnemysTurnTransition(bool keyboardEntry)
        {
            int ycount = 0;
            string allowInputAfterOutput = "";
            string expectedOutput = "Turno do Oponente...Turno do Oponente...Turno do Oponente.";
            while (keyboardEntry || allowInputAfterOutput != expectedOutput)
            {
                for (int i = 0; i < 7; i++)
                {

                    if (i == 0)
                    {
                        Console.Write("Turno do Oponente.");
                        allowInputAfterOutput = "Turno do Oponente.";
                    }
                    else if (ycount != 3)
                    {
                        Console.Write(".");
                        Thread.Sleep(300);
                        allowInputAfterOutput += ".";
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Turno do Oponente.");
                        allowInputAfterOutput += "Turno do Oponente.";
                        ycount = 0;
                    }
                    ycount++;
                }
                ycount = 0;
            }
        }
        public static int DefesaUsuario(object Usuario)
        {
            int Defesa = 0;
            if (Usuario is Artoria artoria)
            {
                Defesa = artoria.Def;
            }
            else if (Usuario is Jalter jalter) 
            {
                Defesa = jalter.Def;
            }
            else if (Usuario is Mordred mordred)
            {
                Defesa = mordred.Def;
            }
            else if (Usuario is Baobhan baobhan)
            {
                Defesa = baobhan.Def;
            }
            
            return Defesa;
        }
        public static int DefesaInimigo(object Inimigo) 
        {
            int enemyDef = 0;
            if (Inimigo is EnemiesFate.EnemyArtoria enemyArtoria)
            {
                enemyDef = enemyArtoria.Def;
            }
            
            return enemyDef;
        }
        public static void WriteColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void WriteColored(double text, ConsoleColor color)
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
        public static void WriteColored2(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        public static void WriteColoredAnsi(string text, string ansiColor)
        {
            Console.Write($"{ ansiColor}{text}\x1b[0m");
            Console.ResetColor();
        }
        public static void WriteColoredAnsi(int i, string ansiColor)
        {
            Console.Write($"{ansiColor}{i}\x1b[0m");
            Console.ResetColor();
        }
    }
}
