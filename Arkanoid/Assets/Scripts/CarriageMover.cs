using UnityEngine;

public class CarriageMover : MonoBehaviour
{
    [SerializeField] private string _axisKeyboardName = "Horizontal";
    [SerializeField] private string _axisMouseName = "Mouse X";
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;

    private void Update()
    {
        Vector3 moving = transform.right * _speed * Time.deltaTime;
        float keyboard = Input.GetAxis(_axisKeyboardName);
        float mouse = Input.GetAxis(_axisMouseName);
        moving *= (keyboard != 0) ? keyboard : mouse;
        transform.Translate(moving);
        LimitDistance();
    }

    private void LimitDistance()
    {
        Vector3 position = transform.position;
        if (transform.position.x < _leftBorder)
            position.x = _leftBorder;
        if (transform.position.x > _rightBorder)
            position.x = _rightBorder;
        transform.position = position;
    }
}
