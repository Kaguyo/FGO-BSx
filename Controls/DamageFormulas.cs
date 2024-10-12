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
            int totalDano = 0; // Variável para acumular o dano total

            for (int i = 0; i < hits; i++)
            {
                double RNGcrit = NextDoubleInRange(random, 0, 100.1);

                if (RNGcrit <= critRate)
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * skillAtk[i] * (1 + (critDmg / 100)));
                    Danos[i] = Math.Max(1, DanoCausado);
                    Console.SetCursorPosition(0, 0);
                    Console.Write($"Dano Causado: {Danos[i]}");
                    Console.SetCursorPosition(0, 1);
                    Console.Write("CRITICAL HIT!");
                    totalDano += Danos[i];
                }
                else
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * skillAtk[i]);
                    Danos[i] = Math.Max(1, DanoCausado);
                    Console.SetCursorPosition(0, 0);
                    Console.Write($"Dano Causado: {Danos[i]}");
                    Console.SetCursorPosition(0, 1);
                    Console.Write(new string(' ', Console.WindowWidth)); // Limpa linha do "CRITICAL HIT!"
                    totalDano += Danos[i];
                }

                Console.SetCursorPosition(0, 2);
                Console.Write($"Dano Total: {totalDano}");

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
            int totalDano = 0; // Variável para acumular o dano total

            for (int i = 0; i < hits; i++)
            {
                double RNGcrit = NextDoubleInRange(random, 0, 100.1);

                if (RNGcrit <= critRate)
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * skillAtk * (1 + (critDmg / 100)));
                    Danos[i] = Math.Max(1, DanoCausado);
                    Console.SetCursorPosition(0, 0);
                    Console.Write($"Dano Causado: {Danos[i]}");
                    Console.SetCursorPosition(0, 1);
                    Console.Write("CRITICAL HIT!");
                    totalDano += Danos[i];
                }
                else
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * skillAtk);
                    Danos[i] = Math.Max(1, DanoCausado);
                    Console.SetCursorPosition(0, 0);
                    Console.Write($"Dano Causado: {Danos[i]}");
                    Console.SetCursorPosition(0, 1);
                    Console.Write(new string(' ', Console.WindowWidth)); // Limpa linha do "CRITICAL HIT!"
                    totalDano += Danos[i];
                }

                Console.SetCursorPosition(0, 2);
                Console.Write($"Dano Total: {totalDano}");

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
            int initialCursorTop = Console.CursorTop;

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

                Console.SetCursorPosition(0, initialCursorTop);
                Console.Write("Dano Causado: ");
                SistemaFGO.WriteColored(Danos[i], ConsoleColor.DarkYellow);

                if (RNGcrit <= critRate)
                {
                    Console.SetCursorPosition(0, initialCursorTop + 1);
                    Console.Write("CRITICAL HIT!");
                }
                else
                {
                    Console.SetCursorPosition(0, initialCursorTop + 1);
                    Console.Write(new string(' ', Console.WindowWidth));
                }

                if (i > 0)
                {
                    DanoCausado += Danos[i - 1];
                }
                Danos[i] = DanoCausado;
                Console.SetCursorPosition(0, initialCursorTop + 2);
                Console.Write("Dano Total: ");
                SistemaFGO.WriteColored(Danos[i], ConsoleColor.DarkYellow);

                if (whichHitIsNpAt <= 3) Thread.Sleep(250);
                else if (whichHitIsNpAt == 4) Thread.Sleep(150);
                else if (whichHitIsNpAt < 9) Thread.Sleep(13);
                else Thread.Sleep(120);

                if (whichHitIsNpAt == 9) danoTotal += Danos[8];
                whichHitIsNpAt += 1;
            }
            Console.WriteLine();
            Console.ReadKey();

            return danoTotal;
        }
        public static int MordredNP(Random random, double mainStat, double[] NPInstances, double critRate, double critDmg, int hits, int defesaInimigo, int danoTotal, double multiplicadorFinal)
        {
            Console.Clear();
            int DanoCausado;
            int[] Danos = new int[hits];
            int whichHitIsNpAt = 1;
            int initialCursorTop = Console.CursorTop;

            for (int i = 0; i < hits; i++)
            {
                double RNGcrit = NextDoubleInRange(random, 0, 100.1);

                if (RNGcrit <= critRate)
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * NPInstances[i] * (1 + (critDmg / 100)) * multiplicadorFinal);
                    Danos[i] = Math.Max(1, DanoCausado);
                }
                else
                {
                    DanoCausado = (int)((mainStat - defesaInimigo) * NPInstances[i] * multiplicadorFinal);
                    Danos[i] = Math.Max(1, DanoCausado);
                }

                Console.SetCursorPosition(0, initialCursorTop);
                Console.Write("Dano Causado: ");
                SistemaFGO.WriteColored(Danos[i], ConsoleColor.Yellow);

                if (RNGcrit <= critRate)
                {
                    Console.SetCursorPosition(0, initialCursorTop + 1);
                    Console.Write("CRITICAL HIT!");
                }
                else
                {
                    Console.SetCursorPosition(0, initialCursorTop + 1);
                    Console.Write(new string(' ', Console.WindowWidth));
                }

                if (i > 0)
                {
                    DanoCausado += Danos[i - 1];
                }
                Danos[i] = DanoCausado;
                Console.SetCursorPosition(0, initialCursorTop + 2);
                Console.Write("Dano Total: ");
                SistemaFGO.WriteColored(Danos[i], ConsoleColor.DarkYellow);

                if (whichHitIsNpAt < 3) Thread.Sleep(150);
                else Thread.Sleep(100);

                if (whichHitIsNpAt == 5) danoTotal += Danos[4];
                whichHitIsNpAt += 1;
            }
            Console.WriteLine();
            Console.ReadKey();

            return danoTotal;
        }
        public static int BaobhanNP(Random random, double mainStat, double[] NPInstances, double critRate, double critDmg, int hits, int defesaInimigo, int danoTotal)
        {
            Console.Clear();
            int DanoCausado;
            int[] Danos = new int[hits];
            int whichHitIsNpAt = 1;
            int initialCursorTop = Console.CursorTop;

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

                Console.SetCursorPosition(0, initialCursorTop);
                Console.Write("Dano Causado: ");
                SistemaFGO.WriteColored(Danos[i], ConsoleColor.Red);

                if (RNGcrit <= critRate)
                {
                    Console.SetCursorPosition(0, initialCursorTop + 1);
                    Console.Write("CRITICAL HIT!");
                }
                else
                {
                    Console.SetCursorPosition(0, initialCursorTop + 1);
                    Console.Write(new string(' ', Console.WindowWidth));
                }

                if (i > 0)
                {
                    DanoCausado += Danos[i - 1];
                }
                Danos[i] = DanoCausado;
                Console.SetCursorPosition(0, initialCursorTop + 2);
                Console.Write("Dano Total: ");
                SistemaFGO.WriteColored(Danos[i], ConsoleColor.Red);

                if (whichHitIsNpAt == 1) Thread.Sleep(850);
                else Thread.Sleep(6);

                if (whichHitIsNpAt == 5) danoTotal += Danos[4];
                whichHitIsNpAt += 1;
            }
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
                Console.Write("\nDano Total: ");
                Controls.SistemaFGO.WriteColored(DanoCausado, ConsoleColor.Yellow);

            }
            else
            {
                DanoCausado = (int)((Atk - defesaInimigo) * NPSkill);
                DanoCausado = Math.Max(1, DanoCausado);
                danoTotal += DanoCausado;

                Console.WriteLine($"\r{DanoCausado}");
                Console.ResetColor();
                Console.Write("\nDano Total: ");
                Controls.SistemaFGO.WriteColored(DanoCausado, ConsoleColor.Yellow);
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