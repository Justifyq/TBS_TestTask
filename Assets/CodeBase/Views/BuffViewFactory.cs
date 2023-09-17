using Effects;
using UnityEngine;

namespace Views
{
    public class BuffViewFactory
    {
        private readonly BuffView _prefab;

        public BuffViewFactory(BuffView prefab) => _prefab = prefab;

        public BuffView CreateBuffView(IBuff buff, Transform container) => Object.Instantiate(_prefab, container).Construct(buff);
    }
}