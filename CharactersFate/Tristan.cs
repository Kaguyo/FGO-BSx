using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGO_BSx.CharactersFate
{
    internal class Tristan : Interfaces.IArcher
    {
        private string _name = "Tristan";
        private int _hpMax = 4551;
        private int _atkMax = 658;
        private int _defMax = 480;
        private int _hp = 4551;
        private int _atk = 158;
        private int _def = 480;
        private double _spCost = 160;
        private double _spInitial = 0;
        private double _basicAtk = 1.3;
        private double _ultNp = 5;
        private int _spd = 120;
        private int _lvl = 1;
        private double _critDmg = 10;
        private double _critRate = 5;

        internal string Name
        {
            get { return _name; }
        }
        internal int HpMax
        {
            get
            {
                return _hpMax;
            }
            set
            {
                _hpMax = value;
            }
        }
        internal int AtkMax
        {
            get
            {
                return _atkMax;
            }
            set
            {
                _atkMax = value;
            }
        }
        internal int DefMax
        {
            get
            {
                return _defMax;
            }
            set
            {
                _defMax = value;
            }
        }
        internal int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }
        }
        internal int Atk
        {
            get
            {
                return _atk;
            }
            set
            {
                _atk = value;
            }
        }
        internal int Def
        {
            get
            {
                return _def;
            }
            set
            {
                _def = value;
            }
        }
        internal double SpCost
        {
            get
            {
                return _spCost;
            }
            set
            {
                _spCost = value;
            }
        }
        internal double SpInitial
        {
            get
            {
                return _spInitial;
            }
            set
            {
                _spInitial = value;
            }
        }
        internal double BasicAttack
        {
            get
            {
                return _basicAtk;
            }
            set
            {
                _basicAtk = value;
            }
        }
        internal double UltNp
        {
            get
            {
                return _ultNp;
            }
            set
            {
                _ultNp = value;
            }
        }
        internal int SPD
        {
            get
            {
                return _spd;
            }
            set
            {
                _spd = value;
            }
        }
        internal int Lvl
        {
            get
            {
                return _lvl;
            }
            set
            {
                _lvl = value;
            }
        }
        internal double CritDmg
        {
            get
            {
                return _critDmg;
            }
            set
            {
                _critDmg = value;
            }
        }
        internal double CritRate
        {
            get
            {
                return _critRate;
            }
            set
            {
                _critRate = value;
            }
        }
    }
}
