using UnityEngine;
using DG.Tweening;

public class VictoryEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _victoryPopUp;
    public void Play()
    {
        _particleSystem.Play();
        _victoryPopUp.DOScale(1f, 1f).SetDelay(0.4f);
    }
}
