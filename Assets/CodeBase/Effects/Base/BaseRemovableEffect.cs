using System;

namespace Effects
{
    public abstract class BaseRemovableEffect : IEffect, IRemovableEffect
    {
        public event Action<IEffect> TurnsRemainingChanged;

        public int TurnsRemaining        
        {
            get => _turnsRemaining;
            set
            {
                if (_turnsRemaining == 0 && value < 0 || value == _turnsRemaining)
                    return;

                if (_turnsRemaining >= 0 && value <= 0) 
                    RemoveEffect();

                if (_turnsRemaining <= 0 && value > 0) 
                    ApplyEffect();

                _turnsRemaining = value < 0 ? 0 : value;
                
                TurnsRemainingChanged?.Invoke(this);
            }
        }

        private int _turnsRemaining;
        
        public abstract void ApplyEffect();
        public abstract void RemoveEffect();
    }
}