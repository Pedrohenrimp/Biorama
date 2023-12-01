using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Biorama.Popups
{
    public class SettingsPopup : BasePopup<SettingsPopup>
    {
        private static readonly string PopupName = nameof(SettingsPopup);

        public static SettingsPopup Instance => GetPopup(PopupName);

        private Action mOnConfirmationCallback;

        public void OnConfirmationClicked()
        {
            if(mOnConfirmationCallback != null)
                mOnConfirmationCallback?.Invoke();

            Debug.Log("Confirmation Clicked");
            Hide();
        }

        public void SetOnConfirmationCallback(Action aAction)
        {
            mOnConfirmationCallback = aAction;
        }
    }
}
