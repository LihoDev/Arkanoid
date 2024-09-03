using UnityEngine;

public class BallStarter : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Blinker _blinker;
    [SerializeField] private string _keyboardButtonName = "Jump";
    [SerializeField] private string _mouseButtonName = "Fire1";

    public void ResetBall()
    {
        _ball.ReturnToOriginPosition();
        _blinker.IsHide = false;
        enabled = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown(_keyboardButtonName) || Input.GetButtonDown(_mouseButtonName))
        {
            _ball.enabled = true;
            _blinker.IsHide = true;
            enabled = false;
        }
    }
}
