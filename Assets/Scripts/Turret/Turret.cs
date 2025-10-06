using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    protected float _range = 10f;

    private float _cooldown = 1f;
    private float _timer = 0f;

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= _cooldown)
        {
            _timer = 0f;
            Shoot();
        }
    }

    protected virtual void Shoot() { }
}
