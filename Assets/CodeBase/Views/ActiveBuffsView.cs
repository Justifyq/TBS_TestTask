using System.Collections.Generic;
using Effects;
using UnityEngine;

namespace Views
{
    public class ActiveBuffsView : MonoBehaviour
    {
        [SerializeField] private Transform container;
        
        private IEnumerable<IBuffHandler> _buffHandlers;
        private BuffViewFactory _factory;

        private readonly Dictionary<IBuff, BuffView> _buffViews = new();

        private void OnDestroy()
        {
            if (_buffHandlers == null)
                return;

            foreach (IBuffHandler handler in _buffHandlers) 
                handler.BuffApplied -= BuffHandler_OnBuffApplied;
        }

        public void Construct(IEnumerable<IBuffHandler> buffHandlers, BuffViewFactory factory)
        {
            _buffHandlers = buffHandlers;
            _factory = factory;
            
            if (_buffHandlers == null)
                return;

            foreach (IBuffHandler handler in _buffHandlers) 
                handler.BuffApplied += BuffHandler_OnBuffApplied;
        }

        private void BuffHandler_OnBuffApplied(IBuff buff)
        {
            if (!_buffViews.ContainsKey(buff)) 
                _buffViews.Add(buff, _factory.CreateBuffView(buff, container));
            
            _buffViews[buff].UpdateView();
        }
    }
}