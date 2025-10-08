using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _zombiePrefab;
    [SerializeField] private Transform _player;

    private float _spawnDistance = 15f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0.5f, 0.5f);
    }

    [ContextMenu("Spawn")]
    private void Spawn()
    {
        Instantiate(_zombiePrefab, PositionInFrontOfPlayer(), Quaternion.identity);
    }

    private Vector3 PositionInFrontOfPlayer()
    {
        return _player.position + _player.forward * _spawnDistance;
    }

}
