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

        private AnimalData mAnimalData;


        public void SetupView(AnimalData aAnimalData)
        {
            mAnimalData = aAnimalData;
            var hasAnimal = ServiceLocator.Instance.UserBook.ContainsAnimal(aAnimalData);
            mBlockedContent.SetActive(!hasAnimal);

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
    }
}

