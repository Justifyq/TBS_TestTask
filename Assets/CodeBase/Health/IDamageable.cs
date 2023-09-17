using System;

namespace Health
{
    public interface IDamageable
    { 
        event Action<int, int> HealthChanged;
        void RecoverHealth(int health);
     
        int MaxHealth { get; }
        int Health { get; }
        void GetDamage(int damage);
    }
}