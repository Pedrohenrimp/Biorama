using UnityEngine;
using Biorama.ScriptableAssets.Book;
using System.Collections.Generic;

namespace Biorama.UI
{
    public class PhaseManager : MonoBehaviour
    {
        #region Members
        [SerializeField]
        private List<GameObject> BiomeViews;

        [SerializeField]
        private List<GameObject> BiomeCollectibles;

        #endregion

        #region Methods
        public void SetBiome(BiomeType aBiomeType)
        {
            for(int i = 0; i < BiomeViews.Count; i++)
            {
                BiomeViews[i].SetActive(i == (int)aBiomeType);
            }

            for(int i = 0; i < BiomeCollectibles.Count; i++)
            {
                BiomeCollectibles[i].SetActive(i == (int)aBiomeType);
            }
        }
        #endregion
    }
}
