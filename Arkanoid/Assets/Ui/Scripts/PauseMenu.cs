using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private BallStarter _ballStarter;
    [SerializeField] private string _escButtonName = "Cancel";
    private bool _isShow = false;

    private void Show()
    {
        _content.SetActive(true);
        _ballStarter.IsBlocked = true;
        Time.timeScale = 0f;
    }

    private void Hide()
    {
        _content.SetActive(false);
        _ballStarter.IsBlocked = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetButtonDown(_escButtonName))
        {
            _isShow = !_isShow;
            if (_isShow) 
                Show();
            else
                Hide();
        }
    }
}
