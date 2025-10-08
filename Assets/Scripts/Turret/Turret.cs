using UnityEngine;
using UnityEngine.Events;

public abstract class Turret : MonoBehaviour
{
    internal UnityAction<Vector3,Vector3> Shooted;

    protected float _range = 50f;

    private float _cooldown = 0.25f;
    private float _timer = 0f;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _cooldown)
        {
            _timer = 0f;
            Shoot();
        }
    }

    protected virtual void Shoot()
    {
        Shooted?.Invoke(transform.position, transform.position + transform.forward * _range);
        Debug.DrawRay(transform.position, transform.forward * _range, Color.green);
    }
}
