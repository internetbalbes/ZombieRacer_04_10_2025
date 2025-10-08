using UnityEngine;

public class InstallPoint : MonoBehaviour
{
    [SerializeField] private bool _isOccupied = false;
    public bool IsOccupied => _isOccupied;

    private GameObject _installedObject;

    internal void InstallObject(GameObject installedObject)
    {
        _isOccupied = true;
        _installedObject = installedObject;
    }

    internal void Realese()
    {
        _isOccupied = false;
        Destroy(_installedObject);
    }
}
