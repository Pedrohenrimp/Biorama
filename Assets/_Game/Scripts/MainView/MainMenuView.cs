using Biorama.Essentials;
using Biorama.Popups;
using UnityEngine;

namespace Biorama.View
{
    public class MainMenuView : MonoBehaviour
    {
        public void OnSettingsButtonClicked()
        {
            SettingsPopup.Instance.Show();
        }

        public void OnPlayButtonClicked()
        {
            ServiceLocator.Instance.CustomSceneManager.LoadScene(SceneType.PlayScene);
        }
    }
}
