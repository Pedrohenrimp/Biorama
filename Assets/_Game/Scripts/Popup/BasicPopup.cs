using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Biorama.Popups
{
    public class BasicPopup : BasePopup<BasicPopup>
    {
        private static readonly string PopupName = nameof(BasicPopup);

        public static BasicPopup Instance => GetPopup(PopupName);

    }
}
