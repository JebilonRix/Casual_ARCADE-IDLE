using UnityEngine;

namespace RedPanda.CameraFollow
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private Vector3 _followDistance;
        [SerializeField] private Vector3 _followRotation;

        private void Update()
        {
            SetPosition();
        }
        public void SetPosition()
        {
            if (_target != null)
            {
                transform.position = _target.transform.position + _followDistance;
                transform.rotation = Quaternion.Euler(_followRotation);
            }
        }
    }
}