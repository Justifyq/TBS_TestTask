using Damage;

namespace Effects
{
    public class VampireDecreaseBuff : BaseRemovableEffect, IBuff
    {
        private readonly IDamageDealer _damageDealer;
        private readonly int _activeTurns;

        public VampireDecreaseBuff(IDamageDealer damageDealer, int turns = 1)
        {
            _damageDealer = damageDealer;
            _activeTurns = turns;
        }

        public override void ApplyEffect() =>  _damageDealer.DamageDealing += DamageDealerOn_DamageDealing;
        public override void RemoveEffect() => _damageDealer.DamageDealing -= DamageDealerOn_DamageDealing;
        
        private void DamageDealerOn_DamageDealing(IUnit unit) => unit.ApplyDebuff<VampireDecreaseDebuff>(_activeTurns);
    }
}