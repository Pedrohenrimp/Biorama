using Biorama.Essentials;
using UnityEngine;

namespace Biorama.ScriptableAssets.Providers
{
    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Providers/Providers", fileName = "Providers")]
    public class Providers : ScriptableObject
    {
        #region Icon Providers
        [SerializeField]
        [CustomName("Collectible Icon Provider")]
        private CollectibleIconProvider mCollectibleIconProvider;
        public CollectibleIconProvider CollectibleIconProvider => mCollectibleIconProvider;
        #endregion
    }
}
