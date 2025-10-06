using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class ObstacleCollision : MonoBehaviour
{
    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;

        Debug.Log("IsTriggerSettedTrue");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ObstacleTriggerEntered");

        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement _playerMovement))
        {
            PlayerTriggerEntered(_playerMovement);

            Debug.Log("ObstacleTriggeredEnteredPlayer");
        }
    }

    protected virtual void PlayerTriggerEntered(PlayerMovement _playerMovement) { }

    internal virtual void OnPlayerHit() { }
}
