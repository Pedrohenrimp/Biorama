using System;
using UnityEngine;

namespace Biorama.ScriptableAssets.Book
{
    [Serializable]
    public enum BiomeType
    {
        Amazonia,
        MataAtlantica,
        Pantanal,
        Caatinga,
        Cerrado,
        Pampa,
        None
    }

    [Serializable]
    public class AnimalData
    {
        public string Id;
        public string Name;
        public string Description;
        public BiomeType BiomeType;
        public Sprite Icon;
    }

    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Book/AnimalObject", fileName = "AnimalObject")]
    public class AnimalObject : ScriptableObject
    {
        public string Id;

        public string Name;

        [TextAreaAttribute(8,8)]
        public string Description;

        public BiomeType BiomeType;

        public Sprite Icon;

        public AnimalData GetAnimalData()
        {
            return new AnimalData()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                BiomeType = this.BiomeType,
                Icon = this.Icon
            };
        }
    }
}
