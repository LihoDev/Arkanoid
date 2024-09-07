using UnityEngine;

public class CarriageSide : MonoBehaviour
{
    [SerializeField] private CarriageMover _source;
    [SerializeField] private float _upBorder;
    [SerializeField] private float _bottomBorder;
    [SerializeField] private bool _invertMoving;
    private float _startRotation;
    private float _sourceLeftBorder;
    private float _sourceRightBorder;
    private float _shift;

    private void Start()
    {
        _sourceLeftBorder = _source.LeftBorder;
        _sourceRightBorder = _source.RightBorder;
        _startRotation = transform.eulerAngles.z;
    }

    private void CalculateShift()
    {
        _shift = (Mathf.Abs(_sourceLeftBorder) + _source.transform.position.x) / (Mathf.Abs(_sourceLeftBorder) + _sourceRightBorder);
        _shift *= Mathf.Abs(_bottomBorder) + _upBorder;
        _shift += _bottomBorder;

        if (_invertMoving)
            _shift = _upBorder - _shift + _bottomBorder;
    }

    private void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation = _source.transform.eulerAngles;
        rotation.z += _startRotation;
        transform.eulerAngles = rotation;
        CalculateShift();
        Vector3 position = transform.position;
        position.y = _shift;
        transform.position = position;
    }
}
