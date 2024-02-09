using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed = 3.5f;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _rotation;
    
    private Transform _target;
    
    private void LateUpdate()
    {
        if(_target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_rotation), _rotationSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
