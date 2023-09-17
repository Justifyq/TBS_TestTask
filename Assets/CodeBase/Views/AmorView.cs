using System;
using Health;
using UnityEngine.UI;

namespace Views
{
    public class AmorView : IDisposable
    {
        private readonly Slider _slider;
        private readonly IArmorSystem _armorSystem;

        public AmorView(IArmorSystem armorSystem, Slider slider)
        {
            _armorSystem = armorSystem;
            _slider = slider;

            slider.maxValue = armorSystem.MaxArmor;
            slider.value = armorSystem.Armor;
            
            _armorSystem.ArmorChanged += ArmorSystem_OnArmorChanged;
        }

        public void Dispose() => _armorSystem.ArmorChanged -= ArmorSystem_OnArmorChanged;

        private void ArmorSystem_OnArmorChanged(int armor) => _slider.value = armor;
    }
}