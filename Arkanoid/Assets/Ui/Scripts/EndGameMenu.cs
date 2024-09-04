using UnityEngine;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private BallStarter _ballStarter;

    public void Show()
    {
        _content.SetActive(true);
        Destroy(_ballStarter.gameObject);
        Time.timeScale = 0f;
    }

}
