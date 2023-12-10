
using Biorama.ScriptableAssets.Book;

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
    }
}
