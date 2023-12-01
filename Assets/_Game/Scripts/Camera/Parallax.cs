using Biorama.Essentials;
using Biorama.Player;
using UnityEngine;

namespace Biorama.CameraManagement
{
    public class Parallax : MonoBehaviour
    {
        #region Members
        [SerializeField]
        [CustomName("Target Transform")]
        private Transform mTarget;

        [SerializeField]
        [CustomName("Velocity Proportion")]
        [Range(0.0f, 1.0f)]
        private float mVelocity = 0.1f;

        [SerializeField]
        [CustomName("Horizontal Parallax")]
        private bool mHorizontalParallax;

        [SerializeField]
        [CustomName("Vertical Parallax")]
        private bool mVerticalParallax;

        private Vector3 mLastPosition;
        #endregion

        private void Start()
        {
            mLastPosition = mTarget.position;
        }

        private void Update()
        {
            var TargetPositionVariation = mTarget.position - mLastPosition;

            if(!mHorizontalParallax)
                TargetPositionVariation.x = 0;
            if(!mVerticalParallax)
                TargetPositionVariation.y = 0;

            transform.position = transform.position + TargetPositionVariation * mVelocity;
            mLastPosition = mTarget.position;
        }
    }
}
