using System.Collections;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _outputTimer;
    [SerializeField] private int _seconds = 60;
    [SerializeField] private EndGameMenu _defeatMenu;

    public void ShowTime(int value)
    {
        int minutes = value / 60;
        _outputTimer.text = $"{minutes}:{value - minutes * 60}";
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    protected IEnumerator Timer()
    {
        float time = _seconds;
        while (time > 0)
        {
            time -= Time.deltaTime;
            ShowTime((int)time);
            yield return new WaitForEndOfFrame();
        }
        _defeatMenu.Show();
    }
}
