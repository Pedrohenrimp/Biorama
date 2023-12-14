using Biorama.Essentials;
using Biorama.Popups;
using Biorama.Collectibles;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using Biorama.ScriptableAssets.Book;

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

        [SerializeField]
        [CustomName("Phase Manager")]
        private PhaseManager mPhaseManager;

        [SerializeField]
        [CustomName("Next Button")]
        private Button mNextButton;

        [SerializeField]
        [CustomName("Final Scene Object")]
        private GameObject mFinalSceneObject;

        [SerializeField]
        [CustomName("Final Player Animator")]
        private Animator mFinalPlayerAnimator;

        [SerializeField]
        [CustomName("Book Button Animator")]
        private Animator mBookButtonAnimator;

        [SerializeField]
        [CustomName("Transition Animator")]
        private Animator mTransitionAnimator;

        private bool mIsSettingsOpenned;

        private bool mCanGoNext;

        public static System.Action OnNextBiome;

        #endregion

        #region Methods
        private async void OnEnable()
        {
            mTransitionAnimator.gameObject.SetActive(true);

            Collectible.OnCollectItem += SetupCollectibleInfo;
            BookPopup.OnUnlockAnimal += SetupCollectibleInfo;
            SettingsPopup.OnHide += OnHideSettings;

            SetupCollectibleInfo();
            mPhaseManager.SetBiome(ServiceLocator.Instance.CurrentBiome);
            mNextButton.gameObject.transform.position = Helpers.GetNextButtonPositionByBiomeType(ServiceLocator.Instance.CurrentBiome);

            await Task.Delay(500);
            mTransitionAnimator.Play("FadeOut");
            await Task.Delay(300);
            mTransitionAnimator.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            Collectible.OnCollectItem -= SetupCollectibleInfo;
            BookPopup.OnUnlockAnimal -= SetupCollectibleInfo;
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

            if(mIsSettingsOpenned)
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
                mIsSettingsOpenned = true;
            }
            else
            {
                SettingsPopup.Instance.Hide();
                mIsSettingsOpenned = false;
            }
        }

        public async void OnHomeButtonClicked()
        {
            mTransitionAnimator.gameObject.SetActive(true);
            mTransitionAnimator.Play("FadeIn");
            ServiceLocator.Instance.SaveGameData();
            await Task.Delay(500);
            HidePauseContent();
            ServiceLocator.Instance.CurrentScene = SceneType.MainScene;
            ServiceLocator.Instance.CustomSceneManager.LoadScene(SceneType.MainScene);
        }

        public void SetupCollectibleInfo()
        {
            var currentBiome = ServiceLocator.Instance.CurrentBiome;
            mCollectibleIcon.sprite = ServiceLocator.Instance.Providers.CollectibleIconProvider.GetIconByBiomeType(currentBiome);
            var collectable = ServiceLocator.Instance.UserInventory.GetInventoryItemById(Helpers.GetCollectableIdByBiomeType(currentBiome));
            var amount = collectable != null ? collectable.Amount : 0;
            mCollectibleLabel.text = $"x{amount}";

            mCanGoNext = ServiceLocator.Instance.UserBook.PlayerBookData.AnimalList.Count >= ((int)currentBiome + 1) * 2;
            mNextButton.interactable = mCanGoNext;
            mBookButtonAnimator.enabled = HasEnoughToUnlock();
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
            mIsSettingsOpenned = false;
        }

        public async void LoadNextBiome()
        {
            if(mCanGoNext)
            {
                mTransitionAnimator.gameObject.SetActive(true);
                mTransitionAnimator.Play("FadeIn");
                await Task.Delay(300);
                
                ServiceLocator.Instance.CurrentBiome++;
                if(ServiceLocator.Instance.CurrentBiome != BiomeType.None)
                {
                    ServiceLocator.Instance.PlayerGameData.GameData.CurrentBiome = ServiceLocator.Instance.CurrentBiome;
                    ServiceLocator.Instance.PlayerGameData.ClearCollectiblesList();
                    ServiceLocator.Instance.PlayerGameData.SaveGameData();
                    SetupCollectibleInfo();
                    mPhaseManager.SetBiome(ServiceLocator.Instance.CurrentBiome);
                    OnNextBiome?.Invoke();
                    mNextButton.gameObject.transform.position = Helpers.GetNextButtonPositionByBiomeType(ServiceLocator.Instance.CurrentBiome);
                }
                else
                {
                    mFinalSceneObject.SetActive(true);
                    mFinalPlayerAnimator.Play("player_win");
                }

                await Task.Delay(500);
                mTransitionAnimator.Play("FadeOut");
                await Task.Delay(300);
                mTransitionAnimator.gameObject.SetActive(false);
            }
        }

        public async void OnCompleteGame()
        {
            mTransitionAnimator.gameObject.SetActive(true);
            mTransitionAnimator.Play("FadeIn");
            ServiceLocator.Instance.SaveGameData();
            ServiceLocator.Instance.PlayerGameData.ClearGameData();
            await Task.Delay(500);
            ServiceLocator.Instance.CurrentScene = SceneType.MainScene;
            ServiceLocator.Instance.CustomSceneManager.LoadScene(SceneType.MainScene);
        }

        private bool HasEnoughToUnlock()
        {
            var inventory = ServiceLocator.Instance.UserInventory.PlayerInventoryData.CollectiblesList;
            for(int i = 0; i < inventory.Count; i++)
            {
                if(inventory[i].Amount >= 3)
                    return true;
            }

            return false;
        }
        #endregion
    }
}
