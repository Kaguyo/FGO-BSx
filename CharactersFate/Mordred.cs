using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGO_BSx.CharactersFate
{
    internal class Mordred : FGO_BSx.Interfaces.ISaber
    {
        private string _name = "Mordred";
        private int _hpMax = 6021;
        private int _atkMax = 702;
        private int _defMax = 590;
        private int _hp = 6021;
        private int _atk = 702;
        private int _def = 590;
        private double _spCost = 160;
        private double _spInitial = 0;
        private double _basicAtk = 1.70;
        private double _extraAtk = 0.73; // 3 hits
        private static double _ultNpHit1 = 0.9; // 1 hit
        private static double _ultNpHit2 = 1.9; // 1 hit
        private static double _ultNpHit3 = 3.5; // 1 hit
        private static double _ultNpHit4 = 3.9; // 1 hit
        private static double _ultNpHit5 = 5.2; // 1 hit
        private int _spd = 100;
        private int _lvl = 1;
        private double _critDmg = 10;
        private double _critRate = 5;
        private double _classDmgBonus;

        internal double ClassDmgBonus { get => _classDmgBonus; set => _classDmgBonus = value; }
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
        internal static double UltNpHit1 { get => _ultNpHit1; set => _ultNpHit1 = value; }
        internal static double UltNpHit2 { get => _ultNpHit2; set => _ultNpHit2 = value; }
        internal static double UltNpHit3 { get => _ultNpHit3; set => _ultNpHit3 = value; }
        internal static double UltNpHit4 { get => _ultNpHit4; set => _ultNpHit4 = value; }
        internal static double UltNpHit5 { get => _ultNpHit5; set => _ultNpHit5 = value; }
        internal int SPD { get => _spd; set => _spd = value; }
        internal int Lvl { get => _lvl; set => _lvl = value; }
        internal double CritDmg { get => _critDmg; set => _critDmg = value; }
        internal double CritRate { get => _critRate; set => _critRate = value; }
        internal int BuffMordred { get; set; } = -1;
        internal static int ExtraAttackCooldown { get; set; } = 6;
    }
}
