using Biorama.Essentials;
using UnityEngine;

namespace Biorama.Popups
{
    public abstract class BasePopup<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static GameObject mPopupObject;

        private static T mInstance;

        public virtual void Show()
        {
            mPopupObject.SetActive(true);
            ServiceLocator.Instance.PopupCanvasTransform.gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            DestroyImmediate(mPopupObject);
            if(ServiceLocator.Instance.PopupCanvasTransform.childCount <= 0)
                ServiceLocator.Instance.PopupCanvasTransform.gameObject.SetActive(false);
        }

        public static T GetPopup(string aPopupName)
        {
            if(mInstance == null)
            {
                var prefabReference = ServiceLocator.Instance.PopupManager.GetPopup(aPopupName);
                mPopupObject = Instantiate(prefabReference, ServiceLocator.Instance.PopupCanvasTransform);
                mPopupObject.SetActive(false);
                mInstance = mPopupObject.GetComponent<T>();
            }

            return mInstance;
        }
    }
}
