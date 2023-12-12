using System.IO;
using UnityEditor;
using UnityEngine;

namespace Biorama.Essentials
{
    public static class Constants
    {
        #region Player Constants
        public static readonly string PlayerTag = "Player";
        #endregion

        #region Animation Constants
        public static readonly string BookLeftToRightAnimaitonName = "BookLeftToRight";
        public static readonly string BookRightToLeftAnimaitonName = "BookRightToLeft";
        public static readonly string BookOpenBookAnimaitonName = "OpenBook";
        public static readonly string BookHideBookAnimaitonName = "HideBook";
        public static readonly string BookNoneAnimaitonName = "None";
        #endregion

        #region Limits Constants
        public static readonly int CollectableRequirimentAmount = 3;
        #endregion

        #region Biome Colletible Constants
        public static readonly string AmazoniaCollectible = "COLL_WOOD_AM";
        public static readonly string MataAtlanticaCollectible = "COLL_FLOWER_MA";
        public static readonly string PantanalCollectible = "COLL_WATER_PN";
        public static readonly string CaatingaCollectible = "COLL_MUD_CA";
        public static readonly string CerradoCollectible = "COLL_BRANCH_CE";
        public static readonly string PampaCollectible = "COLL_GRASS_PA";
        #endregion 


        #region Next Button Position
        public static readonly Vector2 AmazoniaNextPositon = new Vector2(150, -3.6f);
        public static readonly Vector2 MataAtlanticaNextPosition = new Vector2(150, -1.8f);
        public static readonly Vector2 PantanalNextPosition = new Vector2(150, -1f);
        public static readonly Vector2 CaatingaNextPosition = new Vector2(150, -3f);
        public static readonly Vector2 CerradoNextPosition = new Vector2(150, -3.6f);
        public static readonly Vector2 PampaNextPosition = new Vector2(150, -3f);
        #endregion

        #region Player Spawn Position
        public static readonly Vector3 AmazoniaSpawnPositon = new Vector3(-6, -5.25f, 0);
        public static readonly Vector3 MataAtlanticaSpawnPositon = new Vector3(-6, -3.25f, 0);
        public static readonly Vector3 PantanalSpawnPositon = new Vector3(-6, -3f, 0);
        public static readonly Vector3 CaatingaSpawnPositon = new Vector3(-6, -4.5f, 0);
        public static readonly Vector3 CerradoSpawnPositon = new Vector3(-6, -5f, 0);
        public static readonly Vector3 PampaSpawnPositon = new Vector3(-6, -4.5f, 0);
        #endregion
    }
}
