using System.Collections.Generic;
using System.Linq;

namespace GameLoop
{
    public class TargetFounder
    {
        private readonly IEnumerable<IUnit> _targetUnits;

        public TargetFounder(IEnumerable<IUnit> targetUnits)
        {
            _targetUnits = targetUnits;
        }

        public IUnit GetTarget() => _targetUnits.FirstOrDefault(u => u.Health > 0);
    }
}