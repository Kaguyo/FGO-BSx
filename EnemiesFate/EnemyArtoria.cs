using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGO_BSx.EnemiesFate
{

    internal class EnemyArtoria : Interfaces.IEnemySwordsman
    {
        private string _name = "Artoria";
        private int _hpMax = 265629;
        private int _atkMax = 940;
        private int _defMax = 215;
        private int _hp = 265629;
        private int _atk = 940;
        private int _def = 315;
        private double _spCost = 200;
        private double _spInitial = 0;
        private double _basicAtk = 4;
        private double _swordAtk = 6;
        private double _heavyAtk = 6.4;
        private double _ultNp = 11;
        private int _spd = 100;
        private int _lvl = 1;
        private double _critDmg = 10;
        private double _critRate = 5;
        private double _extraAtk = 0.3;

        internal string? LastComment { get; set; }
        internal string Name { get => _name; }
        internal int HpMax { get => _hpMax; set => _hpMax = value; }
        internal int AtkMax { get => _atkMax; set => _atkMax = value; }
        internal int DefMax { get => _defMax; set => _defMax = value; }
        internal int Hp { get => _hp; set => _hp = value; }
        internal int Atk { get => _atk; set => _atk = value; }
        internal int Def { get => _def; set => _def = value; }
        internal double SpCost { get => _spCost; set => _spCost = value; }
        internal double SpInitial { get => _spInitial; set => _spInitial = value; }
        internal double BasicAttack { get => _basicAtk; set => _basicAtk = value; }
        internal double Extra { get => _extraAtk; set => _extraAtk = value; }
        internal double UltNp { get => _ultNp; set => _ultNp = value; }
        internal int SPD { get => _spd; set => _spd = value; }
        internal int Lvl { get => _lvl; set => _lvl = value; }
        internal double CritDmg { get => _critDmg; set => _critDmg = value; }
        internal double CritRate { get => _critRate; set => _critRate = value; }
    }
}