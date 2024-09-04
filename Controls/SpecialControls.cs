namespace FGO_BSx.Controls
{
    internal class SpecialControls
    {
        internal static int CalculateDamage(double mainStat, int defesaInimigo, double instance, double critRate, double critDmg, Random random)
        {
            double RNGcrit = SistemaFGO.NextDoubleInRange(random, 0, 100.1);
            int DanoCausado;

            if (RNGcrit <= critRate && RNGcrit > 0)
            {
                DanoCausado = (int)((mainStat - defesaInimigo) * instance * (1 + (critDmg / 100)));
            }
            else
            {
                DanoCausado = (int)((mainStat - defesaInimigo) * instance);
            }

            // Ensure the damage is at least 1
            return Math.Max(1, DanoCausado);
        }
    }
}
