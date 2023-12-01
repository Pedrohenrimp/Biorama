using Biorama.Essentials;
using UnityEngine;


namespace Biorama.ScriptableAssets.CustomSettings
{
    public enum GameControl
    {
        MoveLeft,
        MoveRight,
        MoveUp,
        MoveDown,
        Jump,
        Inventory,
        Pause,
        Interact,
    }

    public class GameControlObject
    {
        public KeyCode MoveLeft;
        public KeyCode MoveRight;
        public KeyCode MoveUp;
        public KeyCode MoveDown;
        public KeyCode Jump;
        public KeyCode Inventory;
        public KeyCode Pause;
        public KeyCode Interact;
    }

    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/CustomSettings/CustomGameControl", fileName = "CustomGameControl")]
    public class CustomGameControl : ScriptableObject
    {
        public SerializableDictionary<GameControl, KeyCode> customGameControl = new SerializableDictionary<GameControl, KeyCode>();
        
        [SerializeField]
        private TextAsset customGameControlDataJson;

        [SerializeField]
        private TextAsset defaultGameControlDataJson;

        public KeyCode GetValue(GameControl aGameControl)
        {
            customGameControl.TryGetValue(aGameControl, out KeyCode value);
            return value;
        }

        public void Init()
        {
            var gameControlObj = JsonUtils.ParseToObject<GameControlObject>(customGameControlDataJson);
            
            SetControlByGameControlType(GameControl.Interact, gameControlObj.Interact);
            SetControlByGameControlType(GameControl.Inventory, gameControlObj.Inventory);
            SetControlByGameControlType(GameControl.Jump, gameControlObj.Jump);
            SetControlByGameControlType(GameControl.MoveDown, gameControlObj.MoveDown);
            SetControlByGameControlType(GameControl.MoveLeft, gameControlObj.MoveLeft);
            SetControlByGameControlType(GameControl.MoveRight, gameControlObj.MoveRight);
            SetControlByGameControlType(GameControl.MoveUp, gameControlObj.MoveUp);
            SetControlByGameControlType(GameControl.Pause, gameControlObj.Pause);
        }

        public void SetGameControl()
        {
            SaveCustomControlData(GetCurrentGameControlObject());
        }

        public void SetupDefaultGameControl()
        {
            var gameControlObj = JsonUtils.ParseToObject<GameControlObject>(defaultGameControlDataJson);
            
            SetControlByGameControlType(GameControl.Interact, gameControlObj.Interact);
            SetControlByGameControlType(GameControl.Inventory, gameControlObj.Inventory);
            SetControlByGameControlType(GameControl.Jump, gameControlObj.Jump);
            SetControlByGameControlType(GameControl.MoveDown, gameControlObj.MoveDown);
            SetControlByGameControlType(GameControl.MoveLeft, gameControlObj.MoveLeft);
            SetControlByGameControlType(GameControl.MoveRight, gameControlObj.MoveRight);
            SetControlByGameControlType(GameControl.MoveUp, gameControlObj.MoveUp);
            SetControlByGameControlType(GameControl.Pause, gameControlObj.Pause);

            SetGameControl();
        }

        public void SetControlByGameControlType(GameControl aControl, KeyCode aKeyCode)
        {
            customGameControl.Replace(aControl, aKeyCode);
        }

        private GameControlObject GetCurrentGameControlObject()
        {
            var gameControlObj = new GameControlObject();
            gameControlObj.Interact = GetKeyCodeByGameControl(GameControl.Interact);
            gameControlObj.Inventory = GetKeyCodeByGameControl(GameControl.Inventory);
            gameControlObj.Jump = GetKeyCodeByGameControl(GameControl.Jump);
            gameControlObj.MoveDown = GetKeyCodeByGameControl(GameControl.MoveDown);
            gameControlObj.MoveLeft = GetKeyCodeByGameControl(GameControl.MoveLeft);
            gameControlObj.MoveRight = GetKeyCodeByGameControl(GameControl.MoveRight);
            gameControlObj.MoveUp = GetKeyCodeByGameControl(GameControl.MoveUp);
            gameControlObj.Pause = GetKeyCodeByGameControl(GameControl.Pause);

            return gameControlObj;
        }

        private KeyCode GetKeyCodeByGameControl(GameControl aControl)
        {
            var foundValue = customGameControl.TryGetValue(aControl, out KeyCode keyCode);

            return foundValue ? keyCode : KeyCode.None;
        }

        private void SaveCustomControlData(GameControlObject aObject)
        {
            JsonUtils.ParseToJson(aObject, customGameControlDataJson);
        }
    }
}
