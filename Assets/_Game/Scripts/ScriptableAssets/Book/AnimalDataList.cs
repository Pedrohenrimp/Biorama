using UnityEngine;

namespace Biorama.ScriptableAssets.Book
{
    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Book/AnimalDataList", fileName = "AnimalDataList")]
    public class AnimalDataList : ScriptableObject
    {
        public AnimalObject blockedAnimalObject;
        public SerializableDictionary<string, AnimalObject> animalDataList = new SerializableDictionary<string, AnimalObject>();

        #region Methods
        public AnimalObject GetAnimalObject(string aId)
        {
            animalDataList.TryGetValue(aId, out AnimalObject animalObject);
            return animalObject;
        }

        public AnimalObject GetBlockedAnimalObject()
        {
            return blockedAnimalObject;
        }
        #endregion
    }
}
