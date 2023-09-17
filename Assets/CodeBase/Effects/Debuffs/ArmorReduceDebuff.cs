using Health;

namespace Effects
{
    public class ArmorReduceDebuff : BaseRemovableEffect, IDebuff
    {
        private readonly IArmorSystem _armorSystem;
        private readonly int _armorReduce;

        public ArmorReduceDebuff(IArmorSystem armorSystem, int armorReduce = 10)
        {
            _armorSystem = armorSystem;
            _armorReduce = armorReduce;
        }

        public override void ApplyEffect() => _armorSystem.ReduceArmor += _armorReduce;

        public override void RemoveEffect() => _armorSystem.ReduceArmor -= _armorReduce;
    }
}