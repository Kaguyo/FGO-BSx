using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGO_BSx.Interfaces
{
    interface IArcher
    {
        virtual void RangeAttack() 
        {
            Console.WriteLine("Ataque de longe");
        }
    }
    public interface ISaber
    {
        virtual void SwordSkill() 
        {
            Console.WriteLine("Ataque de espada");
        }
    }
    interface IAssassin
    {
        virtual void MurderSkill()
        {
            Console.WriteLine("Habilidade Assassin");
        }
    }
    interface IAvenger
    {
        virtual void StackUp()
        {
            Console.WriteLine("Buff");
        }
    }
}
