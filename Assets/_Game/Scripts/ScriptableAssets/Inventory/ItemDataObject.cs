using System;
using UnityEngine;

namespace Biorama.ScriptableAssets.Inventory
{
    public enum ItemType
    {
        Collectible
    }

    [Serializable]
    public class ItemData
    {
        public string Id;
        public string Name;
        public string Description;
        public int Amount;
        public ItemType Type;
        public Sprite Icon;
    }

    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Inventory/ItemDataObject", fileName = "ItemDataObject")]
    public class ItemDataObject : ScriptableObject
    {
        public string Id;
        public string Name;
        public string Description;
        public int Amount;
        public ItemType Type;
        public Sprite Icon;

        public ItemData GetItemData()
        {
            return new ItemData()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Amount = this.Amount,
                Type = this.Type,
                Icon = this.Icon
            };
        }
    }
}
