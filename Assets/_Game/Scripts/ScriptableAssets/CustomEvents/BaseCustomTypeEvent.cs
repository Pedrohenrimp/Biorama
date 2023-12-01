using System;

public abstract class BaseCustomTypeEvent<T> : BaseCustomEvent
{
        private Action<T> mAction;

        public void Raise(T aValue)
        {
            mAction?.Invoke(aValue);
        }

        public void Register(Action<T> aAction)
        {
            mAction += aAction;
        }

        public void Unregister(Action<T> aAction)
        {
            mAction -= aAction;
        }
}
