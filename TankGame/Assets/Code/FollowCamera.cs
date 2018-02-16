using UnityEngine;

namespace TankGame
{
    public class FollowCamera : MonoBehaviour, ICameraFollow
    {
        [SerializeField, Tooltip("The distance from which the camera follows the target.")]
        private float _followDistance = 10.0f;

        [SerializeField, Tooltip("The angle of the camera relative to negative Y-axis in degrees.")]
        private float _cameraAngle = 30.0f;

        [SerializeField, Tooltip("The target transform the camera follows.")]
        private Transform _target;

        [SerializeField, Tooltip("Toggles optional camera motion smoothing.")]
        private bool _cameraSmoothing = true;

        [SerializeField, Tooltip("Camera movement movement speed. Active only if camera smoothing is enabled.")]
        private float _moveSpeed = 6.0f;

        [SerializeField, Tooltip("Camera turn speed. Active only if camera smoothing is enabled.")]
        private float _turnSpeed = 6.0f;

        private Vector3 _targetPosition;
        private Quaternion _targetRotation;

        // Use this for initialization
        void Start()
        {
            Init();
        }

        public void Init()
        {
            // Check that a target is set!
            if (_target == null)
            {
                Debug.LogError("Target not set for FollowCamera in " + gameObject.name);
                enabled = false;
            }
        }

        private void Update()
        {
            _targetPosition = _target.position +
                              _target.forward * (-1f) * Mathf.Sin(Mathf.Deg2Rad * _cameraAngle) * _followDistance +
                              Vector3.up * Mathf.Cos(Mathf.Deg2Rad * _cameraAngle) * _followDistance;

            _targetRotation = Quaternion.LookRotation(_target.position - transform.position);

            if (_cameraSmoothing)
            {
                transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _moveSpeed);
                transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, Time.deltaTime * _turnSpeed);
            }
            else
            {
                transform.position = _targetPosition;
                transform.rotation = _targetRotation;
            }
        }
        /// <summary>
        /// Sets the camera follow distance.
        /// </summary>
        /// <param name="distance">Diagonal camera follow distance.</param>
        public void SetDistance(float distance)
        {
            _followDistance = distance;
        }

        /// <summary>
        /// Sets the camera follow angle relative to negative Y-axis.
        /// </summary>
        /// <param name="angle">Angle in degrees.</param>
        public void SetAngle(float angle)
        {
            _cameraAngle = angle;
        }

        /// <summary>
        /// Sets the target to follow.
        /// </summary>
        /// <param name="targetTransform">The transform that the camera should follow.</param>
        public void SetTarget(Transform targetTransform)
        {
            _target = targetTransform;
        }
    }
}
