using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace TowerDefence
{
    public class ObjectPoolBuilder<T> where T : MonoBehaviour
    {
        private Func<T> _createFunc = () => new GameObject().AddComponent<T>();
        private Action<T> _actionOnGet= obj => obj.gameObject.SetActive(true);
        private Action<T> _actionOnRelease = obj => obj.gameObject.SetActive(false);
        private Action<T> _actionOnDestroy= Object.Destroy;
        private bool _collectionCheck = true;
        private int _defaultCapacity = 10;
        private int _maxSize = 10000;

        private ObjectPoolBuilder() { }

        public ObjectPool<T> Build() =>
            new(_createFunc, _actionOnGet, _actionOnRelease, _actionOnDestroy,
                _collectionCheck, _defaultCapacity, _maxSize);

        public static ObjectPoolBuilder<T> FromPrefab(T prefab) =>
            new()
            {
                _createFunc = () => Object.Instantiate(prefab)
            };

        public ObjectPoolBuilder<T> SetCreateFunc(Func<T> func)
        {
            _createFunc = func;
            return this;
        }

        public ObjectPoolBuilder<T> SetActionOnGet(Action<T> action)
        {
            _actionOnGet = action;
            return this;
        }

        public ObjectPoolBuilder<T> SetActionOnRelease(Action<T> action)
        {
            _actionOnRelease = action;
            return this;
        }

        public ObjectPoolBuilder<T> SetActionOnDestroy(Action<T> action)
        {
            _actionOnDestroy = action;
            return this;
        }

        public ObjectPoolBuilder<T> SetCollectionCheck(bool check)
        {
            _collectionCheck = check;
            return this;
        }

        public ObjectPoolBuilder<T> SetDefaultCapacity(int capacity)
        {
            _defaultCapacity = capacity;
            return this;
        }

        public ObjectPoolBuilder<T> SetMaxSize(int size)
        {
            _maxSize = size;
            return this;
        }
    }
}