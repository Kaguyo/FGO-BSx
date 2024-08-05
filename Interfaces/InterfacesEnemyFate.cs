using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGO_BSx.Interfaces
{
    public interface IEnemySwordsman
    {
        virtual void BasicAttack()
        {
            Console.WriteLine("Ataque normal");
        }
        virtual void SwordSkill()
        {
            Console.WriteLine("Ataque de espada");
        }
        virtual void HeavyAttack()
        {
            Console.WriteLine("Ataque pesado");
        }
        virtual void UltimateAttack()
        {
            Console.WriteLine("Ataque especial");
        }
    }
}
