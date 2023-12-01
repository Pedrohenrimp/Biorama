using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Biorama.Popups
{
    public class ConfirmationPopup : BasePopup<ConfirmationPopup>
    {
        private static readonly string PopupName = nameof(ConfirmationPopup);

        public static ConfirmationPopup Instance => GetPopup(PopupName);

        public void FazNada(){}
    }
}
