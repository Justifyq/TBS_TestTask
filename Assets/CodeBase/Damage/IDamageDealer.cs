using System;
using Health;

namespace Damage
{
    public interface IDamageDealer
    {
        event Action<IUnit> DamageDealing;
        event Action<int> DamageDealt; 
        void DealDamage(IUnit unit);
    }
}