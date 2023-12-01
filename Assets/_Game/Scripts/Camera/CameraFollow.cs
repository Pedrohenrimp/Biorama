using Biorama.Essentials;
using UnityEngine;

namespace Biorama.CameraManagement
{
    public class CameraFollow : MonoBehaviour
    {
        #region Members
        [SerializeField]
        [CustomName("Target")]
        private Transform mTarget;

        [SerializeField]
        [CustomName("Smooth Time")]
        private float mSmoothTime = 0.25f;

        [SerializeField]
        [CustomName("Vertical Offset")]
        private float mVerticalOffset = 0;

        [SerializeField]
        [CustomName("Horizontal Offset")]
        private float mHorizontalOffset = 0;

        [SerializeField]
        [CustomName("Camera Distance")]
        [Range(1.0f, 10.0f)]
        private float mCameraDistance = 5.0f;

        [SerializeField]
        [CustomName("Top Limit")]
        private Transform mTopLimit;

        [SerializeField]
        [CustomName("Down Limit")]
        private Transform mDownLimit;

        [SerializeField]
        [CustomName("Left Limit")]
        private Transform mLeftLimit;

        [SerializeField]
        [CustomName("Right Limit")]
        private Transform mRightLimit;

        private Vector3 mOffset;
        private Vector3 mVelocity = Vector3.zero;
        #endregion

        private void Start()
        {
            mOffset = new Vector3(mHorizontalOffset, mVerticalOffset, Camera.main.transform.position.z);
            Camera.main.orthographicSize = mCameraDistance;
        }

        private void Update()
        {
            #if UNITY_EDITOR
                mOffset.x = mHorizontalOffset;
                mOffset.y = mVerticalOffset;
                Camera.main.orthographicSize = mCameraDistance;
            #endif

            Vector3 targetPosition = mTarget.position + mOffset;

            targetPosition.x = Mathf.Clamp(targetPosition.x, mLeftLimit.position.x + (mCameraDistance * 1.78f), mRightLimit.position.x - (mCameraDistance * 1.78f));
            targetPosition.y = Mathf.Clamp(targetPosition.y, mDownLimit.position.y + mCameraDistance, mTopLimit.position.y - mCameraDistance);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref mVelocity, mSmoothTime);
        }

        public void SetHorizontalOffsetDirection(float aSignal)
        {
            if(aSignal > 0)
            {
                mHorizontalOffset = Mathf.Abs(mHorizontalOffset);
                mOffset.x = mHorizontalOffset;

            }
            else if(aSignal < 0)
            {
                mHorizontalOffset = -Mathf.Abs(mHorizontalOffset);
                mOffset.x = mHorizontalOffset;
            }

        }
    }
}
