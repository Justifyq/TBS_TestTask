using System;

namespace Damage
{
    public abstract class BaseDamageSystem : IDamageDealer
    {
        public event Action<IUnit> DamageDealing;
        public event Action<int> DamageDealt;
    
        protected readonly int BaseDamage;

        protected BaseDamageSystem(int baseDamage)
        {
            BaseDamage = baseDamage;
        }
    
        public void DealDamage(IUnit unit)
        {
            DamageDealing?.Invoke(unit);
            int beforeHealth = unit.Health;
            unit.GetDamage(CalculateDamage());
            int dealtDamage = beforeHealth - unit.Health;
            DamageDealt?.Invoke(dealtDamage);
        }

        protected abstract int CalculateDamage();
    }
}