using UnityEngine;

namespace Biorama.ScriptableAssets.Book
{
    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Book/BookPageList", fileName = "BookPageList")]
    public class BookPageList : ScriptableObject
    {
        public SerializableDictionary<BiomeType, BookPageObject> pageList = new SerializableDictionary<BiomeType, BookPageObject>();

        #region Methods
        public BookPageObject GetPageObject(BiomeType aBiomeType)
        {
            pageList.TryGetValue(aBiomeType, out BookPageObject pageObject);
            return pageObject;
        }
        #endregion
    }
}
