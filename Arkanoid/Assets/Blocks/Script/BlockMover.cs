using UnityEngine;

public class BlockMover : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    [SerializeField] private float _speed = 10f;
    private Transform _target;

    private void Start()
    {
        _target = _firstPoint;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        if (Vector2.Distance(_target.position, transform.position) < 0.001f)
        {
            ChangeTarget();
        } 
    }

    private void ChangeTarget()
    {
        _target = (_target == _firstPoint) ? _secondPoint : _firstPoint;
    }
}
