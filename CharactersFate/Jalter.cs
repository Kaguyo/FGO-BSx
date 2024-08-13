using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGO_BSx.CharactersFate
{
    internal class Jalter : FGO_BSx.Interfaces.IAvenger
    {
        internal String name = "Jeanne d'arc (Alter)";
        internal double hpMax = 6551;
        internal int atkMax = 222;
        internal int defMax = 590;
        internal double hp = 6551;
        internal int atk = 222;
        internal int def = 590;
        internal int spCost = 175;
        internal int spInitial = 0;
        internal double basicAtk = 1.60;
        internal double ultNp = 5.9;
        internal int spd = 100;
        internal int lvl = 1;
        internal double critDmg = 10;
        internal double critRate = 5;


        public static void SkillsJalter(double sp, double spCost) 
        {
            FGO_BSx.Controls.SistemaFGO.WriteColored("Sword Attack", ConsoleColor.DarkYellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("1", ConsoleColor.Green);
            Console.WriteLine(")");
            FGO_BSx.Controls.SistemaFGO.WriteColored("Self Modification", ConsoleColor.DarkYellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("2", ConsoleColor.Green);
            Console.WriteLine(")");
            FGO_BSx.Controls.SistemaFGO.WriteColored("Ephemeral Dream", ConsoleColor.DarkYellow);
            Console.Write(" (");
            Controls.SistemaFGO.WriteColored("3", ConsoleColor.Green);
            Console.WriteLine(")");
            //passive Self-Replenishment (Magic)
            //passive Extra Attack Finesse Improvement
            if (sp < spCost)
            {
                FGO_BSx.Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Yellow);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.Magenta);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.Gray);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Le Grondement de la Haine", ConsoleColor.DarkYellow);
                Console.Write(" (");
                Controls.SistemaFGO.WriteColored("4", ConsoleColor.Green);
                Console.Write(")");
                FGO_BSx.Controls.SistemaFGO.WriteColored(")", ConsoleColor.Gray);
                Controls.SistemaFGO.WriteColored("\nNP Energy", ConsoleColor.Magenta);
                Console.Write(": ");
                sp /= spCost;
                sp *= 100;
                FGO_BSx.Controls.SistemaFGO.WriteColored((int)sp, ConsoleColor.DarkGray);
                Controls.SistemaFGO.WriteColored("/", ConsoleColor.Magenta);
                FGO_BSx.Controls.SistemaFGO.WriteColored("100", ConsoleColor.Green);
                FGO_BSx.Controls.SistemaFGO.WriteColored("  NOT READY", ConsoleColor.DarkRed);
                FGO_BSx.Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Yellow);
            }
            else if (sp >= spCost)
            {
                sp = spCost;
                FGO_BSx.Controls.SistemaFGO.WriteColored("-------------------------------\n", ConsoleColor.Yellow);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Noble Phantasm", ConsoleColor.Magenta);
                Controls.SistemaFGO.WriteColored(" (", ConsoleColor.Gray);
                FGO_BSx.Controls.SistemaFGO.WriteColored("Le Grondement de la Haine", ConsoleColor.DarkYellow);
                Console.Write(" (");
                Controls.SistemaFGO.WriteColored("3", ConsoleColor.Green);
                Console.Write(")");
                FGO_BSx.Controls.SistemaFGO.WriteColored(")", ConsoleColor.Gray);
                Controls.SistemaFGO.WriteColored("\nNP Energy", ConsoleColor.Magenta);
                Console.Write(": ");
                sp /= spCost;
                sp *= 100;
                FGO_BSx.Controls.SistemaFGO.WriteColored(((int)sp), ConsoleColor.Green);
                Controls.SistemaFGO.WriteColored("/", ConsoleColor.Magenta);
                FGO_BSx.Controls.SistemaFGO.WriteColored("100", ConsoleColor.Green);
                FGO_BSx.Controls.SistemaFGO.WriteColored("  READY", ConsoleColor.Green);
                FGO_BSx.Controls.SistemaFGO.WriteColored("\n-------------------------------", ConsoleColor.Yellow);
            }
        }
    }
}
