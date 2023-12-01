using Biorama.Essentials;
using Biorama.Events;
using Biorama.ScriptableAssets.CustomSettings;
using UnityEngine;

namespace Biorama.Player
{
    public class PlayerInputController : MonoBehaviour
    {
        #region Members
        [SerializeField]
        [CustomName("Player Controller")]
        private CharacterController mPlayerController;

        [SerializeField]
        [CustomName("Animator")]
        private Animator mPlayerAnimator;

        [SerializeField]
        [CustomName("Horizontal Speed Value")]
        private float mHorizontalSpeed;

        [SerializeField]
        [CustomName("Max Height")]
        private float mMaxHeight;

        [SerializeField]
        [CustomName("Peak Time")]
        private float mPeakTime;

        [SerializeField]
        [CustomName("On Player Moved Event Key")]
        private string mOnPlayerMovedEventKey;

        private TransformEvent mOnPlayerMovedEvent;
        public TransformEvent OnPlayerMovedEvent
        {
            get
            {
                if(mOnPlayerMovedEvent == null)
                    mOnPlayerMovedEvent = (TransformEvent) ServiceLocator.Instance.CustomEventProvider.GetEvent(mOnPlayerMovedEventKey);
                
                return mOnPlayerMovedEvent;
            }
        }


        private CustomGameControl mCustomGameControl;

        private float mGravity;
        private float mJumpSpeed;

        private Vector2 mVelocityX;
        private Vector2 mVelocityY;

        private Vector2 mFinalVelocity;
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            mCustomGameControl = ServiceLocator.Instance.CustomGameControl;

            mGravity = 2 * mMaxHeight / Mathf.Pow(mPeakTime, 2);
            mJumpSpeed = mGravity * mPeakTime;
        }

        void Update()
        {
            if(ServiceLocator.Instance.IsGamePlaying)
            {
                
                if(Input.anyKeyDown)
                {
                    OnKeyDown();
                }

                Move();  
            }
        }

        #endregion

        #region Methods
        private void OnKeyDown()
        {
            if(IsKeyDown(GameControl.Pause))
            {
            }
            if(IsKeyDown(GameControl.Inventory))
            {

            }
            if(IsKeyDown(GameControl.Interact))
            {

            }
        }

        private bool IsKeyPressed(GameControl aGameControl)
        {
            return Input.GetKey(mCustomGameControl.GetValue(aGameControl));
        }

        private bool IsKeyDown(GameControl aGameControl)
        {
            return Input.GetKeyDown(mCustomGameControl.GetValue(aGameControl));
        }

        private void Move()
        {
            mVelocityX = GetVelocityX();

            if(!mPlayerController.isGrounded)
            {
                ApplyGravityEffect();
            }
            else
            {
                mVelocityY = IsJumping() ? (mJumpSpeed * Vector2.up) : Vector2.down;
            }

            

            mFinalVelocity =  mVelocityX + mVelocityY;

            mPlayerController.Move(mFinalVelocity * Time.deltaTime);

            mPlayerAnimator.SetBool("IsRuning", mVelocityX.x != 0);
            mPlayerAnimator.SetBool("IsJumping", !mPlayerController.isGrounded);

            if(mVelocityX.x != 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, mVelocityX.x > 0 ? 0 : -180, 0);
                ServiceLocator.Instance.CameraFollow.SetHorizontalOffsetDirection(mVelocityX.x);
            }

            
        }

        public Vector2 GetVelocityX()
        {
            var inputX =  IsKeyPressed(GameControl.MoveLeft) ? -1 :
                IsKeyPressed(GameControl.MoveRight) ? 1 : 0;

            return mHorizontalSpeed * inputX * Vector2.right;
        }

        private void ApplyGravityEffect()
        {
            mVelocityY += mGravity * Vector2.down * Time.deltaTime;
        }

        private bool IsJumping()
        {
            return (IsKeyDown(GameControl.Jump) || IsKeyDown(GameControl.MoveUp));
        }
        #endregion
    }
}
