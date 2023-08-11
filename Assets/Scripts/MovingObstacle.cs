using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private float _minDistanceToPosition = 0.1f;
    [SerializeField] private float _speed;

    private Vector3 _targetPos;
    private int _posIndex;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _targetPos = _positions[0];
    }

    private void Update()
    {
        _transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);

        if (Vector3.Distance(_targetPos, _transform.position) < _minDistanceToPosition)
        {
            _posIndex = _posIndex + 1 == _positions.Length ? 0 : _posIndex + 1;
            _targetPos = _positions[_posIndex];
        }
    }
}
