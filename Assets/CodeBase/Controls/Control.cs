using System;
using BattleSystem;
using BattleSystem.Buffs;
using GameLoop;
using GameLoop.Buffs;

namespace Controls
{
    public class Control : ITurnController, IPlayerAttack, IPlayerBuffApplier
    {
        public event Action Began;
        public event Action Finished;

        public event Action CanBuffApplyStateUpdated;
        public event Action CanAttackStateUpdated;
        
        public ControllableUnits Controllable { get; }
        public bool CanAttack => _canDealDamage && _target != null;
        public bool CanApplyBuff => _buffApplier.CanGiveBuff(Controllable?.ActiveUnit) && _canApplyBuff;
        
        private readonly BattleControl _battleControl;
        
        private readonly BuffsCollection _buffsCollection;
        private readonly BuffApplier _buffApplier;
        private readonly TargetFounder _targetFounder;

        private IUnit _target;

        private bool _canApplyBuff;
        private bool _canDealDamage;


        public Control(BuffsCollection buffsCollection, BuffApplier buffApplier,
            ControllableUnits controllable, TargetFounder targetFounder)
        {
            _buffsCollection = buffsCollection;
            _buffApplier = buffApplier;
            _targetFounder = targetFounder;
            _battleControl = new BattleControl(controllable, targetFounder);
            Controllable = controllable;
        }

        public void Begin()
        {
            _canApplyBuff = true;
            _canDealDamage = true;
            _target = _targetFounder.GetTarget();
            
            Began?.Invoke();
            CanAttackStateUpdated?.Invoke();
            CanBuffApplyStateUpdated?.Invoke();
        }

        public void Attack()
        {
            if (!CanAttack)
                return;
            
            _battleControl.Attack();
            _canDealDamage = false;

            if (CanApplyBuff)
            {
                _canApplyBuff = false;
                CanBuffApplyStateUpdated?.Invoke();
            }
            
            CanAttackStateUpdated?.Invoke();
            Finished?.Invoke();
        }

        public void ApplyBuff()
        {
            if (!CanApplyBuff)
                return;
            
            _buffApplier.GiveBuffToUnit(Controllable.ActiveUnit, _buffsCollection.GetRandomBuff());
            _canApplyBuff = false;
            
            CanBuffApplyStateUpdated?.Invoke();
        }
    }
}