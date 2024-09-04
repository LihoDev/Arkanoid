using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private List<Image> _images = new List<Image>();
    [SerializeField] private EndGameMenu _defeatMenu;
    private int _activeIndex;

    public void DoDamage()
    {
        _images[_activeIndex].enabled = false;
        _activeIndex--;
        if (_activeIndex < 0)
            _defeatMenu.Show();
    }

    private void Start()
    {
        _activeIndex = _images.Count - 1;
    }
}
