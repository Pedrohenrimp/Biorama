using Biorama.Essentials;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Biorama.ScriptableAssets.Book
{
    [Serializable]
    public class BookData
    {
        public List<AnimalData> AnimalList = new List<AnimalData>();
    }

    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Book/UserBook", fileName = "UserBook")]
    public class UserBook : ScriptableObject
    {
        #region Members
        [SerializeField]
        [CustomName("Animal Data Json")]
        private TextAsset mAnimalDataJson;

        private BookData mPlayerBookData;
        public BookData PlayerBookData => mPlayerBookData;
        
        #endregion

        #region Methods
        public void LoadBookData()
        {
            mPlayerBookData = JsonUtils.ParseToObject<BookData>(mAnimalDataJson);
            if(mPlayerBookData == null)
            {
                mPlayerBookData = new BookData();
            }

        }


        public void SaveBookData()
        {
            JsonUtils.ParseToJson(PlayerBookData, mAnimalDataJson);
        }

        public void AddAnimalData(AnimalData aAnimal)
        {
            if(mPlayerBookData == null)
            {
                mPlayerBookData = new BookData();
            }

            var playerAnimal = GetAnimalData(ref mPlayerBookData.AnimalList, aAnimal);
            
            if(playerAnimal == null)
            {
                mPlayerBookData.AnimalList.Add(aAnimal);
            }

            SaveBookData();
        }

        public void RemoveAnimalData(AnimalData aAnimalData)
        {
            var playerItem = GetAnimalData(ref mPlayerBookData.AnimalList, aAnimalData);
            
            if(playerItem != null)
            {
                for(int i = 0; i < mPlayerBookData.AnimalList.Count; i++)
                {
                    if(mPlayerBookData.AnimalList[i].Id.Equals(aAnimalData.Id))
                    {
                        mPlayerBookData.AnimalList.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public AnimalData GetAnimalData(ref List<AnimalData> aList, AnimalData aAnimalData)
        {
            for(int i = 0; i < aList.Count; i++)
            {
                if(aList[i].Id.Equals(aAnimalData.Id))
                    return aList[i];
            }

            return null;
        }

        public bool ContainsAnimal(AnimalData aAnimalData)
        {
            return GetAnimalData(ref mPlayerBookData.AnimalList, aAnimalData) != null;
        }
        #endregion
    }
}
