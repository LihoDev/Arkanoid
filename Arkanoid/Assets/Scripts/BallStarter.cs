using UnityEngine;

public class BallStarter : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Blinker _blinker;
    [SerializeField] private string _keyboardButtonName = "Jump";
    [SerializeField] private string _mouseButtonName = "Fire1";
    private bool _isBlocked;

    public bool IsBlocked 
    {
        set 
        { 
            _isBlocked = value;
        }
    }

    public void ResetBall()
    {
        _ball.ReturnToOriginPosition();
        _blinker.IsHide = false;
        enabled = true;
    }

    private void Update()
    {
        if (!_isBlocked && (Input.GetButtonDown(_keyboardButtonName) || Input.GetButtonDown(_mouseButtonName)))
        {
            _ball.LaunchBall();
            _blinker.IsHide = true;
            enabled = false;
        }
    }
}
