using Biorama.CameraManagement;
using Biorama.Events;
using Biorama.Player;
using Biorama.ScriptableAssets.CustomSettings;
using UnityEngine;
using Biorama.ScriptableAssets.Inventory;
using Biorama.Popups;
using Biorama.ScriptableAssets.Book;
using Biorama.ScriptableAssets.Providers;
using Biorama.ScriptableAssets.GameDatas;

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
        public Transform PopupCanvasTransform
        {
            get
            {
                if(mPopupCanvas == null)
                {
                    Canvas[] canvas = FindObjectsOfType<Canvas>(true);
                    for(int i = 0; i < canvas.Length; i++)
                    {
                        if(canvas[i].gameObject.name.Equals("PopupCanvas"))
                        {
                            mPopupCanvas = canvas[i].gameObject.transform;
                            break;
                        }
                    }
                    
                }
                return mPopupCanvas;
            }
        }

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

        [SerializeField]
        [CustomName("Player Game Data")]
        private PlayerGameData mPlayerGameData;
        public PlayerGameData PlayerGameData => mPlayerGameData;
        #endregion

        #region Primitive Attributes
        [SerializeField]
        private bool isGamePlaying = true;
        public bool IsGamePlaying
        {
            get => isGamePlaying;
            set => isGamePlaying = value;
        }

        [SerializeField]
        private bool isGamePaused = false;
        public bool IsGamePaused
        {
            get => isGamePaused;
            set => isGamePaused = value;
        }

        [SerializeField]
        private bool isInventoryOpenned = false;
        public bool IsInventoryOpenned
        {
            get => isInventoryOpenned;
            set => isInventoryOpenned = value;
        }

        [SerializeField]
        private BiomeType currentBiome = BiomeType.None;
        public BiomeType CurrentBiome
        {
            get => currentBiome;
            set => currentBiome = value;
        }

        [SerializeField]
        private SceneType currentScene = SceneType.MainScene;
        public SceneType CurrentScene
        {
            get => currentScene;
            set => currentScene = value;
        }
        #endregion

        #region Methods
        private void OnEnable()
        {
            UserInventory.LoadInventoryData();
            PlayerGameData.LoadGameData();
            UserBook.LoadBookData();
        }

        private void OnApplicationQuit()
        {
            PlayerGameData.SaveGameData();
            UserInventory.SaveInventoryData();
            UserBook.SaveBookData();
        }

        private void OnDestroy()
        {
            if(CurrentScene == SceneType.PlayScene)
            {
                PlayerGameData.SaveGameData();
                UserInventory.SaveInventoryData();
                UserBook.SaveBookData();
            }
        }

        public void PauseGame(bool aPause)
        {
            isGamePaused = aPause;
            isGamePlaying = !aPause;
        }

        public void SaveGameData()
        {
            if(CurrentScene == SceneType.PlayScene)
            {
                PlayerGameData.GameData.CurrentBiome = CurrentBiome;
                PlayerGameData.GameData.PlayerPositon = PlayerInputController.gameObject.transform.position;
                PlayerGameData.SaveGameData();
            }
        }

        public void SetPlayerInputController(PlayerInputController aPlayerInputController)
        {
            mPlayerInputController = aPlayerInputController;
        }

        public void SetCameraFollow(CameraFollow aCameraFollow)
        {
            mCameraFollow = aCameraFollow;
        }
        #endregion
    }
}
