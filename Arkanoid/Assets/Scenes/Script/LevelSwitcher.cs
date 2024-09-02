using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private int _nextLevelIndex = 1;

    public void StartNextLevel()
    {
        SceneManager.LoadScene(_nextLevelIndex);
    }
}
