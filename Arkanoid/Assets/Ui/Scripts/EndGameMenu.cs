using UnityEngine;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private BallStarter _ballStarter;
    [SerializeField] private CarriageMover _carriageMover;

    public void Show()
    {
        _content.SetActive(true);
        _carriageMover.enabled = false;
        Destroy(_ballStarter.gameObject);
        Time.timeScale = 0f;
    }
}
