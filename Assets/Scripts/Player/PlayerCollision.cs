using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerCollision : MonoBehaviour
{
    private Collider _collider;
    private Rigidbody _rigidbody;

    internal event System.Action OnPlayerHit;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

        _collider.isTrigger = true;
        _rigidbody.useGravity = false;

        Debug.Log("IsTriggerSettedTrue");
        Debug.Log("UseGravitySettedFalse");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ObstacleCollision>(out ObstacleCollision _obstacleCollision))
        {
            _obstacleCollision.OnPlayerHit();
            OnPlayerHit?.Invoke();
        }
    }
}
