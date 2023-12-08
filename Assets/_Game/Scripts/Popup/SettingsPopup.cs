using Biorama.Essentials;
using Biorama.Popups.Book;
using Biorama.ScriptableAssets.Book;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Biorama.Popups
{
    public enum OptionsType
    {
        MainOptions,
        InGameOptions
    }
    public class SettingsPopup : BasePopup<SettingsPopup>
    {
        private static readonly string PopupName = nameof(SettingsPopup);

        public static SettingsPopup Instance => GetPopup(PopupName);

        #region Members
        [SerializeField]
        [CustomName("Audio Plus Button")]
        private Button mAudioPlusButton;

        [SerializeField]
        [CustomName("Audio Minus Button")]
        private Button mAudioMinusButton;

        [SerializeField]
        [CustomName("Home Button")]
        private GameObject mHomeButton;

        [SerializeField]
        [CustomName("Hide Button")]
        private GameObject mHideButton;
        #endregion

        #region Methods
        public void Show(OptionsType aOptionsType = OptionsType.MainOptions)
        {
            SetupCloseButtons(aOptionsType);

            base.Show();  
        }

        public override void Hide()
        {
            base.Hide();
        }

        public void OnInfoButtonClicked()
        {

        }

        public void OnControlsButtonClicked()
        {

        }

        public void OnContactButtonClicked()
        {

        }

        public void OnAudioButtonClicked()
        {

        }

        public void OnAudioMinusButtonClicked()
        {

        }

        public void OnAudioPlusButtonClicked()
        {

        }

        public void OnHomeButtonClicked()
        {
            Hide();
        }

        public void OnCloseButtonClicked()
        {
            Hide();
        }

        private void SetupCloseButtons(OptionsType aOptionsType)
        {
            mHomeButton.SetActive(aOptionsType == OptionsType.MainOptions);
            mHideButton.SetActive(aOptionsType == OptionsType.InGameOptions);
        }
        #endregion
    }
}
