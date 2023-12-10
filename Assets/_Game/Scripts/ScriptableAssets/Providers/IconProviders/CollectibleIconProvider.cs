using Biorama.ScriptableAssets.Book;
using UnityEngine;

namespace Biorama.ScriptableAssets.Providers
{
    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Providers/IconProvider/CollectibleIconProvider", fileName = "CollectibleIconProvider")]
    public class CollectibleIconProvider : ScriptableObject
    {
        public SerializableDictionary<BiomeType, Sprite> iconProvider = new SerializableDictionary<BiomeType, Sprite>();

        #region Methods
        public Sprite GetIconByBiomeType(BiomeType aBiome)
        {
            iconProvider.TryGetValue(aBiome, out Sprite icon);
            return icon;
        }
        #endregion
    }
}
