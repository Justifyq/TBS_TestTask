using System;
using System.Collections.Generic;

namespace Effects
{
    public interface IDebuffApplier
    {
        IEnumerable<IDebuff> ActiveDebuffs { get; }
        
        void ApplyDebuff<TDebuff>(int turns) where TDebuff : class, IDebuff;
        
        void ApplyDebuff(Type type, int turns);
    }
}