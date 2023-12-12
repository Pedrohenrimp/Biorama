
using Biorama.ScriptableAssets.Book;
using UnityEngine;

namespace Biorama.Essentials
{
    public static class Helpers
    {
        public static string GetCollectableIdByBiomeType(BiomeType aBiome)
        {
            switch(aBiome)
            {
                case BiomeType.Amazonia:
                    {
                        return Constants.AmazoniaCollectible;
                    }
                case BiomeType.MataAtlantica:
                    {
                        return Constants.MataAtlanticaCollectible;
                    }
                case BiomeType.Pantanal:
                    {
                        return Constants.PantanalCollectible;
                    }
                case BiomeType.Caatinga:
                    {
                        return Constants.CaatingaCollectible;
                    }
                case BiomeType.Cerrado:
                    {
                        return Constants.CerradoCollectible;
                    }
                case BiomeType.Pampa:
                    {
                        return Constants.PampaCollectible;
                    }
            }
            
            return string.Empty;
        }

        public static Vector2 GetNextButtonPositionByBiomeType(BiomeType aBiome)
        {
            switch(aBiome)
            {
                case BiomeType.Amazonia:
                    {
                        return Constants.AmazoniaNextPositon;
                    }
                case BiomeType.MataAtlantica:
                    {
                        return Constants.MataAtlanticaNextPosition;
                    }
                case BiomeType.Pantanal:
                    {
                        return Constants.PantanalNextPosition;
                    }
                case BiomeType.Caatinga:
                    {
                        return Constants.CaatingaNextPosition;
                    }
                case BiomeType.Cerrado:
                    {
                        return Constants.CerradoNextPosition;
                    }
                case BiomeType.Pampa:
                    {
                        return Constants.PampaNextPosition;
                    }
            }
            
            return new Vector2(160, -3);
        }

        public static Vector3 GetPlayerSpawnPositionByBiomeType(BiomeType aBiome)
        {
            switch(aBiome)
            {
                case BiomeType.Amazonia:
                    {
                        return Constants.AmazoniaSpawnPositon;
                    }
                case BiomeType.MataAtlantica:
                    {
                        return Constants.MataAtlanticaSpawnPositon;
                    }
                case BiomeType.Pantanal:
                    {
                        return Constants.PantanalSpawnPositon;
                    }
                case BiomeType.Caatinga:
                    {
                        return Constants.CaatingaSpawnPositon;
                    }
                case BiomeType.Cerrado:
                    {
                        return Constants.CerradoSpawnPositon;
                    }
                case BiomeType.Pampa:
                    {
                        return Constants.PampaSpawnPositon;
                    }
            }
            
            return Constants.AmazoniaSpawnPositon;
        }
    }
}
