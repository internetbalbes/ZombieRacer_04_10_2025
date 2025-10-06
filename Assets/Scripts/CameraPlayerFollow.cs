using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _xAngle = 45f;

    private void LateUpdate()
    {
        transform.position = _player.position + _offset;

        Vector3 lookTarget = new Vector3(_player.position.x, transform.position.y, _player.position.z);
        transform.LookAt(lookTarget);

        transform.Rotate(Vector3.right, _xAngle, Space.Self);
    }
}

