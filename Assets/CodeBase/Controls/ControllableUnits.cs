using System.Collections.Generic;
using System.Linq;

namespace Controls
{
    public class ControllableUnits
    { 
        public bool IsTeamAlive => Units.Any(u => u.Health > 0);

        public IUnit ActiveUnit => Units.FirstOrDefault(u => u.Health > 0);
        public IEnumerable<IUnit> Units { get; }

        private IUnit[] _aliveUnits;

        public ControllableUnits(IEnumerable<IUnit> units)
        {
            Units = units;
        }

        public void CallFinishTurn()
        {
            foreach (IUnit unit in Units) 
                unit.FinishTurn();
        }
    }
}