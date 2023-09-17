using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButtonView : MonoBehaviour
    {
        protected Button Button;

        protected virtual void Awake()
        {
            Button = GetComponent<Button>();
            Button.onClick.AddListener(OnClick);
        }

        protected virtual void OnDestroy() => Button.onClick.RemoveListener(OnClick);

        protected abstract void OnClick();
    }
}