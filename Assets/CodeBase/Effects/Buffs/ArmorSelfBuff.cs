using Health;

namespace Effects
{
    public class ArmorSelfBuff : BaseRemovableEffect, IBuff
    {
        private readonly IArmorSystem _armorSystem;

        private readonly int _armorChange;
        
        public ArmorSelfBuff(IArmorSystem armorSystem, int armorChange = 50)
        {
            _armorSystem = armorSystem;
            _armorChange = armorChange;
        }

        public override void ApplyEffect() => _armorSystem.AdditionalArmor += _armorChange;

        public override void RemoveEffect() => _armorSystem.AdditionalArmor -= _armorChange;
    }
}