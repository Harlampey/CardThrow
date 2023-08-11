using UnityEngine;
using Dreamteck.Splines;

public class DirectionSetter : MonoBehaviour
{
    [SerializeField] private SplineComputer _spline;
    [SerializeField] private MeshRenderer _pathRenderer;
    [SerializeField] private CardThrow _cardThrow;

    [SerializeField] private Vector2 _middlePointSensetivity, _endPointSensetivity;

    private Vector3[] _pointsStartPositions;

    void Awake()
    {
        InitializeSplineDotsPositions();
    }
    private void InitializeSplineDotsPositions()
    {
        _pointsStartPositions = new Vector3[_spline.pointCount];
        for (int i = 0; i < _spline.pointCount; i++)
        {
            _pointsStartPositions[i] = _spline.GetPointPosition(i, SplineComputer.Space.Local);
        }
    }
    private void Update()
    {
        SetDirection();
        ShowOrHideTrajectory();
    }
    private void SetDirection()
    {
        if (_cardThrow.CanThrow)
        {
            Vector3 test = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            float horizontal = test.x - 0.5f;
            float vertical = test.y - 0.5f;

            _spline.SetPointPosition(1, _pointsStartPositions[1] + new Vector3(horizontal * _middlePointSensetivity.x, 0, vertical * _middlePointSensetivity.y), SplineComputer.Space.Local);
            _spline.SetPointPosition(2, _pointsStartPositions[2] + new Vector3(horizontal * _endPointSensetivity.x, 0, vertical * _endPointSensetivity.y), SplineComputer.Space.Local);
        }
    }
    private void ShowOrHideTrajectory()
    {
        if (!Level.IsPlaying)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            _pathRenderer.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _pathRenderer.enabled = false;
        }
    }
}
