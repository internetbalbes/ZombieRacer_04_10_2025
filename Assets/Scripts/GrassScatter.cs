using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GrassScatter : MonoBehaviour
{
    [SerializeField] private GameObject _grassPrefab;
    [SerializeField] private int _grassCount = 100;
    [SerializeField] private float _grassSize = 0.25f;

    private void Start()
    {
        if (_grassPrefab == null) return;

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer == null) return;

        Vector3 size = renderer.bounds.size;
        Vector3 planePos = transform.position;

        for (int i = 0; i < _grassCount; i++)
        {
            Vector3 pos = new Vector3(
                planePos.x + Random.Range(-size.x / 2, size.x / 2),
                planePos.y,
                planePos.z + Random.Range(-size.z / 2, size.z / 2)
            );

            GameObject grass = Instantiate(_grassPrefab, pos, Quaternion.Euler(0, Random.Range(0, 360f), 0));
            grass.transform.localScale = Vector3.one * _grassSize;
            grass.transform.parent = transform;
        }
    }
}
