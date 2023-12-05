using System;
using UnityEngine;

namespace Biorama.ScriptableAssets.Book
{

    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Book/BookPageObject", fileName = "BookPageObject")]
    public class BookPageObject : ScriptableObject
    {
        public AnimalObject leftAnimal;
        public AnimalObject rightAnimal;
        public BiomeType biomeType;

        public AnimalData GetLeftAnimalData()
        {
            return new AnimalData()
            {
                Id = leftAnimal.Id,
                Name = leftAnimal.Name,
                Description = leftAnimal.Description,
                BiomeType = leftAnimal.BiomeType,
                Icon = leftAnimal.Icon
            };
        }

        public AnimalData GetRightAnimalData()
        {
            return new AnimalData()
            {
                Id = rightAnimal.Id,
                Name = rightAnimal.Name,
                Description = rightAnimal.Description,
                BiomeType = rightAnimal.BiomeType,
                Icon = rightAnimal.Icon
            };
        }

        public BiomeType GetPageBiomeType()
        {
            return biomeType;
        }
    }
}
