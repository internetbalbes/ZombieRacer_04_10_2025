using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class BloodSplatter : MonoBehaviour
{
    private ParticleSystem _bloodParticleSystem;
    [SerializeField] private PlayerCollision _playerCollision;

    private void Start()
    {
        _bloodParticleSystem = GetComponent<ParticleSystem>();

        var main = _bloodParticleSystem.main;
        main.stopAction = ParticleSystemStopAction.None;
    }

    private void OnEnable()
    {
        _playerCollision.OnPlayerHit += PlayBloodEffect;
    }

    private void OnDisable()
    {
        _playerCollision.OnPlayerHit -= PlayBloodEffect;
    }

    private void PlayBloodEffect()
    {
        _bloodParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        _bloodParticleSystem.Play();
    }
}
