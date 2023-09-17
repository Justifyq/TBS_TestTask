using System;
using Health;
using UnityEngine.UI;

namespace Views
{
    public class HealthView : IDisposable
    {
        private readonly Slider _slider;
        private readonly IDamageable _damageable;

        public HealthView(IDamageable damageable, Slider slider)
        {
            _slider = slider;
            _damageable = damageable;

            slider.maxValue = damageable.MaxHealth;
            slider.value = damageable.Health;
            
            _damageable.HealthChanged += Damageable_OnHealthChanged;
        }
        
        public void Dispose() => _damageable.HealthChanged -= Damageable_OnHealthChanged;

        private void Damageable_OnHealthChanged(int lastHealth, int health) => _slider.value = health;
    }
}