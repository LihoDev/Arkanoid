using UnityEngine;

public class GemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Gem gem))
        {
            gem.Activate();
            Destroy(gem.gameObject);
        }
    }
}
