using System;

namespace Damage
{
    public class DamageSystem : BaseDamageSystem
    {
        private readonly IDamageMultiplier _damageMultiplier;

        public DamageSystem(IDamageMultiplier damageMultiplier, int baseDamage = 15) : base(baseDamage)
        {
            _damageMultiplier = damageMultiplier;
        }

        protected override int CalculateDamage() => _damageMultiplier.RecalculateDamage(BaseDamage);
    }
}