﻿using FGO_BSx.CharactersFate;
using NAudio.Wave;
using System;


namespace FGO_BSx.Controls
{
    public class SistemaFGO
    {
        private static readonly Random random = new Random();
        private static WaveStream? audioFileReader;
        private static WaveOutEvent? backgroundWaveOutDevice;
        private static WaveStream? backgroundAudioFileReader;
        static internal string escolhaSkill = "";
        static internal object? inimigoEscolhido;
        static internal object? personagemEscolhido;
        private static WaveOutEvent? waveOutDevice;
        internal static bool SuccessToAttack { get; set; }

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
            if ((hp / hpMax) < 0.2)
            {
                WriteColoredAnsi(hp, "\x1b[38;5;124m");
            }
            else if ((hp / hpMax) < 0.6)
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
                Console.Write("   |   ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
            else if (personagemEscolhido is Jalter jalter)
            {
                WriteColored("Jeanne D'arc (Alter)", ConsoleColor.DarkYellow);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, jalter.Hp);
                Console.Write("  |    ");
                DisplayEnemyInfo(inimigoEscolhido, vidaInimigo, spEnemy, spCostEnemy);
            }
            else if (personagemEscolhido is Mordred mordred)
            {
                WriteColored("Mordred", ConsoleColor.Yellow);
                Console.Write(" [");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP(vidaUsuario, mordred.Hp);
                Console.Write("    |    ");
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
        public static int EnemyAttack(object inimigo, int defesaUsuario, int danoTotalEnemy) 
        {
            if (inimigo is EnemiesFate.EnemyArtoria enemyArtoria) 
            {
                while (true)
                {
                    int choice = random.Next(1, 4);
                }
            }
            return danoTotalEnemy;
        }
        public static int UserAttack(object personagem, int defesaInimigo, int danoTotalUser)
        {
            if (personagem is Artoria artoria)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    danoTotalUser = artoria.SwordSkill(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    danoTotalUser = artoria.ManaLoading(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (SistemaFGO.escolhaSkill == "3" && artoria.SpInitial >= artoria.SpCost)
                {
                    danoTotalUser = artoria.Excalibur(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
            }
            else if (personagem is Baobhan baobhan)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    danoTotalUser = baobhan.RangeAttack(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    danoTotalUser = baobhan.FinesseImprovement(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (SistemaFGO.escolhaSkill == "3" && baobhan.SpInitial >= baobhan.SpCost)
                {
                    danoTotalUser = baobhan.FetchFailnaught(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
            }
            else if (personagem is Jalter jalter)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    danoTotalUser = jalter.SwordSkill(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    danoTotalUser = jalter.SelfModificationCritUp(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (SistemaFGO.escolhaSkill == "3")
                {
                    danoTotalUser = jalter.OblivionCorrectionCritUp(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (SistemaFGO.escolhaSkill == "4" && jalter.SpInitial >= jalter.SpCost)
                {
                    danoTotalUser = jalter.LeGrondementdelaHaine(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
            }
            else if (personagem is Mordred mordred)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    danoTotalUser = mordred.SwordSkill(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    danoTotalUser = mordred.ManaLoading(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (SistemaFGO.escolhaSkill == "3")
                {
                    danoTotalUser = mordred.KnightofCrimsonThunder(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
                else if (SistemaFGO.escolhaSkill == "4" && mordred.SpInitial >= mordred.SpCost)
                {
                    danoTotalUser = mordred.ClarentBloodArthur(defesaInimigo, danoTotalUser);
                    SistemaFGO.escolhaSkill = "";
                    SuccessToAttack = true;
                    Console.Clear();
                }
            }
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