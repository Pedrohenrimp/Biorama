using UnityEngine;

namespace Biorama.ScriptableAssets.Inventory
{
    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Inventory/ItemDataList", fileName = "ItemDataList")]
    public class ItemDataList : ScriptableObject
    {
        public SerializableDictionary<string, ItemDataObject> itemDataList = new SerializableDictionary<string, ItemDataObject>();

        #region Methods
        public ItemDataObject GetItemDataObject(string aId)
        {
            itemDataList.TryGetValue(aId, out ItemDataObject itemDataObject);
            return itemDataObject;
        }
        #endregion
    }
}
