using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _tMP_Text;
    private int _score;

    public void AddPoints(int count)
    {
        _score += count;
        UpdateText();
    }

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _tMP_Text.text = _score.ToString();
    }
}
