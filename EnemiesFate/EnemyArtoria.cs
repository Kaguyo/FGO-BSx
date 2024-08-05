using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGO_BSx.EnemiesFate
{

    public class EnemyArtoria : FGO_BSx.Interfaces.IEnemySwordsman
    {
        internal String name = "Artoria";
        internal double hpMax = 265629;
        internal int atkMax = 140;
        internal int defMax = 115;
        internal double hp = 265629;
        internal int atk = 140;
        internal int def = 115;
        internal double spCost = 200;
        internal double spInitial = 0;
        internal double basicAtk = 4;
        internal double swordAtk = 6;
        internal double heavyAtk = 6.4;
        internal double ultNp = 11;
        internal int spd = 100;
        internal int lvl = 1;
        internal double critDmg = 10;
        internal double critRate = 5;
    }
}
