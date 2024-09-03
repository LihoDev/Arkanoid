using UnityEngine;

public class Blinker : MonoBehaviour
{
    [SerializeField] private float _time = 1f;
    [SerializeField] private GameObject _content;
    private bool _isShow = true;
    private float _currentTime;

    public bool IsHide { 
        set 
        { 
            _isShow = !value;
            _content.SetActive(_isShow);
            enabled = !value;
        } 
    }

    private void Start()
    {
        _currentTime = _time;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime < 0f)
        {
            _isShow = !_isShow;
            _content.SetActive(_isShow);
            _currentTime = _time;
        }
    }
}