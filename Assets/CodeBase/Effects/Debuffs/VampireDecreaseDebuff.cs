using AttackEffects;

namespace Effects
{
    public class VampireDecreaseDebuff : BaseRemovableEffect, IDebuff
    {
        private readonly IVampireSystem _vampireSystem;
        private readonly int _vampireReduce;

        public VampireDecreaseDebuff(IVampireSystem vampireSystem, int vampireReduce = 25)
        {
            _vampireSystem = vampireSystem;
            _vampireReduce = vampireReduce;
        }

        public override void ApplyEffect() =>  _vampireSystem.ReduceVampire += _vampireReduce;
        public override void RemoveEffect() => _vampireSystem.ReduceVampire -= _vampireReduce;
    }
}