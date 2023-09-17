using Damage;

namespace Effects
{
    public class DoubleDamageBuff : BaseRemovableEffect, IBuff
    {
        private readonly IDamageMultiplier _damageMultiplier;
        private readonly int _multiplier;

        public DoubleDamageBuff(IDamageMultiplier damageMultiplier, int multiplier = 2)
        {
            _damageMultiplier = damageMultiplier;
            _multiplier = multiplier;
        }

        public override void ApplyEffect() => _damageMultiplier.AdditionalMultiply += _multiplier;

        public override void RemoveEffect() => _damageMultiplier.AdditionalMultiply -= _multiplier;
    }
}