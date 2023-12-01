using Biorama.Essentials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Biorama.Popups
{
    public class BookPopup : BasePopup<BookPopup>
    {
        private static readonly string PopupName = nameof(BookPopup);

        public static BookPopup Instance => GetPopup(PopupName);

        #region Members
        [SerializeField]
        [CustomName("Book Animator")]
        private Animator mBookAnimator;
        #endregion

        #region Methods
        public override void Show()
        {
            base.Show();

            mBookAnimator.Play(Constants.BookOpenBookAnimaitonName);
        }

        public override void Hide()
        {
            mBookAnimator.Play(Constants.BookHideBookAnimaitonName);

            Invoke(nameof(CloseBook),0.30f);
        }

        public void OnLeftButtonClicked()
        {
            if(mBookAnimator.GetCurrentAnimatorStateInfo(0).IsName(Constants.BookNoneAnimaitonName))
                mBookAnimator.Play(Constants.BookRightToLeftAnimaitonName);
        }

        public void OnRightButtonClicked()
        {
            if(mBookAnimator.GetCurrentAnimatorStateInfo(0).IsName(Constants.BookNoneAnimaitonName))
                mBookAnimator.Play(Constants.BookLeftToRightAnimaitonName);
        }

        private void CloseBook()
        {
            base.Hide();
        }
        #endregion
    }
}
