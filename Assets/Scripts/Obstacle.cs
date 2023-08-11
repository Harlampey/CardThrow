using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Vector3 _rotateDirection;
    [SerializeField] private float _punchForce, _punchDuration;

    private void Update()
    {
        transform.Rotate(_rotateDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Card card))
        {
            card.DestroyCard();
            transform.DOPunchScale(Vector3.one * _punchForce, _punchDuration, 1, 1);
        }
    }
}
