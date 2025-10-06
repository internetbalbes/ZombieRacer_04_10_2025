using UnityEngine;

public class PlayerStalker : MonoBehaviour
{
    private float _speed = 1f;

    private static Transform _player;

    void Start()
    {
        if (_player == null) _player = PlayerSingleton.Instance.transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }
}
