using UnityEngine;

public class PlayerStalker : MonoBehaviour
{
    private float _speed = 3f;

    private static Transform _player;

    void Start()
    {
        if (_player == null) _player = PlayerSingleton.Instance.transform;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(_player.position.x, transform.position.y, _player.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        transform.LookAt(targetPosition);
    }
}
