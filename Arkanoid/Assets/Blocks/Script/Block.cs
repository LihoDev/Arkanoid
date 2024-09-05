using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int _points = 10;

    public int GetPoints()
    {
        return _points;
    }

    public bool TryDestroy()
    {
        Destroy(gameObject);
        return true;
    }
}
