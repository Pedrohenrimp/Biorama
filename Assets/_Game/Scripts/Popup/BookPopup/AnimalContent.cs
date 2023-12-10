using Biorama.Essentials;
using Biorama.ScriptableAssets.Book;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Biorama.Popups.Book
{
    public class AnimalContent : MonoBehaviour
    {
        [SerializeField]
        [CustomName("Animal Name")]
        private TextMeshProUGUI mAnimalNameLabel;

        [SerializeField]
        [CustomName("Animal Description")]
        private TextMeshProUGUI mAnimalDescriptionLabel;

        [SerializeField]
        [CustomName("Animal Icon")]
        private Image mAnimalIcon;

        [SerializeField]
        [CustomName("Blocked Content")]
        private GameObject mBlockedContent;

        [Header("Collectable")]
        [SerializeField]
        [CustomName("Collectable Content")]
        private GameObject mCollectableContent;

        [SerializeField]
        [CustomName("Collectable Icon")]
        private Image mCollectableIcon;

        [SerializeField]
        [CustomName("Collectable Label")]
        private TextMeshProUGUI mCollectableLabel;

        [SerializeField]
        [CustomName("Collectable Button")]
        private Button mCollectableButton;

        private AnimalData mAnimalData;


        public void SetupView(AnimalData aAnimalData)
        {
            mAnimalData = aAnimalData;
            var hasAnimal = ServiceLocator.Instance.UserBook.ContainsAnimal(aAnimalData);
            mBlockedContent.SetActive(!hasAnimal);
            SetupColletableContent(aAnimalData);
            mAnimalDescriptionLabel.gameObject.SetActive(hasAnimal);

            if(aAnimalData != null && hasAnimal)
            {

                mAnimalNameLabel.text = aAnimalData.Name;
                mAnimalDescriptionLabel.text = aAnimalData.Description;
                mAnimalIcon.sprite = aAnimalData.Icon;
            }
            else
            {
                var blockedObject = ServiceLocator.Instance.AnimalDataList.GetBlockedAnimalObject();

                mAnimalNameLabel.text = blockedObject.Name;
                mAnimalDescriptionLabel.text = blockedObject.Description;
                mAnimalIcon.sprite = aAnimalData.Icon;
            }
        }

        public AnimalData GetAnimalData()
        {
            return mAnimalData;
        }

        public void SetupColletableContent(AnimalData aAnimalData)
        {
            var hasAnimal = ServiceLocator.Instance.UserBook.ContainsAnimal(aAnimalData);
            mCollectableContent.SetActive(!hasAnimal);
            if(!hasAnimal)
            {
                mCollectableIcon.sprite = ServiceLocator.Instance.Providers.CollectibleIconProvider.GetIconByBiomeType(aAnimalData.BiomeType);
                var collectable = ServiceLocator.Instance.UserInventory.GetInventoryItemById(Helpers.GetCollectableIdByBiomeType(aAnimalData.BiomeType));
                var amount = collectable != null ? collectable.Amount : 0;
                mCollectableLabel.text = $"{amount}/{Constants.CollectableRequirimentAmount}";
                mCollectableButton.interactable = amount >= Constants.CollectableRequirimentAmount;
            }
        }
    }
}

