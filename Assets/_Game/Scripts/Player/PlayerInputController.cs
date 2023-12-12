using Biorama.Essentials;
using Biorama.Events;
using Biorama.ScriptableAssets.CustomSettings;
using Biorama.UI;
using System.Threading.Tasks;
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
            InGameUIManager.OnNextBiome += SetPlayerStartPosition;

            mCustomGameControl = ServiceLocator.Instance.CustomGameControl;

            mGravity = 2 * mMaxHeight / Mathf.Pow(mPeakTime, 2);
            mJumpSpeed = mGravity * mPeakTime;

            if(ServiceLocator.Instance.PlayerGameData.HasSavedGame)
            {
                gameObject.transform.position = ServiceLocator.Instance.PlayerGameData.GameData.PlayerPositon;
            }
            else
            {
                SetPlayerStartPosition();
            }

            ServiceLocator.Instance.SetPlayerInputController(this);
        }

        private void OnDisable()
        {
            InGameUIManager.OnNextBiome -= SetPlayerStartPosition;
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

            ApplyGravityEffect();
            
            mFinalVelocity =  mVelocityX + mVelocityY;
            MovePlayer(mFinalVelocity);

            SetAnimation();
            SetRotation();
        }

        public Vector2 GetVelocityX()
        {
            var inputX =  IsKeyPressed(GameControl.MoveLeft) ? -1 :
                IsKeyPressed(GameControl.MoveRight) ? 1 : 0;

            return mHorizontalSpeed * inputX * Vector2.right;
        }

        private void ApplyGravityEffect()
        {
            if(!mPlayerController.isGrounded)
            {
                mVelocityY += mGravity * Vector2.down * Time.deltaTime;
            }
            else
            {
                mVelocityY = IsJumping() ? (mJumpSpeed * Vector2.up) : Vector2.down;
            }  
        }

        private void SetAnimation()
        {
            mPlayerAnimator.SetBool("IsRuning", mVelocityX.x != 0);
            mPlayerAnimator.SetBool("IsJumping", !mPlayerController.isGrounded);
        }

        private bool IsJumping()
        {
            return (IsKeyDown(GameControl.Jump) || IsKeyDown(GameControl.MoveUp));
        }

        private void SetRotation()
        {
            if(mVelocityX.x != 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, mVelocityX.x > 0 ? 0 : -180, 0);
                ServiceLocator.Instance.CameraFollow.SetHorizontalOffsetDirection(mVelocityX.x);
            }
        }

        private void MovePlayer(Vector2 aVelocity)
        {
            mPlayerController.Move(aVelocity * Time.deltaTime);
        }

        private async void SetPlayerStartPosition()
        {
            ServiceLocator.Instance.PauseGame(true);
            await Task.Delay(200);
            gameObject.transform.position = Helpers.GetPlayerSpawnPositionByBiomeType(ServiceLocator.Instance.CurrentBiome);
            await Task.Delay(100);
            ServiceLocator.Instance.PauseGame(false);
        }
        #endregion
    }
}
