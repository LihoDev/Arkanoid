using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Vector2 _startDirection = Vector2.up;
    [SerializeField] private CarriageMover _carriage;
    private Vector2 _direction;
    private Vector2 _startPosition;

    public void ReturnToOriginPosition()
    {
        transform.parent = _carriage.transform;
        transform.localPosition = _startPosition;
        enabled = false;
    }

    public void LaunchBall()
    {
        enabled = true;
        _startPosition = transform.localPosition;
        transform.parent = null;
        _direction = _startDirection;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _direction = Vector2.Reflect(_direction, collision.GetContact(0).normal);
    }
}
