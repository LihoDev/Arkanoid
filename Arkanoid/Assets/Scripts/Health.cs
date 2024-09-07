using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private List<GameObject> _images = new List<GameObject>();
    [SerializeField] private UnityEvent _onHelthOver;
    private int _activeIndex;

    public void DoDamage()
    {
        if (_images.Count > 0)
            _images[_activeIndex].SetActive(false);
        _activeIndex--;
        if (_activeIndex < 0)
        {
            _onHelthOver?.Invoke();
        }
    }

    public bool IsOver()
    {
        return _activeIndex < 0;
    }

    private void Start()
    {
        _activeIndex = _images.Count - 1;
    }
}
