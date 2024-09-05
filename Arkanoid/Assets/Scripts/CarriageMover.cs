using UnityEngine;

public class CarriageMover : MonoBehaviour
{
    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;
    [SerializeField] private Camera _camera;
    [SerializeField] private string _rotationAxisName = "Mouse Y";
    [SerializeField] private Vector3 _rotateDirection = Vector3.up;
    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private float _maxAngle = 45f;

    private void Update()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = transform.position.y;
        transform.position = mousePosition;
        LimitDistance();
        transform.Rotate(_rotateDirection * _rotationSpeed * Input.GetAxis(_rotationAxisName) * Time.deltaTime);
        LimitAngle();
    }

    private void LimitDistance()
    {
        Vector3 position = transform.position;
        if (position.x < _leftBorder)
            position.x = _leftBorder;
        if (position.x > _rightBorder)
            position.x = _rightBorder;
        transform.position = position;
    }

    private void LimitAngle()
    {
        Vector3 rotation = transform.eulerAngles;
        if (rotation.z > _maxAngle && rotation.z < 90)
            rotation.z = _maxAngle;
        if (rotation.z < 365 - _maxAngle && rotation.z > 365 - 90)
            rotation.z = 365 - _maxAngle;
        if (45 < rotation.z && rotation.z < 365 - _maxAngle)
            rotation.z = 0;
        transform.eulerAngles = rotation;
    }
}
