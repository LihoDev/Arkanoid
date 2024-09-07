using UnityEngine;

public class CarriageMirror : MonoBehaviour
{
    [SerializeField] private CarriageMover _source;
    [SerializeField] private bool _axisY = false;
    private float _startRotation;
    private float _leftBorder;
    private float _rightBorder;
    private Vector2 position;

    private void Start()
    {
        _leftBorder = _source.LeftBorder;
        _rightBorder = _source.RightBorder;
        position = transform.position;
        _startRotation = transform.eulerAngles.z;
    }

    private void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation = _source.transform.eulerAngles;
        rotation.z += _startRotation;
        transform.eulerAngles = rotation;
        float shift = _rightBorder - _source.transform.position.x + _leftBorder;
        if (_axisY)
            position.y = shift;
        else 
            position.x = shift;
        transform.position = position;
    }
}
