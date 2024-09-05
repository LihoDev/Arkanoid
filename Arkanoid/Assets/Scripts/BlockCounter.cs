using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    [SerializeField] private int _count = 1;
    [SerializeField] private EndGameMenu _victoryMenu;

    public void RemoveBlock()
    {
        _count--;
        if (_count == 0 )
        {
            _victoryMenu.Show();
        }
    }
}
