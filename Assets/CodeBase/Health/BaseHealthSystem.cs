using System;

namespace Health
{
    public abstract class BaseHealthSystem : IDamageable
    {
        public event Action<int, int> HealthChanged;
        
        public int MaxHealth => _baseHealth;

        public int Health
        {
            get => _health;

            protected set
            {
                if (value == _health)
                    return;

                int lastHealth = _health;
                _health = value;

                if (_health > _baseHealth)
                    _health = _baseHealth;
            
                if (_health < 0)
                    _health = 0;

                HealthChanged?.Invoke(lastHealth, _health);
            }
        }

        private int _health;

        private int _baseHealth;

        protected BaseHealthSystem(int baseHealth = 100)
        {
            _baseHealth = baseHealth;
            _health = baseHealth;
        }

        public abstract void GetDamage(int damage);

        public abstract void RecoverHealth(int health);

    }
}