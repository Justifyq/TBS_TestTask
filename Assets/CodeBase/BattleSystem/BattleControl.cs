using Controls;
using GameLoop;

namespace BattleSystem
{
    public class BattleControl
    {
        private readonly ControllableUnits _controllableUnits;
        private readonly TargetFounder _targetFounder;

        public BattleControl(ControllableUnits controllableUnits, TargetFounder targetFounder)
        {
            _controllableUnits = controllableUnits;
            _targetFounder = targetFounder;
        }
        
        public void Attack() => _controllableUnits.ActiveUnit.DealDamage(_targetFounder.GetTarget());
    }
}