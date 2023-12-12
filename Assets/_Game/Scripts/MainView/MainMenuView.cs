using Biorama.Essentials;
using Biorama.Popups;
using Biorama.ScriptableAssets.Book;
using UnityEngine;
using UnityEngine.UI;

namespace Biorama.View
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        [CustomName("Continue Button")]
        private Button mContinueButton;

        private void Start()
        {
            mContinueButton.interactable = ServiceLocator.Instance.PlayerGameData.HasSavedGame;
        }
        public void OnSettingsButtonClicked()
        {
            SettingsPopup.Instance.Show();
        }

        public void OnNewGameButtonClicked()
        {
            ServiceLocator.Instance.PlayerGameData.ClearGameData();
            ServiceLocator.Instance.UserInventory.ClearInventoryData();
            ServiceLocator.Instance.UserBook.ClearBookData();
            ServiceLocator.Instance.CurrentScene = SceneType.PlayScene;
            ServiceLocator.Instance.CustomSceneManager.LoadScene(SceneType.PlayScene);
            ServiceLocator.Instance.IsGamePlaying = true;
            ServiceLocator.Instance.CurrentBiome = BiomeType.Amazonia;
        }

        public void OnContinueButtonClicked()
        {
            ServiceLocator.Instance.CurrentScene = SceneType.PlayScene;
            ServiceLocator.Instance.CustomSceneManager.LoadScene(SceneType.PlayScene);
            ServiceLocator.Instance.IsGamePlaying = true;
            ServiceLocator.Instance.CurrentBiome = ServiceLocator.Instance.PlayerGameData.GameData.CurrentBiome;
        }
    }
}
