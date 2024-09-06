using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private Gem _gem;

    public void Activate()
    {
        _gem.transform.parent = null;
        _gem.transform.localScale = Vector3.one;
        _gem.gameObject.SetActive(true);
    }

}
