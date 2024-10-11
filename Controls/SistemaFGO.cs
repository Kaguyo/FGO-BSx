using FGO_BSx.CharactersFate;
using NAudio.Wave;
using System;

namespace FGO_BSx.Controls
{
    public class SistemaFGO
    {
        private static WaveStream? audioFileReader;
        private static WaveOutEvent? backgroundWaveOutDevice;
        private static WaveStream? backgroundAudioFileReader;
        static internal string escolhaSkill = "";
        static internal object? inimigoEscolhido;
        static internal object? personagemEscolhido;
        private static WaveOutEvent? waveOutDevice;

        public static string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static void DisplayHP(int hp, int hpMax)
        {
            if (hp / hpMax <= 0.2)
            {
                WriteColoredAnsi(hp, "\x1b[38;5;124m");
            }
            else if (hp / hpMax < 0.6)
            {
                WriteColoredAnsi(hp, "\x1b[38;5;226m");
            }
            else
            {
                WriteColoredAnsi(hp, "\x1b[38;5;46m");
            }
            Console.Write("/");
            WriteColoredAnsi(hpMax, "\x1b[38;5;46m");
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
        public static void MyServantAndEnemy(object personagemEscolhido, int vidaUsuario, object inimigoEscolhido, int vidaInimigo, double spEnemy, double spCostEnemy)
        {
            if (personagemEscolhido is Artoria artoria)
            {
                WriteColored("Artoria", ConsoleColor.Yellow);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, artoria.Hp);
                Console.Write("      |      ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
            else if (personagemEscolhido is Baobhan baobhan)
            {
                WriteColored("Baobhan", ConsoleColor.Red);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, baobhan.Hp);
                Console.Write("      |      ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
            else if (personagemEscolhido is Jalter jalter)
            {
                WriteColored("Jeanne D'arc (Alter)", ConsoleColor.DarkYellow);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, jalter.Hp);
                Console.Write("  |      ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
            else if (personagemEscolhido is Mordred mordred)
            {
                WriteColored("Mordred", ConsoleColor.Yellow);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, mordred.Hp);
                Console.Write("      |      ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
            else if (personagemEscolhido is Tristan tristan)
            {
                WriteColored("Tristan", ConsoleColor.DarkRed);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, tristan.Hp);
                Console.Write("      |      ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
            else if (personagemEscolhido is Okada okada)
            {
                WriteColored("Okada", ConsoleColor.DarkGray);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, okada.Hp);
                Console.Write("      |      ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
        }

        public static void PlayBackgroundSound(string backgroundAudioFilePath)
        {
            StopBackgroundSound();
            try
            {
                backgroundWaveOutDevice = new WaveOutEvent();
                backgroundAudioFileReader = new AudioFileReader(backgroundAudioFilePath);
                backgroundWaveOutDevice.Init(backgroundAudioFileReader);
                backgroundWaveOutDevice.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing background sound: " + ex.Message);
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
            else if (Personagem is Tristan tristan)
            {
                Tristan.SkillsTristan(tristan.SpInitial, tristan.SpCost);
            }
            else if (Personagem is Okada okada)
            {
                Okada.SkillsOkada(okada.SpInitial, okada.SpCost);
            }
        }
        internal static void PlaySound(string audioFilePath)
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
        public static void StopBackgroundSound()
        {
            if (backgroundWaveOutDevice != null)
            {
                backgroundWaveOutDevice.Stop();
                backgroundWaveOutDevice.Dispose();
                backgroundWaveOutDevice = null;
            }
            if (backgroundAudioFileReader != null)
            {
                backgroundAudioFileReader.Dispose();
                backgroundAudioFileReader = null;
            }
        }
        public static int UserAttack(object personagem, int defesaInimigo, int danoTotal)
        {
            if (personagem is Artoria artoria)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    danoTotal = artoria.SwordSkill(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    danoTotal = artoria.ManaLoading(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3" && artoria.SpInitial >= artoria.SpCost)
                {
                    danoTotal = artoria.Excalibur(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Baobhan baobhan)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    danoTotal = baobhan.RangeAttack(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    danoTotal = baobhan.FinesseImprovement(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3" && baobhan.SpInitial >= baobhan.SpCost)
                {
                    danoTotal = baobhan.FetchFailnaught(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Okada okada)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    danoTotal = okada.SwordSkill(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    danoTotal = okada.AntiSaberAtkUp(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3" && okada.SpInitial >= okada.SpCost)
                {
                    danoTotal = okada.Shimatsuken(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Jalter jalter)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    danoTotal = jalter.SwordSkill(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    danoTotal = jalter.SelfModificationCritUp(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3")
                {
                    danoTotal = jalter.OblivionCorrectionCritUp(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "4" && jalter.SpInitial >= jalter.SpCost)
                {
                    danoTotal = jalter.LeGrondementdelaHaine(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Tristan tristan)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    danoTotal = tristan.RangeAttack(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    danoTotal = tristan.ManaLoading(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3" && tristan.SpInitial >= tristan.SpCost)
                {
                    danoTotal = tristan.Failnaught(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Mordred mordred)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    danoTotal = mordred.SwordSkill(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    danoTotal = mordred.ManaLoading(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3")
                {
                    danoTotal = mordred.KnightofCrimsonThunder(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "4" && mordred.SpInitial >= mordred.SpCost)
                {
                    danoTotal = mordred.ClarentBloodArthur(defesaInimigo, danoTotal);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            return danoTotal;
        }
        public static int DefesaInimigo(object Inimigo) 
        {
            if (Inimigo is FGO_BSx.EnemiesFate.EnemyArtoria enemyArtoria)
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