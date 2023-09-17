using Controls;

namespace Views
{
    public class ApplyBuffButton : AbstractButtonView
    {
        private IPlayerBuffApplier _playerBuffApplier;

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            if (_playerBuffApplier != null)
                _playerBuffApplier.CanBuffApplyStateUpdated -= PlayerBuffApplier_OnCanBuffApplyStateUpdated;
        }

        public void Construct(IPlayerBuffApplier playerBuffApplier)
        {
            _playerBuffApplier = playerBuffApplier;
            _playerBuffApplier.CanBuffApplyStateUpdated += PlayerBuffApplier_OnCanBuffApplyStateUpdated;
        }

        protected override void OnClick() => _playerBuffApplier.ApplyBuff();
        private void PlayerBuffApplier_OnCanBuffApplyStateUpdated() => Button.interactable = _playerBuffApplier.CanApplyBuff;
    }
}