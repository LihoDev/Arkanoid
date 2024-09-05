using System.Collections.Generic;
using UnityEngine;

public class TextPointsPool : MonoBehaviour
{
    [SerializeField] private TextPoint _prefab;
    [SerializeField] private int _size = 5;
    private List<TextPoint> _pool = new List<TextPoint>();
    private int _currentIndex = 0;

    public void PasteTextPoint(Vector2 position, int value)
    {
        var text = _pool[_currentIndex];
        _currentIndex++;
        if (_currentIndex >= _size)
        {
            _currentIndex = 0;
        }
        text.transform.position = position;
        text.gameObject.SetActive(true);
        text.StartAnimation(value);
    }

    private void Start()
    {
        for (var i = 0; i < _size; i++)
        {
            var instance = Instantiate(_prefab, transform.position, Quaternion.identity, transform);
            instance.gameObject.SetActive(false);
            _pool.Add(instance);
        }
    }
}
