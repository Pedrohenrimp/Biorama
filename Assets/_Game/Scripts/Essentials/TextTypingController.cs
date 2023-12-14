using Biorama.Essentials;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Biorama.UI.Text
{
    public class TextTypingController : MonoBehaviour
    {
        #region Members
        [SerializeField]
        [CustomName("Text Label")]
        private TextMeshProUGUI mTextLabel;

        [SerializeField]
        [CustomName("Typing Interval")]
        [Range(0.01f, 0.5f)]
        private float mTypingInterval = 0.05f;

        [TextAreaAttribute(minLines: 4, maxLines: 8)]
        [SerializeField]
        [CustomName("Text Message")]
        private string mText;
        public string Text
        {
            get
            {
                return mText;
            }
            set
            {
                mText = value;
            }
        }

        [SerializeField]
        [CustomName("Delay")]
        [Range(0.0f, 10.0f)]
        private float mDelay;


        private string mPartialText;

        private int mCurrentCharacter;
        #endregion

        #region Methods
        private void Awake()
        {
            mPartialText = string.Empty;
            mCurrentCharacter = 0;
        }

        private async void OnEnable()
        {
            await Task.Delay((int)mDelay*1000);
            TypeText();
        }
        public void TypeText()
        {
            if(mCurrentCharacter <= mText.Length)
            {
                mPartialText = mText.Substring(0, mCurrentCharacter);
                mTextLabel.text = mPartialText;
                mCurrentCharacter++;
                Invoke(nameof(TypeText), mTypingInterval);
            }
        }
        #endregion
    }
}
