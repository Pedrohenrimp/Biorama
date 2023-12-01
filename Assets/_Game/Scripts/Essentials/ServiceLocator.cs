using Biorama.CameraManagement;
using Biorama.Events;
using Biorama.Player;
using Biorama.ScriptableAssets.CustomSettings;
using UnityEngine;
using Biorama.ScriptableAssets.Inventory;
using Biorama.Popups;

namespace Biorama.Essentials
{
    public class ServiceLocator : Singleton<ServiceLocator>
    {
        #region Objects
        [SerializeField]
        [CustomName("Custom Game Control")]
        private CustomGameControl mCustomGameControl;
        public CustomGameControl CustomGameControl => mCustomGameControl;

        [SerializeField]
        [CustomName("Popup Manager")]
        private PopupManager mPopupManager;
        public PopupManager PopupManager => mPopupManager;

        [SerializeField]
        [CustomName("Popup Canvas")]
        private Transform mPopupCanvas;
        public Transform PopupCanvasTransform => mPopupCanvas;

        [SerializeField]
        [CustomName("Custom Scene Manager")]
        private CustomSceneManager mCustomSceneManager;
        public CustomSceneManager CustomSceneManager => mCustomSceneManager;

        [SerializeField]
        [CustomName("Custom Event Provider")]
        private CustomEventProvider mCustomEventProvider;
        public CustomEventProvider CustomEventProvider => mCustomEventProvider;

        [SerializeField]
        [CustomName("Camera Follow")]
        private CameraFollow mCameraFollow;
        public CameraFollow CameraFollow => mCameraFollow;

        [SerializeField]
        [CustomName("Player Input Controller")]
        private PlayerInputController mPlayerInputController;
        public PlayerInputController PlayerInputController => mPlayerInputController;

        [SerializeField]
        [CustomName("Player Inventory")]
        private UserInventory mUserInventory;
        public UserInventory UserInventory => mUserInventory;

        [SerializeField]
        [CustomName("Item Data List")]
        private ItemDataList mItemDataList;
        public ItemDataList ItemDataList => mItemDataList;
        #endregion

        #region Primitive Attributes
        private bool isGamePlaying = true;
        public bool IsGamePlaying
        {
            get => isGamePlaying;
            set => isGamePlaying = value;
        }

        private bool isGamePaused = false;
        public bool IsGamePaused
        {
            get => isGamePaused;
            set => isGamePaused = value;
        }

        private bool isInventoryOpenned = false;
        public bool IsInventoryOpenned
        {
            get => isInventoryOpenned;
            set => isInventoryOpenned = value;
        }
        #endregion

        private void Start()
        {
            UserInventory.LoadInventoryData();
        }

        private void OnApplicationQuit()
        {
            UserInventory.SaveInventoryData();
        }

        private void OnDestroy()
        {
            UserInventory.SaveInventoryData();
        }


        public void OpenBook()
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
    }
}
