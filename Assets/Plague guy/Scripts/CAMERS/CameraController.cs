using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 3f;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _target.position + _offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
