using Biorama.Essentials;
using Biorama.Popups.Book;
using Biorama.ScriptableAssets.Book;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Biorama.Popups
{
    public enum PaginationType
    {
        RightToLeft,
        LeftToRight
    }
    public class BookPopup : BasePopup<BookPopup>
    {
        private static readonly string PopupName = nameof(BookPopup);

        public static BookPopup Instance => GetPopup(PopupName);

        public static System.Action OnUnlockAnimal;

        #region Members
        [SerializeField]
        [CustomName("Book Animator")]
        private Animator mBookAnimator;

        [SerializeField]
        [CustomName("Left Page Content")]
        private AnimalContent mLeftPageContent;

        [SerializeField]
        [CustomName("Left Page Animation Content")]
        private AnimalContent mLeftPageAnimationContent;

        [SerializeField]
        [CustomName("Right Page Content")]
        private AnimalContent mRightPageContent;

        [SerializeField]
        [CustomName("Right Page Animation Content")]
        private AnimalContent mRightPageAnimationContent;

        [SerializeField]
        [CustomName("Left Button")]
        private Button mLeftButton;

        [SerializeField]
        [CustomName("Right Button")]
        private Button mRightButton;

        private BookPageObject mCurrentPageObject;

        private PaginationType mCurrentPaginationType;

        private int mCurrentPage;
        #endregion

        #region Methods
        public override void Show()
        {
            base.Show();

            SetupButtons();

            mCurrentPageObject = ServiceLocator.Instance.BookPageList.GetPageObject((BiomeType)mCurrentPage);

            mLeftPageContent.SetupView(mCurrentPageObject.GetLeftAnimalData());
            mLeftPageAnimationContent.SetupView(mCurrentPageObject.GetLeftAnimalData());
            mRightPageContent.SetupView(mCurrentPageObject.GetRightAnimalData());
            mRightPageAnimationContent.SetupView(mCurrentPageObject.GetRightAnimalData());

            mBookAnimator.Play(Constants.BookOpenBookAnimaitonName);
        }

        public override void Hide()
        {
            mBookAnimator.Play(Constants.BookHideBookAnimaitonName);

            Invoke(nameof(CloseBook),0.30f);
        }

        public void OnLeftButtonClicked()
        {
            if(CanPaginate(PaginationType.LeftToRight) && mCurrentPage > 0)
            {
                mCurrentPage--;
                mCurrentPaginationType = PaginationType.LeftToRight;
                SetupPages(mCurrentPage, mCurrentPaginationType);
                PlayPaginationAnimation(mCurrentPaginationType);
                SetupButtons();
            }
        }

        public void OnRightButtonClicked()
        {
            if(CanPaginate(PaginationType.RightToLeft) && mCurrentPage < ServiceLocator.Instance.BookPageList.pageList.Count - 1)
            {
                mCurrentPage++;
                mCurrentPaginationType = PaginationType.RightToLeft;
                SetupPages(mCurrentPage, mCurrentPaginationType);
                PlayPaginationAnimation(mCurrentPaginationType);
                SetupButtons();
            }      
        }

        public void OnUnlockLeftAnimalButtonClicked()
        {
            var animalData = mLeftPageContent.GetAnimalData();
            ServiceLocator.Instance.UserBook.AddAnimalData(animalData);
            ServiceLocator.Instance.UserInventory.UpdateItemAmount(Helpers.GetCollectableIdByBiomeType(animalData.BiomeType), -3);
            mLeftPageContent.SetupView(animalData);
            mLeftPageAnimationContent.SetupView(animalData);

            mRightPageContent.SetupView(mCurrentPageObject.GetRightAnimalData());
            mRightPageAnimationContent.SetupView(mCurrentPageObject.GetRightAnimalData());

            OnUnlockAnimal?.Invoke();
        }

        public void OnUnlockRightAnimalButtonClicked()
        {
            var animalData = mRightPageContent.GetAnimalData();
            ServiceLocator.Instance.UserBook.AddAnimalData(animalData);
            ServiceLocator.Instance.UserInventory.UpdateItemAmount(Helpers.GetCollectableIdByBiomeType(animalData.BiomeType), -3);
            mRightPageContent.SetupView(animalData);
            mRightPageAnimationContent.SetupView(animalData);

            mLeftPageContent.SetupView(mCurrentPageObject.GetLeftAnimalData());
            mLeftPageAnimationContent.SetupView(mCurrentPageObject.GetLeftAnimalData());

            OnUnlockAnimal?.Invoke();
        }

        private bool CanPaginate(PaginationType aType)
        {
            switch(aType)
            {
                case PaginationType.RightToLeft:
                    {
                        return mBookAnimator.GetCurrentAnimatorStateInfo(0).IsName(Constants.BookNoneAnimaitonName);
                    }
                case PaginationType.LeftToRight:
                    {
                        return mBookAnimator.GetCurrentAnimatorStateInfo(0).IsName(Constants.BookNoneAnimaitonName);
                    }
            }
            return false;
        }

        private void SetupPages(int aPage, PaginationType aType)
        {
            mCurrentPageObject = ServiceLocator.Instance.BookPageList.GetPageObject((BiomeType)aPage);
            switch(aType)
            {
                case PaginationType.RightToLeft:
                    {
                        mLeftPageAnimationContent.SetupView(mCurrentPageObject.GetLeftAnimalData());
                        mRightPageContent.SetupView(mCurrentPageObject.GetRightAnimalData());
                        break;
                    }
                case PaginationType.LeftToRight:
                    {
                        mRightPageAnimationContent.SetupView(mCurrentPageObject.GetRightAnimalData());
                        mLeftPageContent.SetupView(mCurrentPageObject.GetLeftAnimalData());
                        break;
                    }
            }

            Invoke(nameof(SetupPagesAfterAnimation), 0.4f);
        }

        private void SetupPagesAfterAnimation()
        {
            switch(mCurrentPaginationType)
            {
                case PaginationType.RightToLeft:
                    {
                        mRightPageAnimationContent.SetupView(mCurrentPageObject.GetRightAnimalData());
                        mLeftPageContent.SetupView(mCurrentPageObject.GetLeftAnimalData());
                        break;
                    }
                case PaginationType.LeftToRight:
                    {
                        mLeftPageAnimationContent.SetupView(mCurrentPageObject.GetLeftAnimalData());
                        mRightPageContent.SetupView(mCurrentPageObject.GetRightAnimalData());
                        break;
                    }
            }
        }

        private void PlayPaginationAnimation(PaginationType aType)
        {
            switch(aType)
            {
                case PaginationType.RightToLeft:
                    {
                        mBookAnimator.Play(Constants.BookRightToLeftAnimaitonName);
                        break;
                    }
                case PaginationType.LeftToRight:
                    {
                        mBookAnimator.Play(Constants.BookLeftToRightAnimaitonName);
                        break;
                    }
            }
        }

        private void SetupButtons()
        {
            mRightButton.interactable = mCurrentPage < ServiceLocator.Instance.BookPageList.pageList.Count - 1;
            mLeftButton.interactable = mCurrentPage > 0;
        }

        private void CloseBook()
        {
            base.Hide();
        }
        #endregion
    }
}
