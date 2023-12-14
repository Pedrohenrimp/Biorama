using Biorama.Essentials;
using Biorama.ScriptableAssets.Book;
using System.Collections.Generic;
using UnityEngine;

namespace Biorama.ScriptableAssets.GameDatas
{
    public class GameData
    {
        public BiomeType CurrentBiome;
        public Vector3 PlayerPositon;
        public List<int> Collectibles;
    }

    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/GameData/PlayerGameData", fileName = "PlayerGameData")]
    public class PlayerGameData : ScriptableObject
    {
        [SerializeField]
        [CustomName("Player Game Data Json")]
        private TextAsset mPlayerGameDataJson;

        [SerializeField]
        [CustomName("Path")]
        private string mPath;

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
            JsonUtils.ParseToJson(GameData, mPath);
            mHasSavedGame = true;
        }

        public void AddCollectible(int aValue)
        {
            if(GameData.Collectibles == null)
                GameData.Collectibles = new List<int>();

            GameData.Collectibles.Add(aValue);
            SaveGameData();
        }

        public void ClearCollectiblesList()
        {
            if(GameData.Collectibles != null)
                GameData.Collectibles.Clear();
            else
                GameData.Collectibles = new List<int>();
        }

        public bool ContainsCollectible(int aValue)
        {
            if(GameData.Collectibles == null)
                return false;

            return GameData.Collectibles.Contains(aValue);
        }
        #endregion
    }
}
