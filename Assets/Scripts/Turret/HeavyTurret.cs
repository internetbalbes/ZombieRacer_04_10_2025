using UnityEngine;

public class HeavyTurret : Turret
{
    protected override void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray, _range);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.TryGetComponent<EnemyCollision>(out EnemyCollision enemy))
                enemy.OnPlayerHit();
        }
        
        Debug.DrawRay(transform.position, transform.forward * _range, Color.green);
    }
}
