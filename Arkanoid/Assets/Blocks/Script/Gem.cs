using Bonus;
using UnityEngine;

public abstract class Gem : MonoBehaviour
{
    [SerializeField] protected BonusSwitcher _switcher;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _minHeight = -6f;

    public abstract void Activate();

    private void Update()
    {
        transform.Translate(-transform.up * _speed * Time.deltaTime);
        if (transform.position.y < _minHeight)
        {
            Destroy(gameObject);
        }
    }
}
