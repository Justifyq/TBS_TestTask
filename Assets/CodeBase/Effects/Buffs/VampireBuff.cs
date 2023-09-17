using AttackEffects;
using Health;

namespace Effects
{
    public class VampireBuff : BaseRemovableEffect, IBuff
    {
        private readonly IArmorSystem _armorSystem;
        private readonly IVampireSystem _vampireSystem;

        public VampireBuff(IArmorSystem armorSystem, IVampireSystem vampireSystem)
        {
            _armorSystem = armorSystem;
            _vampireSystem = vampireSystem;
        }

        public override void ApplyEffect()
        {
            _vampireSystem.AdditionalVampire += 50;
            _armorSystem.ReduceArmor += 25;
        }

        public override void RemoveEffect()
        {
            _vampireSystem.AdditionalVampire -= 50;
            _armorSystem.ReduceArmor -= 25;
        }
    }
}