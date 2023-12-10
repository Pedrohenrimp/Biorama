using Biorama.Essentials;
using Biorama.Popups;
using Biorama.Collectibles;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Biorama.UI
{
    public class InGameUIManager : MonoBehaviour
    {
        #region Members
        [SerializeField]
        [CustomName("Pause Content")]
        private GameObject mPauseContent;

        [SerializeField]
        [CustomName("Pause Background Image")]
        private Image mPauseBackgroundImage;

        [SerializeField]
        [CustomName("Collectible Icon")]
        private Image mCollectibleIcon;

        [SerializeField]
        [CustomName("Collectible Label")]
        private TextMeshProUGUI mCollectibleLabel;

        [SerializeField]
        [CustomName("Collectible Content")]
        private GameObject mCollectibleContent;

        [SerializeField]
        [CustomName("Book Button")]
        private GameObject mBookButton;

        #endregion

        #region Methods
        private void OnEnable()
        {
            Collectible.OnCollectItem += SetupCollectibleInfo;
            SettingsPopup.OnHide += OnHideSettings;

            SetupCollectibleInfo();
        }

        private void OnDisable()
        {
            Collectible.OnCollectItem -= SetupCollectibleInfo;
            SettingsPopup.OnHide -= OnHideSettings;
        }

        public void OnBookButtonClicked()
        {
            if(!BookPopup.Instance.isActiveAndEnabled)
            {
                BookPopup.Instance.Show();
            }
            else
            {
                BookPopup.Instance.Hide();
            }
        }

        public void OnPauseButtonClicked()
        {
            ShowPauseContent();
        }

        public void OnPlayButtonClicked()
        {

            if(SettingsPopup.Instance.isActiveAndEnabled)
            {
                SettingsPopup.Instance.Hide();
            }

            HidePauseContent();
        }

        public void OnSettingsButtonClicked()
        {
            if(!SettingsPopup.Instance.isActiveAndEnabled)
            {
                SettingsPopup.Instance.Show(OptionsType.InGameOptions);
                mPauseBackgroundImage.enabled = false;
                mCollectibleContent.SetActive(false);
                mBookButton.SetActive(false);
            }
            else
            {
                SettingsPopup.Instance.Hide();
            }
        }

        public void OnHomeButtonClicked()
        {
            //ServiceLocator.Instance.SavingService.SaveCurrentSession();
            HidePauseContent();
            ServiceLocator.Instance.CustomSceneManager.LoadScene(SceneType.MainScene);
        }

        public void SetupCollectibleInfo()
        {
            var currentBiome = ServiceLocator.Instance.CurrentBiome;
            mCollectibleIcon.sprite = ServiceLocator.Instance.Providers.CollectibleIconProvider.GetIconByBiomeType(currentBiome);
            var collectable = ServiceLocator.Instance.UserInventory.GetInventoryItemById(Helpers.GetCollectableIdByBiomeType(currentBiome));
            var amount = collectable != null ? collectable.Amount : 0;
            mCollectibleLabel.text = $"x{amount}";
        }

        public void ShowPauseContent()
        {
            ServiceLocator.Instance.PauseGame(true);
            mPauseContent.SetActive(true);
            mPauseBackgroundImage.enabled = true;
        }

        public void HidePauseContent()
        {
            ServiceLocator.Instance.PauseGame(false);
            mPauseContent.SetActive(false);
            mPauseBackgroundImage.enabled = false;
        }

        public void OnHideSettings()
        {
            mCollectibleContent.SetActive(true);
            mBookButton.SetActive(true);
            ShowPauseContent();
        }
        #endregion
    }
}
