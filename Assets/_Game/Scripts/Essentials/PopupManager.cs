using System;
using UnityEngine;


namespace Biorama.Essentials
{
    public enum PopupType
    {
        GeneralPopup,
        BasicPopup,
        ConfirmationPoup,
        WarningPopup,
        SettingsPopup,
        BookPopup
    }

    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Popup/PopupManager", fileName = "PopupManager")]
    public class PopupManager : ScriptableObject
    {
        public SerializableDictionary<PopupType, GameObject> popupDataSet = new SerializableDictionary<PopupType, GameObject>();
        

        public GameObject GetPopup(string aPopupName)
        {
            GameObject obj;
            var popupType = (PopupType)Enum.Parse(typeof(PopupType), aPopupName);
            popupDataSet.TryGetValue(popupType, out obj);

            return obj;
        }
    }
}
