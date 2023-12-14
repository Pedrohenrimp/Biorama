using UnityEngine;
using Biorama.Essentials;

namespace Biorama.UI
{
    public class FadeAnimationController : MonoBehaviour
    {
        #region Members
        [SerializeField]
        [CustomName("Animator")]
        private Animator mAnimator;
        #endregion

        #region Methods
        private void OnEnable()
        {
            FadeIn();
        }

        private void OnDisable()
        {
            FadeOut();
        }
        public void FadeIn()
        {
            mAnimator.Play("FadeIn");
        }

        public void FadeOut()
        {
            mAnimator.Play("FadeOut");
        }
        #endregion
    }
}
