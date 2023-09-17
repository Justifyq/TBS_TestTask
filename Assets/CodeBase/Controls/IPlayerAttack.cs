using System;

namespace Controls
{
    public interface IPlayerAttack
    {
        event Action CanAttackStateUpdated;  
        bool CanAttack { get; }
        void Attack();
    }
}