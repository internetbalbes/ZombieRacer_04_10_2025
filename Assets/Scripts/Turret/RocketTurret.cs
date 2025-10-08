using UnityEngine;

public class RocketTurret : Turret
{
    private float _overlapSphereRadius = 5f;

    protected override void Shoot()
    {
        if (Physics.Raycast(new Ray(transform.position, transform.forward), out RaycastHit hit, _range))
        {
            Collider[] enemies = Physics.OverlapSphere(hit.point, _overlapSphereRadius);

            foreach (Collider enemyCollider in enemies)
            {
                if (enemyCollider.TryGetComponent<EnemyCollision>(out EnemyCollision enemy))
                {
                    enemy.OnPlayerHit();
                }
            }
        }

        base.Shoot();
    }
}
