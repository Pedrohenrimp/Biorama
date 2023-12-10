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
        public static readonly string AmazoniaCollectible = "COLL_FLOWER_AM";
        public static readonly string MataAtlanticaCollectible = "COLL_WOOD_MA";
        public static readonly string PantanalCollectible = "COLL_WATER_PN";
        public static readonly string CaatingaCollectible = "COLL_MUD_CA";
        public static readonly string CerradoCollectible = "COLL_BRANCH_CE";
        public static readonly string PampaCollectible = "COLL_GRASS_PA";
        #endregion 
    }
}
