using Biorama.Essentials;
using Biorama.ScriptableAssets.Book;
using Biorama.UI.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Biorama.ScriptableAssets.UI
{
    public class CutScenePageListHandler : MonoBehaviour
    {
        public List<GameObject> pageList = new List<GameObject>();

        private int mCurrentPage = 0;
        #region Methods
        public void GetNextPage()
        {
            mCurrentPage++;
            if(mCurrentPage < pageList.Count)
            {
                for(int i = 0; i < pageList.Count; i++)
                {
                    if(i == mCurrentPage)
                    {
                        pageList[i].SetActive(true);
                    }
                    else
                    {
                        pageList[i].SetActive(false);
                    }
                }
            }
            else
            {
                OnNewGameButtonClicked();
            }
        }

        public async void OnNewGameButtonClicked()
        {
            ServiceLocator.Instance.PlayerGameData.ClearGameData();
            ServiceLocator.Instance.UserInventory.ClearInventoryData();
            ServiceLocator.Instance.UserBook.ClearBookData();
            await Task.Delay(200);
            ServiceLocator.Instance.CurrentScene = SceneType.PlayScene;
            ServiceLocator.Instance.CustomSceneManager.LoadScene(SceneType.PlayScene);
            ServiceLocator.Instance.IsGamePlaying = true;
            ServiceLocator.Instance.CurrentBiome = BiomeType.Amazonia;
        }
        #endregion
    }
}
