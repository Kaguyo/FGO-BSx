namespace FGO_BSx.Controls
{
    internal class DamageFormulas
    {
        //  ======================
        //  GENERIC DAMAGE FORMULA
        //  ======================
        public static int CauseDamage(Random random, double mainStat, double[] skillAtk, double critRate, double critDmg, int hits, int defesaInimigo, int danoTotal)
        {
            Console.Clear();
            int DanoCausado;
            int[] Danos = new int[hits];
            for (int i = 0; i < hits; i++)
            {
                double RNGcrit = NextDoubleInRange(random, 0, 100.1);
                if (RNGcrit <= critRate)
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * skillAtk[i] * (1 + (critDmg / 100)));
                    Danos[i] = Math.Max(1, DanoCausado);
                    danoTotal += Danos[i];
                }
                else
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * skillAtk[i]);
                    Danos[i] = Math.Max(1, DanoCausado);
                    danoTotal += Danos[i];
                }
            }
            Console.Write("Dano Total: ");
            for (int i = 0; i < hits; i++)
            {
                if (i != (hits - 1))
                {
                    Danos[i + 1] += Danos[i];
                }
                Console.Write($"\r{Danos[i]}");
                Thread.Sleep(15);
            }
            Console.WriteLine();
            Console.ReadKey();
            return danoTotal;
        }
        public static int CauseDamage(Random random, double mainStat, double skillAtk, double critRate, double critDmg, int hits, int defesaInimigo, int danoTotal)
        {
            Console.Clear();
            int DanoCausado;
            int[] Danos = new int[hits];
            for (int i = 0; i < hits; i++)
            {
                double RNGcrit = NextDoubleInRange(random, 0, 100.1);
                if (RNGcrit <= critRate)
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * skillAtk * (1 + (critDmg / 100)));
                    Danos[i] = Math.Max(1, DanoCausado);
                    danoTotal += Danos[i];
                }
                else
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * skillAtk);
                    Danos[i] = Math.Max(1, DanoCausado);
                    danoTotal += Danos[i];
                }
            }
            Console.Write("Dano Total: ");
            for (int i = 0; i < hits; i++)
            {
                if (i != (hits - 1))
                {
                    Danos[i + 1] += Danos[i];
                }
                Console.Write($"\r{Danos[i]}");
                Thread.Sleep(15);
            }
            Console.WriteLine();
            Console.ReadKey();
            return danoTotal;
        }

        //  ====================
        //  JALTER NP FORMULA
        //  ====================
        public static int JalterNP(Random random, double mainStat, double[] NPInstances, double critRate, double critDmg, int hits, int defesaInimigo, int danoTotal)
        {
            Console.Clear();
            int DanoCausado;
            int[] Danos = new int[hits];
            int whichHitIsNpAt = 1;

            Console.Write("Dano Total: ");
            SistemaFGO.WriteColored2(ConsoleColor.DarkYellow);

            for (int i = 0; i < hits; i++)
            {
                double RNGcrit = NextDoubleInRange(random, 0, 100.1);
                if (RNGcrit <= critRate)
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * NPInstances[i] * (1 + (critDmg / 100)));
                    Danos[i] = Math.Max(1, DanoCausado);
                }
                else
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * NPInstances[i]);
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
                if (whichHitIsNpAt == 9) danoTotal += Danos[i];
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey();
            return danoTotal;
        }


        //  ====================
        //  ARTORIA NP FORMULA
        //  ====================
        public static int ArtoriaNP(Random random, double Atk, double NPSkill, double critRate, double critDmg, int defesaInimigo, int danoTotal)
        {
            Console.Clear();
            int DanoCausado;
            Console.Write("Dano Causado: ");
            SistemaFGO.WriteColored2(ConsoleColor.Yellow);

            double RNGcrit = NextDoubleInRange(random, 0, 100.1);
            if (RNGcrit <= critRate)
            {
                DanoCausado = (int)((Atk - defesaInimigo) * NPSkill * (1 + (critDmg / 100)));
                DanoCausado = Math.Max(1, DanoCausado);
                danoTotal += DanoCausado;

                Console.WriteLine($"\r{DanoCausado}");
                Console.ResetColor();
                Console.WriteLine("CRITICAL HIT!");
            }
            else
            {
                DanoCausado = (int)((Atk - defesaInimigo) * NPSkill);
                DanoCausado = Math.Max(1, DanoCausado);
                danoTotal += DanoCausado;

                Console.WriteLine($"\r{DanoCausado}");
                Console.ResetColor();
            }
            Console.ReadKey();
            return danoTotal;
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