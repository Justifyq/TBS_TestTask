using Damage;

namespace Effects
{
    public class ArmorDecreaseBuff : BaseRemovableEffect, IBuff
    {
        private readonly IDamageDealer _damageDealer;
        private readonly int _activeTurns;
        
        public ArmorDecreaseBuff(IDamageDealer armorSystem, int activeTurns = 1)
        {
            _damageDealer = armorSystem;
            _activeTurns = activeTurns;
        }

        public override void ApplyEffect() => _damageDealer.DamageDealing += DamageDealer_OnDamageDealing;

        public override void RemoveEffect() => _damageDealer.DamageDealing -= DamageDealer_OnDamageDealing;

        private void DamageDealer_OnDamageDealing(IUnit unit) => unit.ApplyDebuff<ArmorReduceDebuff>(_activeTurns);
    }
}