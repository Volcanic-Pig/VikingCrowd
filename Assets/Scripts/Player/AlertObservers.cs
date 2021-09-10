using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AlertObservers : MonoBehaviour
    {
        private readonly List<Action> _callbacks = new List<Action>();

        public void AddObserver(Action callback)
        {
            _callbacks.Add(callback);
        }
        
        public void Alert()
        {
            foreach (Action action in _callbacks)
            {
                _callbacks.Remove(action); 
                action?.Invoke();
            }
        }

        public void ClearObservers()
        {
            _callbacks.Clear();
        }
    }
}
