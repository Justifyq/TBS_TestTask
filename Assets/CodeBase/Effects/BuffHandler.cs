using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Effects
{
    public class BuffHandler : IBuffHandler
    {
        public event Action<IBuff> BuffApplied;
        public IEnumerable<IBuff> ActiveBuffs => _acceptableBuffs.Select(b => b.Value).Where(b => b.TurnsRemaining > 0);
        
        private readonly Dictionary<Type, IBuff> _acceptableBuffs;

        public BuffHandler(IEnumerable<IBuff> acceptableSelfBuffs)
        {
            _acceptableBuffs = new Dictionary<Type, IBuff>();

            foreach (IBuff buff in acceptableSelfBuffs)
                _acceptableBuffs.Add(buff.GetType(), buff);
        }

        public void ApplyBuff<TBuff>(int turns) where TBuff : class, IBuff => 
            ApplyBuff(typeof(TBuff), turns);

        public void ApplyBuff(Type type, int turns)
        {
            if (!_acceptableBuffs.ContainsKey(type))
                return;
            
            var buff = _acceptableBuffs[type];

            buff.TurnsRemaining += turns;
            BuffApplied?.Invoke(buff);
        }
    }
}