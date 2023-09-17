using System;

namespace Effects
{
    public  interface IEffect
    {
        event Action<IEffect> TurnsRemainingChanged; 
        public int TurnsRemaining { get; set; }
        void ApplyEffect();
    }
}