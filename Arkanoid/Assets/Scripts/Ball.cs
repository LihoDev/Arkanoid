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
        _direction = _startDirection;
        enabled = false;
    }

    private void Start()
    {
        _startPosition = transform.localPosition;
        _direction = _startDirection;
        transform.parent = null;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        _direction = Vector2.Reflect(_direction, collision.GetContact(0).normal);
    }
}
