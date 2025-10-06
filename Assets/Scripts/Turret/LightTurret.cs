using UnityEngine;

public class LightTurret : Turret
{
    protected override void Shoot()
    {
        if (Physics.Raycast(new Ray(transform.position, transform.forward),out RaycastHit hit,_range))
        {
            if (hit.collider.TryGetComponent<EnemyCollision>(out EnemyCollision enemy))
                enemy.OnPlayerHit();
        }

        Debug.DrawRay(transform.position, transform.forward * _range, Color.green);
    }
}
