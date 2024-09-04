namespace FGO_BSx.Controls
{
    internal class DamageFormulas
    {
        //  ======================
        //  GENERIC DAMAGE FORMULA
        //  ======================
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
                Thread.Sleep(25);
            }
            Console.WriteLine();
            Console.ReadKey();
        }


        //  ====================
        //  JALTER NP FORMULA
        //  ====================
        public static void JalterNP(Random random, double mainStat, double skillAtk1, double skillAtk2, double skillAtk3, double skillAtk4, double skillAtk5, double skillAtk6,
        double skillAtk7, double skillAtk8, double skillAtk9, double critRate, double critDmg, int hits, int defesaInimigo)
        {
            int DanoCausado;
            int[] Danos = new int[hits];
            double[] InstanciasNP = { skillAtk1, skillAtk2, skillAtk3, skillAtk4, skillAtk5, skillAtk6, skillAtk7, skillAtk8, skillAtk9 };
            int whichHitIsNpAt = 1;

            Console.Write("Dano Total: ");
            SistemaFGO.WriteColored2(ConsoleColor.DarkYellow);

            for (int i = 0; i < hits; i++)
            {
                double RNGcrit = NextDoubleInRange(random, 0, 100.1);
                if (RNGcrit <= critRate && RNGcrit > 0)
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * InstanciasNP[i] * (1 + (critDmg / 100)));
                    Danos[i] = Math.Max(1, DanoCausado);
                }
                else
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * InstanciasNP[i]);
                    Danos[i] = Math.Max(1, DanoCausado);
                }
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


        //  ============================
        //  FORMS TO GENERATE CRIT HITS
        //  ============================
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
    }
}