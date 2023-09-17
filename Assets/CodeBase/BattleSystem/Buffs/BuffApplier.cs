using System;
using System.Linq;
using Effects;
using Random = UnityEngine.Random;

namespace BattleSystem.Buffs
{
    public class BuffApplier
    {
        private const int MinBuffDurationInclusive = 1;
        private const int MaxBuffDurationExclusive = 4;
        
        private readonly int _maxUnitBuffs;

        public BuffApplier(int maxUnitBuffs = 2) => _maxUnitBuffs = maxUnitBuffs;

        public void GiveBuffToUnit(IUnit unit, Type buffType)
        {
            if (buffType.IsAssignableFrom(typeof(IBuff)) || !CanGiveBuff(unit))
                return;

            unit.ApplyBuff(buffType, Random.Range(MinBuffDurationInclusive, MaxBuffDurationExclusive));
        }

        public bool CanGiveBuff(IUnit unit) => unit?.ActiveBuffs.Count() < _maxUnitBuffs;
    }
}