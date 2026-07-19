using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class GlobalEventManager : MonoBehaviour
    {
        private readonly Dictionary<GlobalEventType, List<Action>> _subscribers = new();
        
        public void Subscribe(GlobalEventType eventType, Action callback)
        {
            if (_subscribers.TryGetValue(eventType, out List<Action> eventSubscribers))
                eventSubscribers.Add(callback);
            else
                _subscribers[eventType] = new List<Action> { callback };
        }

        public void Unsubscribe(GlobalEventType eventType, Action callback)
        {
            if (_subscribers.TryGetValue(eventType, out List<Action> eventSubscribers))
                eventSubscribers.Remove(callback);
            else
                Debug.LogError($"Trying to unsubscribe from unregistered event {eventType}");
        }

        public void Invoke(GlobalEventType eventType)
        {
            if (!_subscribers.TryGetValue(eventType, out List<Action> eventSubscribers))
                return;
            
            foreach (Action callback in eventSubscribers)
                callback?.Invoke();
        }
    }
}
