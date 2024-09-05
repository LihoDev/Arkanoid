using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private CarriageMover _carriage;
    [SerializeField] private TextPointsPool _textPointsPool;
    [SerializeField] private Score _scrore;
    [SerializeField] private BlockCounter _blockCounter;
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
        transform.eulerAngles = Vector3.zero;
        _direction = _carriage.transform.up;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _direction = Vector2.Reflect(_direction, collision.GetContact(0).normal);
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            int points = block.GetPoints();
            Vector2 position = block.transform.position;
            if (block.TryDestroy())
            {
                _textPointsPool.PasteTextPoint(position, points);
                _scrore.AddPoints(points);
                _blockCounter.RemoveBlock();
            }
        }
    }
}
