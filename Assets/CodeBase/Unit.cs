using System;
using System.Collections.Generic;
using AttackEffects;
using Damage;
using Effects;
using Health;
using UnityEngine;

public class Unit : MonoBehaviour, IUnit
{
    public event Action<int, int> HealthChanged
    {
        add => _damageable.HealthChanged += value;
        remove => _damageable.HealthChanged -= value;
    }

    public event Action<IUnit> DamageDealing
    {
        add => _damageDealer.DamageDealing += value;
        remove => _damageDealer.DamageDealing -= value;
    }

    public event Action<int> DamageDealt
    {
        add => _damageDealer.DamageDealt += value;
        remove => _damageDealer.DamageDealt -= value;
    }
    
    public event Action<IBuff> BuffApplied
    {
        add => _buffHandler.BuffApplied += value;
        remove => _buffHandler.BuffApplied -= value;
    }
    
    public IEnumerable<IDebuff> ActiveDebuffs => _debuffApplier.ActiveDebuffs;
    public IEnumerable<IBuff> ActiveBuffs => _buffHandler.ActiveBuffs;

    public int MaxHealth => _damageable.MaxHealth;
    public int Health => _damageable.Health;
    public ArmorSystem ArmorSystem { get; private set; }

    private IDamageable _damageable;
    private IDamageDealer _damageDealer;
    private IBuffHandler _buffHandler;
    private IDebuffApplier _debuffApplier;

    private void Awake()
    {
        ArmorSystem = new ArmorSystem();
        var damageMultiply = new DamageMultiplier();
        
        _damageable = new HealthSystem(ArmorSystem);
        _damageDealer = new DamageSystem(damageMultiply);
        
        var vampireSystem = new VampireSystem(_damageable, _damageDealer);

        _buffHandler = new BuffHandler(new IBuff[]
        {
            new VampireBuff(ArmorSystem, vampireSystem),
            new VampireDecreaseBuff(_damageDealer),
            new ArmorSelfBuff(ArmorSystem),
            new ArmorDecreaseBuff(_damageDealer),
            new DoubleDamageBuff(damageMultiply),
        });

        _debuffApplier = new DebuffApplier(new IDebuff[]
        {
            new ArmorReduceDebuff(ArmorSystem),
            new VampireDecreaseDebuff(vampireSystem),
        });

    }

    public void GetDamage(int damage) => _damageable.GetDamage(damage);
    
    public void DealDamage(IUnit unit) => _damageDealer.DealDamage(unit);

    public void RecoverHealth(int health) => _damageable.RecoverHealth(health);
    
    public void ApplyBuff<T>(int turns) where T : class, IBuff => 
        _buffHandler.ApplyBuff<T>(turns);

    public void ApplyBuff(Type type, int turns) => _buffHandler.ApplyBuff(type, turns);

    public void ApplyDebuff<TDebuff>(int turns) where TDebuff : class, IDebuff =>
        _debuffApplier.ApplyDebuff<TDebuff>(turns);

    public void ApplyDebuff(Type type, int turns) => 
        _debuffApplier.ApplyDebuff(type, turns);

    public void FinishTurn()
    {
        foreach (IBuff buff in ActiveBuffs) 
            buff.TurnsRemaining--;
        
        foreach (IDebuff buff in ActiveDebuffs) 
            buff.TurnsRemaining--;
    }
}