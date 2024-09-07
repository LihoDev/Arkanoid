using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private BallStarter _ballStarter;
    [SerializeField] private string _escButtonName = "Cancel";
    [SerializeField] private CarriageMover _carriageMover;
    private bool _isShow = false;

    public void Show()
    {
        _isShow = true;
        _content.SetActive(true);
        _ballStarter.IsBlocked = true;
        _carriageMover.enabled = false;
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        _isShow = false;
        _content.SetActive(false);
        _ballStarter.IsBlocked = false;
        _carriageMover.enabled = true;
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
