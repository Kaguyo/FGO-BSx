using FGO_BSx.CharactersFate;
using NAudio.Wave;

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
                DisplayHP((int)artoria.Hp, (int)artoria.HpMax);
            }
            else if (personagemEscolhido is Baobhan baobhan)
            {
                WriteColored("Baobhan", ConsoleColor.Red);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)baobhan.Hp, (int)baobhan.HpMax);
            }
            else if (personagemEscolhido is Jalter firstHassan)
            {
                WriteColored("Hassan", ConsoleColor.DarkMagenta);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)firstHassan.Hp, (int)firstHassan.HpMax);
            }
            else if (personagemEscolhido is Mordred mordred)
            {
                WriteColored("Mordred", ConsoleColor.Yellow);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)mordred.Hp, (int)mordred.HpMax);
            }
            else if (personagemEscolhido is Tristan tristan)
            {
                WriteColored("Tristan", ConsoleColor.DarkRed);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)tristan.Hp, (int)tristan.HpMax);
            }
            else if (personagemEscolhido is Okada okada)
            {
                WriteColored("Okada", ConsoleColor.DarkGray);
                Console.Write("[");
                WriteColored("HP", ConsoleColor.Green);
                Console.Write("]: ");
                DisplayHP((int)okada.Hp, (int)okada.HpMax);
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
        public static void UserAttack(object personagem, int defesaInimigo)
        {
            if (personagem is Artoria artoria)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    artoria.SwordSkill(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    artoria.ManaLoading(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3" && artoria.SpInitial >= artoria.SpCost)
                {
                    artoria.Excalibur(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Baobhan baobhan) 
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    baobhan.RangeAttack(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    baobhan.FinesseImprovement(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3" && baobhan.SpInitial >= baobhan.SpCost)
                {
                    baobhan.FetchFailnaught(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Okada okada)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    okada.SwordSkill(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    okada.AntiSaberAtkUp(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3" && okada.SpInitial >= okada.SpCost)
                {
                    okada.Shimatsuken(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Jalter jalter)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    jalter.SwordSkill(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    jalter.SelfModificationCritUp(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3")
                {
                    jalter.OblivionCorrectionCritUp(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "4" && jalter.SpInitial >= jalter.SpCost)
                {
                    jalter.LeGrondementdelaHaine(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Tristan tristan)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    tristan.RangeAttack(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    tristan.ManaLoading(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3" && tristan.SpInitial >= tristan.SpCost)
                {
                    tristan.Failnaught(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
            }
            else if (personagem is Mordred mordred)
            {
                if (SistemaFGO.escolhaSkill == "1")
                {
                    mordred.SwordSkill(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "2")
                {
                    mordred.ManaLoading(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "3")
                {
                    mordred.KnightofCrimsonThunder(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
                else if (SistemaFGO.escolhaSkill == "4" && mordred.SpInitial >= mordred.SpCost)
                {
                    mordred.ClarentBloodArthur(defesaInimigo);
                    SistemaFGO.escolhaSkill = "";
                }
            }
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
        public static void CauseDamage(Random random, double mainStat, double skillAtk, double critRate, double critDmg, int hits, int defesaInimigo)
        {
            int DanoCausado;
            int[] Danos = new int[hits];
            for (int i = 0; i < hits; i++)
            {
                double RNGcrit = NextDoubleInRange(random, 0, 100.1);
                if (RNGcrit <= critRate && RNGcrit > 0)
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * skillAtk * (1 + (critDmg / 100)));
                    Danos[i] = Math.Max(1, DanoCausado);
                }
                else
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * skillAtk);
                    Danos[i] = Math.Max(1, DanoCausado);
                }
            }
            Console.Write("Dano Total: ");
            for (int i = 0; i < hits; i++)
            {
                if (i != (hits - 1)) Danos[i + 1] += Danos[i];
                Console.Write($"\r{Danos[i]}");
                Thread.Sleep(15);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public static void JalterNP(Random random, double mainStat, double skillAtk1, double skillAtk2, double skillAtk3, double skillAtk4, double skillAtk5, double skillAtk6,
        double skillAtk7, double skillAtk8, double skillAtk9, double critRate, double critDmg, int hits, int defesaInimigo)
        {
            int DanoCausado;
            int[] Danos = new int[hits];
            double[] InstanciasNP = { skillAtk1, skillAtk2, skillAtk3, skillAtk4, skillAtk5, skillAtk6, skillAtk7, skillAtk8, skillAtk9 };
            int whichHitIsNpAt = 1;

            Console.Write("Dano Total: ");
            WriteColored2(ConsoleColor.DarkYellow);
            
            for (int i = 0; i < hits; i++)
            {
                DanoCausado = SpecialControls.CalculateDamage(mainStat, defesaInimigo, InstanciasNP[i], critRate, critDmg, random);
                if (i > 0)
                {
                    DanoCausado += Danos[i - 1];
                }
                Danos[i] = DanoCausado;

                Console.Write($"\r{Danos[i]}");
                if (whichHitIsNpAt <= 3) Thread.Sleep(250);
                else if (whichHitIsNpAt == 4) Thread.Sleep(150);
                else if (whichHitIsNpAt < 9) Thread.Sleep(13);
                else Thread.Sleep(120);

                whichHitIsNpAt += 1;
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey();
        }
        public static double NextDoubleInRange(Random random, double minValue, double maxValue)
        {
            double randomValue = random.NextDouble();
            double result = minValue + (randomValue * (maxValue - minValue));
            return result;
        }
        public static double Valor(double value1, double value2)
        {
            double value = value2 - value1;
            return value;
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