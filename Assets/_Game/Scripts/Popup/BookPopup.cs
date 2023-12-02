using Biorama.Essentials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Biorama.Popups
{
    public enum PaginationType
    {
        Right,
        Left
    }
    public class BookPopup : BasePopup<BookPopup>
    {
        private static readonly string PopupName = nameof(BookPopup);

        public static BookPopup Instance => GetPopup(PopupName);

        #region Members
        [SerializeField]
        [CustomName("Book Animator")]
        private Animator mBookAnimator;

        private int mCurrentPage;
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
            if(CanPaginate(PaginationType.Left))
            {
                SetupPages(mCurrentPage);
                PlayPaginationAnimation(PaginationType.Left);
            }
        }

        public void OnRightButtonClicked()
        {
            if(CanPaginate(PaginationType.Right))
            {
                SetupPages(mCurrentPage);
                PlayPaginationAnimation(PaginationType.Right);
            }      
        }


        private bool CanPaginate(PaginationType aType)
        {
            switch(aType)
            {
                case PaginationType.Right:
                    {
                        return mBookAnimator.GetCurrentAnimatorStateInfo(0).IsName(Constants.BookNoneAnimaitonName);
                    }
                case PaginationType.Left:
                    {
                        return mBookAnimator.GetCurrentAnimatorStateInfo(0).IsName(Constants.BookNoneAnimaitonName);
                    }
            }
            return false;
        }

        private void SetupPages(int mPage)
        {

        }

        private void PlayPaginationAnimation(PaginationType aType)
        {
            switch(aType)
            {
                case PaginationType.Right:
                    {
                        mBookAnimator.Play(Constants.BookLeftToRightAnimaitonName);
                        break;
                    }
                case PaginationType.Left:
                    {
                        mBookAnimator.Play(Constants.BookRightToLeftAnimaitonName);
                        break;
                    }
            }
        }

        private void CloseBook()
        {
            base.Hide();
        }
        #endregion
    }
}
