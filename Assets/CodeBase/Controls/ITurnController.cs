using System;

namespace Controls
{
    public interface ITurnController
    {
        event Action Began; 
        event Action Finished;
        void Begin();
    }
}