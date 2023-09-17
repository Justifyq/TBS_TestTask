using System;

namespace Controls
{
    public interface IPlayerBuffApplier
    {
        event Action CanBuffApplyStateUpdated;

        bool CanApplyBuff { get; }
        void ApplyBuff();
    }
}