using UnityEngine;

public class BallStarter : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private string _keyboardButtonName = "Jump";
    [SerializeField] private string _mouseButtonName = "Fire1";

    void Update()
    {
        if (Input.GetButtonDown(_keyboardButtonName) || Input.GetButtonDown(_mouseButtonName))
        {
            _ball.transform.parent = null;
            _ball.enabled = true;
            Destroy(gameObject);
        }
    }
}
