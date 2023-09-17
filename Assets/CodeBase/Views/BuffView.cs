using Effects;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class BuffView : MonoBehaviour
    {
        [SerializeField] private Text buffName;
        [SerializeField] private Text turnsRemainingView;

        private IBuff _buff;

        private void OnDestroy()
        {
            if (_buff != null)
                _buff.TurnsRemainingChanged -= Buff_OnEffectRemoved;
        }

        public BuffView Construct(IBuff buff)
        {
            _buff = buff;
            buffName.text = buff.GetType().Name;
            _buff.TurnsRemainingChanged += Buff_OnEffectRemoved;

            return this;
        }

        public void UpdateView()
        {
            if (gameObject.activeSelf == false)
                gameObject.SetActive(true);
            
            turnsRemainingView.text = _buff.TurnsRemaining.ToString();
        }

        private void Buff_OnEffectRemoved(IEffect effect)
        {
            UpdateView();
            
            if (effect.TurnsRemaining == 0)
                gameObject.SetActive(false);
        }
    }
}