using FGO_BSx.CharactersFate;
using NAudio.Wave;
using System.Text.Json;

namespace FGO_BSx.Controls
{
    public class PlayerData
    {
        int ArtoriaLevel = Artoria.Level;
        int ArtoriaExp = Artoria.Exp;
        
        int MordredLevel = Mordred.Level;
        int MordredExp = Mordred.Exp;

        int BaobhanLevel = Baobhan.Level;
        int BaobhanExp = Baobhan.Exp;

        int JalterLevel = Jalter.Level;
        int JalterExp = Jalter.Exp;

    }
    public class SaveGame 
    {
        static string filePath = @"..\Save\save.json";
        internal static string[] SavedJourneys = [];
        internal static void CreateNewSave(GameJourneys data) 
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(data, options);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha ao tentar criar nova Jornada.");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        internal static object GetSaves() 
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Falha ao tentar encontrar Arquivo salvo.");
                    Console.ReadKey(true);
                    Console.Clear();
                    return null;
                }
                string jsonString = File.ReadAllText(filePath);
                GameJourneys data = JsonSerializer.Deserialize<GameJourneys>(jsonString);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler arquivo. ERR:{ex.Message}");
                return null;
            }
        }
    }
    public class GameJourneys
    {
        internal static void CreateNewJourney(string JourneyName) 
        {
            object[] Journeys = SaveGame.GetSaves();
            int journeysCount = Journeys.Count();
            int repeatedName = 1;
            while(true)
            {
                if (Journeys.Contains(JourneyName))
                {
                    while (true)
                    {
                        JourneyName += $"({repeatedName})";
                        if (Journeys.Contains(JourneyName)) repeatedName++;
                        else
                        {
                            Journeys.Append(JourneyName);
                            break;
                        }
                    }
                    break;
                }
                else 
                {
                    Journeys.Append(JourneyName);
                    break;
                }
            }
        }
    }
    public class SistemaFGO : GameJourneys
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
        public static void NewGame() 
        {
            while (true) 
            {
                Console.WriteLine("================");
                WriteColored(" New Game\n", ConsoleColor.Green);
                Console.WriteLine("================\n");

                Console.WriteLine("Enter a Name to your Journey:");
                string journey = Console.ReadLine();
                if (journey.Length > 16)
                {
                    Console.Clear();
                    Console.Write("ERROR: Characters limit exceded (16).");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                else if (journey.Length < 1)
                {
                    Console.Clear();
                    Console.Write("ERROR: Must enter atleast one character.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                else
                {
                    CreateNewJourney(journey);
                    break;
                }
            }
        }
        public static string FiltroEscolha(ConsoleKey escolhaPersonagem)
        {
            if (escolhaPersonagem == ConsoleKey.D1)
                return "1";
            else if (escolhaPersonagem == ConsoleKey.D2)
                return "2";
            else if (escolhaPersonagem == ConsoleKey.D3)
                return "3";
            else if (escolhaPersonagem == ConsoleKey.D4)
                return "4";
            else if (escolhaPersonagem == ConsoleKey.D5)
                return "5";
            else if (escolhaPersonagem == ConsoleKey.D6)
                return "6";
            else if (escolhaPersonagem == ConsoleKey.D7)
                return "7";
            else if (escolhaPersonagem == ConsoleKey.D8)
                return "8";
            else if (escolhaPersonagem == ConsoleKey.D9)
                return "9";
            else if (escolhaPersonagem == ConsoleKey.Escape)
                return "stop";
            else
                return "";
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
            if (inimigoEscolhido is EnemiesFate.EnemyArtoria enemyArtoria)
                return EnemiesFate.EnemyArtoria.SpInitial;
            else return 0;
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
                string audioFilePath = @"..\Track&Sounds\Effects\Selected.wav";

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
            string audioFilePath = @"..\Track&Sounds\Effects\Selected.wav";
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
            if (!SuccessToAttack) { audioFilePath = @"..\Track&Sounds\Effects\Fail.wav";PlaySound(audioFilePath, waveOutDevice); }

            if (escolhaSkill != ConsoleKey.Escape)
            escolhaSkill = ConsoleKey.D0;

            return danoTotalUser;
        }
        public static int DefesaUsuario(object Usuario)
        {
            if (Usuario is Artoria artoria)
            {
                return artoria.Def;
            }
            else if (Usuario is Jalter jalter) 
            {
                return jalter.Def;
            }
            else if (Usuario is Mordred mordred)
            {
                return mordred.Def;
            }
            else if (Usuario is Baobhan baobhan)
            {
                return baobhan.Def;
            }
            else
            {
                return 0;
            }
        }
        public static int DefesaInimigo(object Inimigo) 
        {
            if (Inimigo is EnemiesFate.EnemyArtoria enemyArtoria)
            {
                return enemyArtoria.Def;
            }
            else
            {
                return 0;
            }
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
            Console.Write($"{ansiColor}{text}\x1b[0m");
            Console.ResetColor();
        }
        public static void WriteColoredAnsi(int i, string ansiColor)
        {
            Console.Write($"{ansiColor}{i}\x1b[0m");
            Console.ResetColor();
        }
    }
}
