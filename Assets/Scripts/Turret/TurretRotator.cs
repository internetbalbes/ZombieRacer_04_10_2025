using UnityEngine;

public class TurretRotator : MonoBehaviour
{
    private float _rotationSpeed = 20f;

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }
}
