using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Biorama.Popups
{
    public class GeneralPopup : BasePopup<GeneralPopup>
    {
        private static readonly string PopupName = nameof(GeneralPopup);

        public static GeneralPopup Instance => GetPopup(PopupName);

        public void FazNada(){}
    }
}
