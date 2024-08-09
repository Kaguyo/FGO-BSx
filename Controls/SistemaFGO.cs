using FGO_BSx.CharactersFate;
using NAudio.Wave;
using System;

namespace FGO_BSx.Controls
{
    public class SistemaFGO
    {
        private static WaveStream audioFileReader;
        private static IWavePlayer backgroundWaveOutDevice;
        private static WaveStream backgroundAudioFileReader;
        static public string escolhaSkill = "";
        static public object inimigoEscolhido;
        static public object personagemEscolhido;
        static public string pararJogo = "";
        private static IWavePlayer waveOutDevice;

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
            if ((double)hp / hpMax <= 0.2)
            {
                WriteColoredAnsi(hp, "\x1b[38;5;124m");
            }
            else if ((double)hp / hpMax < 0.6)
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
            else if (personagemEscolhido is Jalter firstHassan)
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
                Artoria.SkillsArtoria(artoria.spInitial, artoria.spCost);
            }
            else if (Personagem is Baobhan baobhan)
            {
                Baobhan.SkillsBaobhan(baobhan.spInitial, baobhan.spCost);
            }
            else if (Personagem is Jalter jalter)
            {
                Jalter.SkillsJalter(jalter.spInitial, jalter.spCost);
            }
            else if (Personagem is Mordred mordred)
            {
                Mordred.SkillsMordred(mordred.spInitial, mordred.spCost);
            }
            else if (Personagem is Tristan tristan)
            {
                Tristan.SkillsTristan(tristan.spInitial, tristan.spCost);
            }
            else if (Personagem is Okada okada)
            {
                Okada.SkillsOkada(okada.spInitial, okada.spCost);
            }
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
        public static void UserAttack(object personagem)
        {
            if (personagem is Artoria artoria)
            {
                if (Controls.SistemaFGO.escolhaSkill == "1")
                {
                    artoria.SwordSkill();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "2")
                {
                    artoria.ManaLoading();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "3")
                {
                    artoria.Excalibur();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Baobhan baobhan) 
            {
                if (Controls.SistemaFGO.escolhaSkill == "1")
                {
                    baobhan.RangeAttack();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "2")
                {
                    baobhan.FinesseImprovement();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "3")
                {
                    baobhan.FetchFailnaught();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Okada okada)
            {
                if (Controls.SistemaFGO.escolhaSkill == "1")
                {
                    okada.SwordSkill();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "2")
                {
                    okada.AntiSaberAtkUp();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "3")
                {
                    okada.Shimatsuken();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Jalter jalter)
            {
                if (Controls.SistemaFGO.escolhaSkill == "1")
                {
                    jalter.SwordSkill();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "2")
                {
                    jalter.SelfModificationCritUp();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "3")
                {
                    jalter.OblivionCorrectionCritUp();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "4")
                {
                    jalter.LeGrondementdelaHaine();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Tristan tristan)
            {
                if (Controls.SistemaFGO.escolhaSkill == "1")
                {
                    tristan.RangeAttack();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "2")
                {
                    tristan.ManaLoading();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "3")
                {
                    tristan.Failnaught();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Mordred mordred)
            {
                if (Controls.SistemaFGO.escolhaSkill == "1")
                {
                    mordred.SwordSkill();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "2")
                {
                    mordred.ManaLoading();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "3")
                {
                    mordred.KnightofCrimsonThunder();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
                else if (Controls.SistemaFGO.escolhaSkill == "4")
                {
                    mordred.ClarentBloodArthur();
                    Controls.SistemaFGO.escolhaSkill = "";
                }
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

        public static void WriteColoredAnsi(string text, string ansiColor)
        {
            Console.Write($"{ansiColor}{text}\x1b[0m");
        }

        public static void WriteColoredAnsi(int i, string ansiColor)
        {
            Console.Write($"{ansiColor}{i}\x1b[0m");
        }
    }
}