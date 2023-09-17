using System;
using Damage;
using Health;

namespace AttackEffects
{
    public class VampireSystem : IVampireSystem, IDisposable
    {
        public int AdditionalVampire { get; set; }
        public int ReduceVampire { get; set; }

        public int Vampire
        {
            get
            {
                int vampire = _baseVampire + AdditionalVampire - ReduceVampire;

                if (vampire < 0)
                    vampire = 0;

                if (vampire > 0)
                {
                    
                }

                return vampire;
            }
        }

        private readonly IDamageable _damageable;
        private readonly IDamageDealer _damageDealer;
        private readonly int _baseVampire;
        
        public VampireSystem(IDamageable damageable, IDamageDealer damageDealer, int baseVampire = 0)
        {
            _damageable = damageable;
            _damageDealer = damageDealer;
            _baseVampire = baseVampire;

            _damageDealer.DamageDealt += ApplyVampire;
        }

        public void ApplyVampire(int damage)
        {
            int toRecover = CalculateVampire(damage);

            if (toRecover > 0)
                _damageable.RecoverHealth(toRecover);
        }
        
        public void Dispose() => _damageDealer.DamageDealt -= ApplyVampire;

        private int CalculateVampire(int damage) => (int)(damage * Vampire.Normalize());

        ~VampireSystem() => Dispose();
    }
}