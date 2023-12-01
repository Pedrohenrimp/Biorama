using System;
using UnityEngine;

namespace Biorama.Events
{
    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Events/VoidEvent", fileName = "VoidEvent")]
    public class VoidEvent : BaseCustomEvent
    {
        private Action mVoidAction;

        public void Raise()
        {
            mVoidAction?.Invoke();
        }

        public void Register(Action aAction)
        {
            mVoidAction += aAction;
        }

        public void Unregister(Action aAction)
        {
            mVoidAction -= aAction;
        }
    }
}
