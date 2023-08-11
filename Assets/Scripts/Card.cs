using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SplineFollower _follower;

    [SerializeField] private Vector3 _cartRotationVector;
    [SerializeField] private Transform _mesh;
    private bool _canRotate;

    private float _appearTime = 0.15f;

    private void Start()
    {
        AnimateAppear();
    }
    private void AnimateAppear()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, _appearTime);
    }
    public void Throw()
    {
        _follower.enabled = true;
        _canRotate = true;
    }

    public void SetPath(SplineComputer splineComputer)
    {
        _follower.spline = splineComputer;
    }

    public void DestroyCard()
    {
        _follower.enabled = false;
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_canRotate)
            _mesh.Rotate(_cartRotationVector * Time.deltaTime);
    }
}
