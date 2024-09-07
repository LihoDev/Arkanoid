using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool IsReflect {  get; set; } = true;
    public SpriteRenderer Sprite { get => _sprite; }
    public float Speed { get => _speed; set { _speed = value; } }
    [SerializeField] private float _speed = 5f;
    [SerializeField] private CarriageMover _carriage;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radius = 0.125f;
    private Vector2 _direction;
    private Vector2 _startPosition;
    private ContactFilter2D contactFilter = new ContactFilter2D();
    private bool _isHited = false;
    private GameObject _lastCollision;

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

    private void Start()
    {
        contactFilter.NoFilter();
    }

    private void Update()
    {
        _isHited = false;
        transform.Translate(_direction * _speed * Time.deltaTime);

        Debug.DrawRay(transform.position, _direction * ((_speed * Time.deltaTime) + (_radius * transform.localScale.x)), Color.red);
        var hit = Physics2D.Raycast(transform.position, _direction, _speed * Time.deltaTime + (_radius * transform.localScale.x), _layerMask);
        if (hit.transform != null && !_isHited && _lastCollision != hit.transform.gameObject)
        {
            DetectCollision(hit.transform.gameObject, hit.normal);
            _lastCollision = hit.transform.gameObject;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isHited && _lastCollision != collision.gameObject)
        {
            DetectCollision(collision.gameObject, collision.GetContact(0).normal);
            _lastCollision = collision.gameObject;
        }
    }

    private void DetectCollision(GameObject collision, Vector2 normal)
    {
        bool isBlock = collision.TryGetComponent(out Block block);

        if (!collision.TryGetComponent(out Gem gem) && !(isBlock && !IsReflect))
        {
            _direction = Vector2.Reflect(_direction, normal);
            //ReflectDirection(collision.GetContact(0).normal);
        }
        if (isBlock)
        {
            block.DoDamage();
        }
        _isHited = true;
    }

    private void ReflectDirection(Vector2 normal)
    {
        _direction = Vector2.Reflect(_direction, normal);
    }
}
