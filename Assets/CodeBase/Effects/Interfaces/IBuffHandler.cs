using System;
using System.Collections.Generic;

namespace Effects
{
    public interface IBuffHandler
    {
        event Action<IBuff> BuffApplied;
        
        IEnumerable<IBuff> ActiveBuffs { get; }

        void ApplyBuff<T>(int turns) where T : class, IBuff;

        void ApplyBuff(Type type, int turns);
    }
}