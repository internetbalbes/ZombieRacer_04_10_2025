using UnityEngine;

public class InstallPointFollower : MonoBehaviour
{
    private Transform _target;

    public void Initialize(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null) return;
        transform.position = _target.position;
    }
}
