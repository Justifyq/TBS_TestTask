using System;
using System.Collections.Generic;
using System.Linq;

namespace Effects
{
    public class DebuffApplier : IDebuffApplier
    {
        public IEnumerable<IDebuff> ActiveDebuffs => _acceptableDebuffs.Select(d => d.Value).Where(d => d.TurnsRemaining > 0);
        
        private readonly Dictionary<Type, IDebuff> _acceptableDebuffs;

        public DebuffApplier(IEnumerable<IDebuff> acceptableDebuffs)
        {
            _acceptableDebuffs = new Dictionary<Type, IDebuff>();

            foreach (IDebuff debuff in acceptableDebuffs) 
                _acceptableDebuffs.Add(debuff.GetType(), debuff);
        }

        public void ApplyDebuff<TDebuff>(int turns) where TDebuff : class, IDebuff => 
            ApplyDebuff(typeof(TDebuff), turns);

        public void ApplyDebuff(Type type, int turns)
        {
            if (!_acceptableDebuffs.ContainsKey(type))
                return;
            
            var buff = _acceptableDebuffs[type];
            
            if (buff.TurnsRemaining == 0)
                buff.ApplyEffect();

            buff.TurnsRemaining += turns;
        }
    }
}