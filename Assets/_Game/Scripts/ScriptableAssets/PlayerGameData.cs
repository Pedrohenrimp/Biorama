using Biorama.Essentials;
using Biorama.ScriptableAssets.Book;
using UnityEngine;

namespace Biorama.ScriptableAssets.GameDatas
{
    public class GameData
    {
        public BiomeType CurrentBiome;
        public Vector3 PlayerPositon;
    }

    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/GameData/PlayerGameData", fileName = "PlayerGameData")]
    public class PlayerGameData : ScriptableObject
    {
        [SerializeField]
        [CustomName("Player Game Data Json")]
        private TextAsset mPlayerGameDataJson;

        private GameData mGameData;
        public GameData GameData => mGameData;

        private bool mHasSavedGame = false;
        public bool HasSavedGame => mHasSavedGame;

        #region Methods
        public void LoadGameData()
        {
            mGameData = JsonUtils.ParseToObject<GameData>(mPlayerGameDataJson);
            if(mGameData == null)
            {
                mGameData = new GameData();
                mHasSavedGame = false;
            }
            else
            {
                mHasSavedGame = true;
            }

        }

        public void ClearGameData()
        {
            mGameData = null;
            SaveGameData();
            mGameData = new GameData();
            mHasSavedGame = false;
        }

        public void SaveGameData()
        {
            JsonUtils.ParseToJson(GameData, mPlayerGameDataJson);
        }
        #endregion
    }
}
