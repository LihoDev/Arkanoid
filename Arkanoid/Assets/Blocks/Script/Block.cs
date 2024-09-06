using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Block : MonoBehaviour
{
    [SerializeField] private int _points = 10;
    [SerializeField] private UnityEvent _onDestroy;
    private Health _health;
    private TextPointsPool _textPointsPool;
    private Score _scrore;
    private BlockCounter _blockCounter;

    public void DestroyImmediately()
    {
        _onDestroy?.Invoke();
        _textPointsPool.PasteTextPoint(transform.position, _points);
        _scrore.AddPoints(_points);
        _blockCounter.RemoveBlock();
        Destroy(gameObject);
    }

    public void DoDamage()
    {
        _health.DoDamage();
        if (_health.IsOver())
        {
            DestroyImmediately();
        }
    }

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _textPointsPool = FindAnyObjectByType<TextPointsPool>();
        if (_textPointsPool == null)
            Debug.LogError("TextPoints Pool not found!");
        _scrore = FindAnyObjectByType<Score>();
        if (_scrore == null)
            Debug.LogError("Score not found!");
        _blockCounter = FindAnyObjectByType<BlockCounter>();
        if (_blockCounter == null)
            Debug.LogError("Block Counter not found!");
    }
}
