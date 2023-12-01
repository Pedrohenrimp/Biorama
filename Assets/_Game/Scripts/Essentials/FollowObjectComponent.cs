using Biorama.Events;
using UnityEngine;

namespace Biorama.Essentials
{
    public class FollowObjectComponent : MonoBehaviour
    {
        #region Members
        [SerializeField]
        [CustomName("On Moved Event Key")]
        private string mOnMovedEventKey;

        private TransformEvent mOnMovedEvent;
        public TransformEvent OnMovedEvent
        {
            get
            {
                if(mOnMovedEvent == null)
                    mOnMovedEvent = (TransformEvent) ServiceLocator.Instance.CustomEventProvider.GetEvent(mOnMovedEventKey);
                
                return mOnMovedEvent;
            }
        }
        #endregion

        #region Methods
        private void OnEnable()
        {
            OnMovedEvent.Register(SetCurrentPosition);
        }

        private void OnDisable()
        {
            OnMovedEvent.Unregister(SetCurrentPosition);
        }

        public void SetCurrentPosition(Transform aTransform)
        {
            transform.position = aTransform.position;
        }
        #endregion
    }
}
