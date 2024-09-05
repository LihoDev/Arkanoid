using TMPro;
using UnityEngine;

public class TextPoint : MonoBehaviour
{
    [SerializeField] private float _height = 1f;
    [SerializeField] private float _time = 1f;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private TextMeshPro _textMeshPro;
    [SerializeField] private Color _color = Color.green;
    private float _currentTime;
    private Vector2 _startPosition;

    public void StartAnimation(int value)
    {
        _startPosition = transform.position;
        _currentTime = 0f;
        _textMeshPro.text = $"+{value}";
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        Vector2 position = _startPosition;
        position.y += _curve.Evaluate(_currentTime) * _height;
        _textMeshPro.color = new Color(_color.r, _color.g, _color.b, _curve.Evaluate(_time - _currentTime));
        transform.position = position;
        if (_currentTime >= _time)
            gameObject.SetActive(false);
    }
}
