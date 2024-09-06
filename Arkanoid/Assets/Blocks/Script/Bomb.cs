using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _radius = 10f;

    public void Activate()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        foreach (Block block in blocks) 
        {
            if (block.transform != transform && Vector2.Distance(block.transform.position, transform.position) <= _radius)
            {
                block.DestroyImmediately();
            }
        }
    }
}
