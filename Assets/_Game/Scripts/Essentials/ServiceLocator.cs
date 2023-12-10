using Biorama.CameraManagement;
using Biorama.Events;
using Biorama.Player;
using Biorama.ScriptableAssets.CustomSettings;
using UnityEngine;
using Biorama.ScriptableAssets.Inventory;
using Biorama.Popups;
using Biorama.ScriptableAssets.Book;
using Biorama.ScriptableAssets.Providers;

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

        [SerializeField]
        [CustomName("Player Book")]
        private UserBook mUserBook;
        public UserBook UserBook => mUserBook;

        [SerializeField]
        [CustomName("Animal Data List")]
        private AnimalDataList mAnimalDataList;
        public AnimalDataList AnimalDataList => mAnimalDataList;

        [SerializeField]
        [CustomName("Book Page List")]
        private BookPageList mBookPageList;
        public BookPageList BookPageList => mBookPageList;

        [SerializeField]
        [CustomName("Providers")]
        private Providers mProviders;
        public Providers Providers => mProviders;
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

        private BiomeType currentBiome = BiomeType.Amazonia;
        public BiomeType CurrentBiome
        {
            get => currentBiome;
            set => currentBiome = value;
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

        public void PauseGame(bool aPause)
        {
            isGamePaused = aPause;
            isGamePlaying = !aPause;
        }
    }
}
