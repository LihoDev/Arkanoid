using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool IsReflect {  get; set; } = true;
    public SpriteRenderer Sprite { get => _sprite; }
    [SerializeField] private float _speed = 5f;
    [SerializeField] private CarriageMover _carriage;
    [SerializeField] private SpriteRenderer _sprite;
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
        bool isBlock = collision.gameObject.TryGetComponent(out Block block);

        if (!collision.gameObject.TryGetComponent(out Gem gem) && !(isBlock && !IsReflect))
        {
            _direction = Vector2.Reflect(_direction, collision.GetContact(0).normal);
        }
        if (isBlock)
        {
            block.DoDamage();
        }
    }
}
