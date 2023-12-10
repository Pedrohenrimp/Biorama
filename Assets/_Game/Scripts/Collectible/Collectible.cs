using Biorama.Essentials;
using UnityEngine;

namespace Biorama.Collectibles
{
    public class Collectible : MonoBehaviour
    {
        #region Members
        public static System.Action OnCollectItem;

        [SerializeField]
        [CustomName("Item ID")]
        private string mItemId;
        #endregion

        #region Methods
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(Constants.PlayerTag))
            {
                OnCollect();
            }
        }

        private void OnCollect()
        {
            var itemDataObject = ServiceLocator.Instance.ItemDataList.GetItemDataObject(mItemId);
            ServiceLocator.Instance.UserInventory.AddItemData(itemDataObject.GetItemData());
            Destroy(gameObject);
            OnCollectItem?.Invoke();
        }
        #endregion
    }
}
