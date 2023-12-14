using Biorama.Essentials;
using Biorama.Popups;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Biorama.ScriptableAssets.Inventory
{
    [Serializable]
    public class InventoryData
    {
        public List<ItemData> CollectiblesList = new List<ItemData>();
    }

    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Inventory/UserInventory", fileName = "UserInventory")]
    public class UserInventory : ScriptableObject
    {
        #region Members
        [SerializeField]
        [CustomName("Inventory Data Json")]
        private TextAsset mInventoryDataJson;

        [SerializeField]
        [CustomName("Path")]
        private string mPath;

        private InventoryData mPlayerInventoryData;
        public InventoryData PlayerInventoryData => mPlayerInventoryData;
        
        #endregion

        #region Methods
        public void LoadInventoryData()
        {
            mPlayerInventoryData = JsonUtils.ParseToObject<InventoryData>(mInventoryDataJson);
            if(mPlayerInventoryData == null)
            {
                mPlayerInventoryData = new InventoryData();
            }

        }


        public void SaveInventoryData()
        {
            JsonUtils.ParseToJson(PlayerInventoryData, mPath);
        }

        public void AddItemData(ItemData aItem)
        {
            if(mPlayerInventoryData == null)
            {
                mPlayerInventoryData = new InventoryData();
            }

            var playerItem = GetItemData(ref PlayerInventoryData.CollectiblesList, aItem);
            
            if(playerItem != null)
            {
                playerItem.Amount++;
            }
            else
            {
                PlayerInventoryData.CollectiblesList.Add(aItem);
            }

            SaveInventoryData();
        }

        public void UpdateItemAmount(string aId, int aIncrement)
        {
            var playerItem = GetInventoryItemById(aId);
            
            if(playerItem != null)
            {
                playerItem.Amount += aIncrement;
                if(playerItem.Amount <= 0)
                {
                    for(int i = 0; i < PlayerInventoryData.CollectiblesList.Count; i++)
                    {
                        if(PlayerInventoryData.CollectiblesList[i].Id.Equals(aId))
                        {
                            PlayerInventoryData.CollectiblesList.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        public void RemoveItemData(ItemData aItem)
        {
            var playerItem = GetItemData(ref PlayerInventoryData.CollectiblesList, aItem);
            
            if(playerItem != null)
            {
                if(playerItem.Amount > 1)
                {
                    playerItem.Amount--;
                }
                else
                {
                    for(int i = 0; i < PlayerInventoryData.CollectiblesList.Count; i++)
                    {
                        if(PlayerInventoryData.CollectiblesList[i].Id.Equals(aItem.Id))
                        {
                            PlayerInventoryData.CollectiblesList.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        public ItemData GetItemData(ref List<ItemData> aList, ItemData aItemData)
        {
            for(int i = 0; i < aList.Count; i++)
            {
                if(aList[i].Id.Equals(aItemData.Id))
                    return aList[i];
            }

            return null;
        }

        public ItemData GetInventoryItemById(string aId)
        {
            for(int i = 0; i < PlayerInventoryData.CollectiblesList.Count; i++)
            {
                if(PlayerInventoryData.CollectiblesList[i].Id.Equals(aId))
                    return PlayerInventoryData.CollectiblesList[i];
            }
            return null;
        }

        public void ClearInventoryData()
        {
            PlayerInventoryData.CollectiblesList.Clear();
            SaveInventoryData();
        }
        #endregion
    }
}
