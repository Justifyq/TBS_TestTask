using Controls;

namespace Views
{
    public class AttackButton : AbstractButtonView
    {
        private IPlayerAttack _playerAttack;

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            if (_playerAttack != null)
                _playerAttack.CanAttackStateUpdated -= PlayerAttack_OnCanAttackStateUpdated;
        }

        public void Construct(IPlayerAttack playerAttack)
        {
            _playerAttack = playerAttack;
            _playerAttack.CanAttackStateUpdated += PlayerAttack_OnCanAttackStateUpdated;
        }
        
        protected override void OnClick() => _playerAttack.Attack();
        private void PlayerAttack_OnCanAttackStateUpdated() => Button.interactable = _playerAttack.CanAttack;
    }
}