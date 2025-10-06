using UnityEngine;

public class EnemyCollision : ObstacleCollision
{
    protected override void PlayerTriggerEntered(PlayerMovement _playerMovement)
    {
        _playerMovement.Deccelerate();
    }

    internal override void OnPlayerHit()
    {
        Destroy(gameObject);
    }
}
