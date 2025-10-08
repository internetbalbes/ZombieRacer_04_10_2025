using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class Tracer : MonoBehaviour
{
    [SerializeField] private Turret _turret;

    [SerializeField] private float _tracerDuration = 0.02f;

    private LineRenderer _lineRenderer;
    private Coroutine _drawRoutine;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        ConfigureLine();
    }

    private void ConfigureLine()
    {
        _lineRenderer.startWidth = 0.05f;
        _lineRenderer.endWidth = 0.05f;
        _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        _lineRenderer.startColor = Color.yellow;
        _lineRenderer.endColor = Color.red;
        _lineRenderer.enabled = false;
    }

    public void DrawTracer(Vector3 start, Vector3 end)
    {
        if (_drawRoutine != null)
            StopCoroutine(_drawRoutine);

        _drawRoutine = StartCoroutine(DrawRoutine(start, end));
    }

    private IEnumerator DrawRoutine(Vector3 start, Vector3 end)
    {
        _lineRenderer.SetPosition(0, start);
        _lineRenderer.SetPosition(1, end);
        _lineRenderer.enabled = true;

        yield return new WaitForSeconds(_tracerDuration);

        _lineRenderer.enabled = false;
    }

    private void OnEnable() => _turret.Shooted += DrawTracer;
    private void OnDisable() => _turret.Shooted -= DrawTracer;
}
