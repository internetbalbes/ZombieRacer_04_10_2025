using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private float _speed = 5f;

    private float _rotationSpeed = 100f;

    private float _maxSpeed = 7f;
    private float _acceleration = 0.25f;

    private void Update()
    {
        Accelerate();
        MoveForward();
        JoystickRotate();

        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
    }

    private void Accelerate()
    {
        _speed += _acceleration * Time.deltaTime;
        _speed = Mathf.Clamp(_speed, 0f, _maxSpeed);
    }

    private void MoveForward()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void JoystickRotate()
    {
        float horizontalInput = _joystick.Horizontal;

        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            transform.Rotate(0f, horizontalInput * _rotationSpeed * Time.deltaTime, 0f);
        }
    }

    internal void Deccelerate()
    {
        _speed--;

        Debug.Log("PlayerDeccelerated");

        if (_speed <= 0)
        {
            Debug.Log("PlayerSpeedEqualOrLessThanZero");
        }
    }
}
